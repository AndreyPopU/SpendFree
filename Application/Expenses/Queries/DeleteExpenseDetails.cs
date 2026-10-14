using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses.Queries;

public class DeleteExpenseDetails
{
    public class Command : IRequest
    {
        public required int Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var expense = await context.Expenses.FindAsync([request.Id], cancellationToken)
                ?? throw new Exception("Expense not found");

            context.Remove(expense);

            await context.SaveChangesAsync();
        }
    }
}