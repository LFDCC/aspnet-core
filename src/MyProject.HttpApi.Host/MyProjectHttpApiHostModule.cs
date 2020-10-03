using System;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using MyProject.EntityFrameworkCore;
using MyProject.JwtSetttings;

using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(MyProjectApplicationModule),
        typeof(MyProjectEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreMvcModule)
        )]
    public class MyProjectHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            ConfigureConventionalControllers();
            ConfigureAuthentication(context, configuration);
            ConfigureAuthorization(context, configuration);
            ConfigureLocalization();
            ConfigureVirtualFileSystem(context);
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context);
        }
        /// <summary>
        /// 虚拟文件系统
        /// </summary>
        /// <param name="context"></param>
        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<MyProjectDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}MyProject.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MyProjectDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}MyProject.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MyProjectApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}MyProject.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<MyProjectApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}MyProject.Application"));
                });
            }
        }
        /// <summary>
        /// ApplicationService Convert Controller
        /// 自动Api控制器
        /// </summary>
        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(MyProjectApplicationModule).Assembly);
            });
        }

        /// <summary>
        /// 认证
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));
            JwtSetting setting = configuration.GetSection("JwtSetting").Get<JwtSetting>();

            context.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(setting.Secret)),
                    ValidIssuer = setting.Issuer,
                    ValidAudience = setting.AccessAudience,
                };
            });
        }
        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureAuthorization(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy =>
                {
                    policy.RequireRole("admin");
                });
                options.AddPolicy("teacher", policy =>
                {
                    policy.RequireRole("teacher");
                });
                options.AddPolicy("student", policy =>
                {
                    policy.RequireRole("student");
                });
                options.AddPolicy("teacher_student", policy =>
                {
                    policy.RequireRole("teacher", "student");
                });
            });
        }
        /// <summary>
        /// 配置Swagger
        /// </summary>
        /// <param name="context"></param>
        private static void ConfigureSwaggerServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                });
        }

        /// <summary>
        /// 本地化
        /// </summary>
        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });
        }
        /// <summary>
        /// 跨域
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();


            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject API");
            });

            app.UseAuditing();

            app.UseConfiguredEndpoints();
        }
    }
}
