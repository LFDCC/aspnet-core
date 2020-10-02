using Microsoft.EntityFrameworkCore;

using MyProject.Roles;
using MyProject.Users;

using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MyProject.EntityFrameworkCore
{
    public static class MyProjectDbContextModelCreatingExtensions
    {
        public static void ConfigureMyProject(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<User>(b =>
            {
                b.ToTable(MyProjectConsts.DbTablePrefix + "Users", MyProjectConsts.DbSchema);
                b.HasKey(t => t.UserName).HasName("PK_User_UserName");
                b.HasIndex(t => t.RoleName).HasName("ID_Use_RoleName");
                
                b.ConfigureByConvention();
                b.ConfigureStringDefaultLength();


                /* Configure more properties here */
            });

            builder.Entity<Role>(b =>
            {
                b.ToTable(MyProjectConsts.DbTablePrefix + "Roles", MyProjectConsts.DbSchema);
                b.ConfigureByConvention();
                b.ConfigureStringDefaultLength();

                /* Configure more properties here */
            });
        }
    }
}
