using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class GetExpensesList
{
    public class Query : IRequest<List<Expense>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Expense>>
    {
        public async Task<List<Expense>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Expenses.ToListAsync(cancellationToken);
        }
    }
}