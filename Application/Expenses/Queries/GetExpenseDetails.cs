using Domain;
using MediatR;
using Persistence;

namespace Application.Expenses.Queries;

public class GetExpenseDetails
{
    public class Query : IRequest<Expense>
    {
        public required int Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Expense>
    {
        public async Task<Expense> Handle(Query request, CancellationToken cancellationToken)
        {
            var expense = await context.Expenses.FindAsync([request.Id], cancellationToken);

            if (expense == null) throw new Exception("Expense not found");

            return expense;
        }
    }
}