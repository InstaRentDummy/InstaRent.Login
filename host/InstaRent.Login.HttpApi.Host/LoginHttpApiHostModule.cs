using InstaRent.Login.EntityFrameworkCore;
using InstaRent.Login.MultiTenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
//using Volo.Abp.Caching;
//using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
//using Volo.Abp.PermissionManagement.EntityFrameworkCore;
//using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
//using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.VirtualFileSystem;

namespace InstaRent.Login;

[DependsOn(
    typeof(LoginApplicationModule),
    typeof(LoginEntityFrameworkCoreModule),
    typeof(LoginHttpApiModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAutofacModule),
    //typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    //typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    //typeof(AbpSettingManagementEntityFrameworkCoreModule),
    //typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
    )]
public class LoginHttpApiHostModule : AbpModule
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<LoginDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}InstaRent.Login.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<LoginDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}InstaRent.Login.Domain", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<LoginApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}InstaRent.Login.Application.Contracts", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<LoginApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}InstaRent.Login.Application", Path.DirectorySeparatorChar)));
            });
        }

        context.Services.AddAbpSwaggerGen(
            //configuration["AuthServer:Authority"],
            //new Dictionary<string, string>
            //{
            //    {"Login", "Login API"}
            //},
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Login API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.HideAbpEndpoints();
            });

        //Configure<AbpLocalizationOptions>(options =>
        //{
        //    options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
        //    options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
        //    options.Languages.Add(new LanguageInfo("en", "en", "English"));
        //    options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
        //    options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
        //    options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
        //    options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
        //    options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
        //    options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
        //    options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
        //    options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
        //    options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
        //    options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
        //    options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
        //    options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
        //    options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
        //    options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
        //    options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
        //    options.Languages.Add(new LanguageInfo("es", "es", "Español"));
        //});

        //context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(options =>
        //    {
        //        options.Authority = configuration["AuthServer:Authority"];
        //        options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
        //        options.Audience = "Login";
        //    });

        //Configure<AbpDistributedCacheOptions>(options =>
        //{
        //    options.KeyPrefix = "Login:";
        //});

        //var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("Login");
        //if (!hostingEnvironment.IsDevelopment())
        //{
        //    var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        //    dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "Login-Protection-Keys");
        //}

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
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
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        //app.UseAuthentication();
        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }
        app.UseAbpRequestLocalization();
        //app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Login API");

            //var configuration = context.GetConfiguration();
            //options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            //options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            //options.OAuthScopes("Login");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
