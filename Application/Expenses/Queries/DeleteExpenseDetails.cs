using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class DeleteExpenseDetails
{
    public class Command : IRequest<Result<Unit>>
    {
        public required int Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var expense = await context.Expenses.FindAsync([request.Id], cancellationToken);

            if (expense == null) return Result<Unit>.Failure("Expense not found", 404);

            context.Remove(expense);

            var result = await context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to delete expense", 400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}