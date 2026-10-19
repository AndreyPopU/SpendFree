using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetTransactions
{
    public class Query : IRequest<Result<int>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Result<int>>
    {
        public async Task<Result<int>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await context.Expenses.ToListAsync();

            if (result == null) return Result<int>.Failure("Expenses not found", 404);

            return Result<int>.Success(result.Count);
        }
    }
}