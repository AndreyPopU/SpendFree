using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedAsync(
    AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (await context.Categories.AnyAsync())
            return;

        var categories = new List<Category>
        {
            new() { Name = "Food" },
            new() { Name = "Bills" },
            new() { Name = "Rent" },
            new() { Name = "Fun" },
            new() { Name = "Transport" }
        };

        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();

        var expenses = new List<Expense>
        {
            new()
            {
                Description = "Groceries",
                Amount = 45.50m,
                Date = DateTime.UtcNow.AddDays(-2),
                CategoryId = categories[0].Id,
                Name = "LIDL",
                CategoryName = "Food"
            },
            new()
            {
                Description = "Electricity bill",
                Amount = 65.00m,
                Date = DateTime.UtcNow.AddDays(-5),
                CategoryId = categories[1].Id,
                Name = "Electricity.CO",
                CategoryName = "Bills"
            },
            new()
            {
                Description = "Monthly rent",
                Amount = 600.00m,
                Date = DateTime.UtcNow.AddDays(-7),
                CategoryId = categories[2].Id,
                Name = "Rent",
                CategoryName = "Rent"

            },
            new()
            {
                Description = "Cinema tickets",
                Amount = 24.00m,
                Date = DateTime.UtcNow.AddDays(-1),
                CategoryId = categories[3].Id,
                Name = "Cinema",
                CategoryName = "Fun"
            },
            new()
            {
                Description = "Bus pass",
                Amount = 25.00m,
                Date = DateTime.UtcNow,
                CategoryId = categories[4].Id,
                Name = "Transport",
                CategoryName = "Transport",
            }
        };

        context.Expenses.AddRange(expenses);
        await context.SaveChangesAsync();
    }
}