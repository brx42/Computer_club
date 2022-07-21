global using Ardalis.ApiEndpoints;
global using AutoMapper;
using Computer_club.Domain.Data;
using Computer_club.Domain.Entities;
using Computer_club.Domain.Services.AuthService;
using Computer_club.Domain.Services.TokenService;
using Computer_club.Domain.Services.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Computer_club.Domain.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var optSection = builder.Configuration.GetSection("JwtOptions");
var keySection = builder.Configuration.GetSection("JwtOptions:Keys");
builder.Services.Configure<JwtOptions>(optSection);
builder.Services.Configure<RsaKeys>(keySection);
var optSectionJwt = optSection.Get<JwtOptions>();
var key = keySection.Get<RsaKeys>();

builder.Services.AddControllers(options =>
    options.UseNamespaceRouteToken())
                .AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = 
        ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped(typeof(IUserRepository<User>), typeof(UserRepository));

var pubKey = await key.GetPublicKey();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer("Bearer", options=>
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
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ClubConnection")));

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Computer_club_api", Version = "v1"});
    c.UseApiEndpoints();
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Authorization using bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
        }
    });
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                    "Computer_club_api v1"));

app.UseEndpoints(endpoint =>
{
    endpoint.MapDefaultControllerRoute();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        await AppDbSeed.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex.Message);
    }
}

app.Run();