global using Ardalis.ApiEndpoints;
global using AutoMapper;
using Computer_club.Data;
using Computer_club.Data.Repository.UserRepository;
using Computer_club.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("ClubConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(connection));

builder.Services.AddControllers(options => options.UseNamespaceRouteToken());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressInferBindingSourcesForParameters = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Computer_club_api", Version = "v1"});
    c.UseApiEndpoints();
    c.EnableAnnotations();
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IUserRepository<User>), typeof(UserRepository));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                    "Computer_club_api v1"));


app.UseEndpoints(endpoint =>
{
    endpoint.MapDefaultControllerRoute();
});

app.Run();