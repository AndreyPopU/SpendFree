using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetTransactions
{
    public class Query : IRequest<int> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, int>
    {
        public async Task<int> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await context.Expenses.ToListAsync();
            return result.Count;
        }
    }
}