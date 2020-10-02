using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace MyProject.Data
{
    public class MyProjectDbMigrationService : ITransientDependency
    {
        public ILogger<MyProjectDbMigrationService> Logger { get; set; }

        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<IMyProjectDbSchemaMigrator> _dbSchemaMigrators;

        public MyProjectDbMigrationService(
            IDataSeeder dataSeeder,
            IEnumerable<IMyProjectDbSchemaMigrator> dbSchemaMigrators)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;

            Logger = NullLogger<MyProjectDbMigrationService>.Instance;
        }

        public async Task MigrateAsync()
        {
            Logger.LogInformation("Started database migrations...");

            await MigrateDatabaseSchemaAsync();
            await SeedDataAsync();

            Logger.LogInformation("Successfully completed database migrations.");
        }

        private async Task MigrateDatabaseSchemaAsync()
        {
            Logger.LogInformation($"Migrating schema for host database...");

            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }
        }

        private async Task SeedDataAsync()
        {
            Logger.LogInformation($"Executing host database seed...");

            await _dataSeeder.SeedAsync();
        }
    }
}