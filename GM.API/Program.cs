using GM.Data.EFs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using Microsoft.AspNetCore.Mvc.Versioning;

using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Mvc;
using GM.API;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using GM.Data.Extensions;
using Main.Api.Middlewares;
using GM.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
const string myAllowAllOrigins = "_myAllowAllOrigins";
// Service Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowAllOrigins, policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("location", "Content-Disposition", "Link", "X-Total-Count", "X-Limit");
    });
});

// Service Context
builder.Services.AddDbContext<GMDbContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? string.Empty,
        b =>
        {
            b.MigrationsAssembly("GMDbContext");
            b.CommandTimeout(1200);
        }
    );
    options.ConfigureWarnings(config =>
    {
        config.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning);
        config.Ignore(RelationalEventId.BoolWithDefaultWarning);
    }
    );/// Dùng làm gì 

}, ServiceLifetime.Transient);

// Service Version
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

// Service Swagger
builder.Services.AddSwaggerGen(
    x=>x.EnableAnnotations()
    );
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

// Service Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new DependencyRegister()));


// Service Other
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
}); ///Custom json theo đúng định dạng

builder.Services.AddRouting(option => option.LowercaseUrls = true); ///hạ chữ cái khi router đưa ra ngoài 
var app = builder.Build();

var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
var collectionProvider = app.Services.GetRequiredService<IApiDescriptionGroupCollectionProvider>();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    collectionProvider.ApiDescriptionGroups.Items.ToList().ForEach(group =>
    {
        if (!string.IsNullOrEmpty(group.GroupName))
            descriptionProvider.ApiVersionDescriptions.ToList().ForEach(description =>
            {
                c.SwaggerEndpoint($"/swagger/{group.GroupName}/swagger.json",
                    $"{group.GroupName.ToUpperInvariant()} - {description.GroupName.ToUpperInvariant()}");
            });
    });
});

app.UseCors(myAllowAllOrigins);
app.UseMiddleware<HandleResponseMiddleware>();
app.UseMiddleware<AuthMiddleware>();

app.UseRouting();
app.MapControllers();
app.Run();