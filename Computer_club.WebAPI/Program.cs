global using Ardalis.ApiEndpoints;
global using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Computer_club.Data.Database;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Domain.Extensions;
using Computer_club.Domain.Options;
using Computer_club.WebAPI.Mapping;
using Computer_club.WebAPI.Mapping.MappingForBack;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ClubConnection")));

var optSection = builder.Configuration.GetSection("JwtOptions");
var keySection = builder.Configuration.GetSection("JwtOptions:Keys");
builder.Services.Configure<JwtOptions>(optSection);
builder.Services.Configure<RsaKeys>(keySection);
var optSectionJwt = optSection.Get<JwtOptions>();
var key = keySection.Get<RsaKeys>();

builder.Services.AddControllers(options =>
    options.UseNamespaceRouteToken())
    .AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddServices();

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
builder.Services.AddRoleAndPolicy();

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;

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

builder.Services.AddAutoMapper
    (typeof(UserMapping),
    typeof(RoleMapping),
    typeof(ClubMapping),
    typeof(AccountMapping),
    typeof(ProviderMapping), 
    typeof(HistoryEquipmentMapping),
    typeof(PhotoMapping), 
    typeof(DeviceSetMapping), 
    typeof(EquipmentMapping), 
    typeof(PlaceMapping), 
    typeof(ScheduleMapping));


var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

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
        var context = services.GetRequiredService<AppDbContext>();
        await AppDbSeed.SeedAsync(userManager, roleManager, context);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex.Message);
    }
}

app.Run();