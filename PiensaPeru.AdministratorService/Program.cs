using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PiensaPeru.AdministratorService.Domain.Persistence.Contexts;
using PiensaPeru.AdministratorService.Domain.Persistence.Repositories;
using PiensaPeru.AdministratorService.Domain.Services;
using PiensaPeru.AdministratorService.Persistence.Repositories;
using PiensaPeru.AdministratorService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//CORS
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection Configuration

builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddScoped<IManagementRepository, ManagementRepository>();

// Services
builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IManagementService, ManagementService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Piensa Peru Administrator Microservice", Version = "v1" });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    // Ensure Database is created, including seed data
    context.Database.EnsureCreated();
}

app.Run();
