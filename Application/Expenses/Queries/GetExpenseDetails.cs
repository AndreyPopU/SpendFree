using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Expenses.Queries;

public class GetExpenseDetails
{
    public class Query : IRequest<Result<Expense>>
    {
        public required int Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Result<Expense>>
    {
        public async Task<Result<Expense>> Handle(Query request, CancellationToken cancellationToken)
        {
            var expense = await context.Expenses.FindAsync([request.Id], cancellationToken);

            if (expense == null) return Result<Expense>.Failure("Expense not found", 404);

            return Result<Expense>.Success(expense);
        }
    }
}