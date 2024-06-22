using Easy.Api.Extensions;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;
using Easy.CrossCutting.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configure dependencies
builder.Services.ConfigureDependenciesRepository(builder.Configuration);
builder.Services.AutoMapperConfig();

// Add controllers with JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    })
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Add API versioning and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersioning();
builder.Services.AddSwaggerPersonalizado();

// Configure authentication
builder.Services.AddAuthentication(builder.Configuration);



WebApplication app = builder.Build();

app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();
app.UseCors(builder => builder
    .SetIsOriginAllowed(orign => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
// Map controllers
app.MapControllers();

// Ensure the Resources directory exists and serve static files from it
string resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
if (!Directory.Exists(resourcesPath))
    Directory.CreateDirectory(resourcesPath);

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(resourcesPath),
    RequestPath = new PathString("/Resources")
});

app.Run();
