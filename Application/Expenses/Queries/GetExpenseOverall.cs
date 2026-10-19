using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetExpenseOverall
{
    public class Query : IRequest<Result<decimal>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Result<decimal>>
    {
        public async Task<Result<decimal>> Handle(Query request, CancellationToken cancellationToken)
        {
            var expenses = await context.Expenses.ToListAsync();

            decimal total = 0;

            if (expenses.Count <= 0) return Result<decimal>.Success(total);

            foreach (Expense expense in expenses)
                total += expense.Amount;

            return Result<decimal>.Success(total);
        }
    }
}