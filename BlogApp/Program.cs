using BlogApp.Data;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(options =>
{
    options.SerializerSettings = s =>
    {
        s.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    };
});

builder.Services.AddAuthorization();
builder.Services.AddAuthenticationJwtBearer(options =>
{
    options.SigningKey = builder.Configuration["Authorization:JWT:Key"];
});

builder.Services.AddDbContextFactory<ApplicationDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<JwtCreationOptions>(options =>
{
    options.SigningKey = builder.Configuration["Authorization:JWT:Key"]!;
    options.ExpireAt = DateTime.UtcNow.AddDays(1);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwaggerGen();
}

app.UseBlazorFrameworkFiles();
app.MapStaticAssets();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapFallbackToFile("index.html");
app.MapFastEndpoints(options =>
{
    options.Errors.UseProblemDetails();
    options.Endpoints.RoutePrefix = "api";
    options.Serializer.Options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

app.Run();