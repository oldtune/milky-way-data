using Data;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using QuackQuack.Configs;
using OpenTelemetry.Metrics;
using Data.Repositories.Implementations;
using Data.Repositories;

var MyCorsOrigins = "MyCorsOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

// builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// builder.Services.AddScoped<IWordRepository, WordRepository>();

// builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// builder.Services.AddOpenTelemetry()
//     .WithTracing(tracerProviderBuilder =>
//         tracerProviderBuilder
//             .AddSource(DiagnosticsConfig.ActivitySource.Name)
//             .ConfigureResource(resource => resource
//                 .AddService(DiagnosticsConfig.ServiceName))
//             .AddAspNetCoreInstrumentation()
//             .AddHttpClientInstrumentation()
//             .AddJaegerExporter()
//             .AddConsoleExporter())
//     .WithMetrics(metricsProviderBuilder =>
//         metricsProviderBuilder
//         .ConfigureResource(resource => resource
//                 .AddService(DiagnosticsConfig.ServiceName))
//             .AddAspNetCoreInstrumentation()
//             .AddHttpClientInstrumentation()
//             .AddOtlpExporter(option =>
//             {
//                 option.Endpoint = new Uri("http://localhost:4317");
//             })
//             .AddConsoleExporter());


builder.Services.AddCors((options) =>
{
    options.AddPolicy(MyCorsOrigins, policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "https://localhost:3000");
    });
});

// builder.Services.AddDbContextPool<DictionaryDbContext>(config =>
// {
//     config.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//     config.UseNpgsql(builder.Configuration.GetConnectionString("Dictionary"), dbOptions =>
//     {
//         dbOptions.CommandTimeout(30);
//         dbOptions.EnableRetryOnFailure();
//         dbOptions.MigrationsAssembly("Data");
//     });
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// app.UseSwagger();
// app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(MyCorsOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
