using Npo.Api;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

////////////////////
// Create builder //
////////////////////
var builder = WebApplication.CreateBuilder(args);

//Configure NLOG
builder.Logging.ClearProviders();
builder.Logging.AddNLog();

// Use secrets.json if available
builder.Configuration.AddJsonFile("secrets/appsettings.secrets.json", optional: true, reloadOnChange: true);

// Use cors only if environment is Development
builder.AddCors("AllowAll");

// Add Controllers
builder.AddControllers();

// Add Api endpoint versioning
builder.AddVersioning();

// Add HttpContextAccessor dependecy injection
builder.Services.AddHttpContextAccessor();

// Add Dependency Injection
builder.AddDependencyInjection();

// Add swagger
builder.AddSwagger();


///////////////
// Build App //
///////////////
var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Test")
{
    app.UseCors("AllowAll");
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Use routing
app.UseRouting();

// Use swagger
app.UseSwagger();
app.UseSwaggerUI(SwaggerConfig.SwaggerUIOptions());

// Use controllers, map endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Run application
app.Run();
