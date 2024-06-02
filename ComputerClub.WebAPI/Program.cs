using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ComputerClub.DAL.Database;
using ComputerClub.DAL.Entities;
using ComputerClub.Domain.Options;
using ComputerClub.WebAPI.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(builder.Configuration.GetConnectionString("ClubConnection")); });

IConfigurationSection optSection = builder.Configuration.GetSection("JwtOptions");
IConfigurationSection keySection = builder.Configuration.GetSection("JwtOptions:Keys");

builder.Services.Configure<JwtOptions>(optSection);
builder.Services.Configure<RsaKeys>(keySection);

JwtOptions? optSectionJwt = optSection.Get<JwtOptions>();
RsaKeys? key = keySection.Get<RsaKeys>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var pubKey = await key.GetPublicKey();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = optSectionJwt.Issuer,
            ValidateIssuer = false,
            ValidAudience = optSectionJwt.Audience,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = pubKey,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
        };
    });
builder.Services.AddRoleAndPolicy();

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSwagger();

builder.Services.AddFastEndpoints();

builder.Services.AddMapster();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints(config =>
{
    config.Serializer.Options.Converters.Add(new JsonStringEnumConverter());
    config.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.Endpoints.RoutePrefix = "api";
});

app.UseSwaggerGen();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    ILoggerFactory loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        ProjectSeed projectSeed = services.GetRequiredService<ProjectSeed>();
        await projectSeed.SeedAsync();
    }
    catch (Exception ex)
    {
        ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex.Message);
    }
}

app.Run();