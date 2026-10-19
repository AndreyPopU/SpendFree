using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Expenses.Queries;

public class EditExpenseDetails
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Expense Expense { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var expense = await context.Expenses.FindAsync(request.Expense.Id, cancellationToken);

            if (expense == null) return Result<Unit>.Failure("Expense not found", 404);

            mapper.Map(request.Expense, expense);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Result<Unit>.Failure("Failed to save Expense", 400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}