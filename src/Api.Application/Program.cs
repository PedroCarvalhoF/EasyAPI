using Api.Application.Extensions;
using Api.Extensions;
using CrossCutting.DependencyInjection;
using CrossCutting.Util;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);



builder.Services.ConfigureDependenciesRepository(builder.Configuration);

builder.Services.AutoMapperConfig();

builder.Services.AddControllers()
    .AddJsonOptions(options =>

    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    })
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddVersioning();

builder.Services.AddSwaggerPersonalizado();

builder.Services.AddAuthenticationSetup(builder.Configuration);



WebApplication app = builder.Build();


app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());



app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

if (!Path.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Resources")))
    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Resources"));


app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
    RequestPath = new PathString("/Resources")
});


CriaPerfilIdentity criaPerfilIdentity = new();
await criaPerfilIdentity.CriarPerfisUsuariosAsync(app);

app.Run();
