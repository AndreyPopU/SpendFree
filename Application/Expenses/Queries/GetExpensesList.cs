using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetExpensesList
{
    public class Query : IRequest<Result<List<Expense>>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Result<List<Expense>>>
    {
        public async Task<Result<List<Expense>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await context.Expenses.ToListAsync(cancellationToken);

            if (result == null) return Result<List<Expense>>.Failure("Failed to find expenses", 404);

            return Result<List<Expense>>.Success(result);
        }
    }
}