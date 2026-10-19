using API.Middleware;
using Application.Core;
using Application.Expenses.Queries;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<FakeDelayFilter>();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
builder.Services.AddMediatR(opt =>
{
    builder.Services.AddValidatorsFromAssemblyContaining<CreateExpenseDetails.Handler>();
    opt.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    opt.RegisterServicesFromAssemblyContaining<GetExpensesList.Handler>();
});

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfiles));
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "https://localhost:3000"));
app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AppDbContext>();
    await DbInitializer.SeedAsync(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured when creating the database for the application");
}

app.Run();
