using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetAverageExpenseDetails
{
    public class Query : IRequest<Result<decimal>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Result<decimal>>
    {
        public async Task<Result<decimal>> Handle(Query request, CancellationToken cancellationToken)
        {
            var expenses = await context.Expenses.ToListAsync();

            decimal average = 0m;
            
            if (expenses.Count <= 0) return Result<decimal>.Success(average);

            foreach (Expense expense in expenses)
                average += expense.Amount;    

            average /= expenses.Count;

            return Result<decimal>.Success(average);
        }
    }
}