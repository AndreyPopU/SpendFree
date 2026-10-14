using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetAverageExpenseDetails
{
    public class Query : IRequest<decimal> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, decimal>
    {
        public async Task<decimal> Handle(Query request, CancellationToken cancellationToken)
        {
            var expenses = await context.Expenses.ToListAsync();

            decimal average = 0m;

            foreach (Expense expense in expenses)
                average += expense.Amount;    

            average /= expenses.Count;

            return average;
        }
    }
}