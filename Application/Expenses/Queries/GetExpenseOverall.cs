using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetExpenseOverall
{
    public class Query : IRequest<decimal> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, decimal>
    {
        public async Task<decimal> Handle(Query request, CancellationToken cancellationToken)
        {
            var expenses = await context.Expenses.ToListAsync();

            decimal total = 0;
            foreach (Expense expense in expenses)
                total += expense.Amount;

            return total;
        }
    }
}