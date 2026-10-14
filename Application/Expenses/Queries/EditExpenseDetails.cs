using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Expenses.Queries;

public class EditExpenseDetails
{
    public class Command : IRequest
    {
        public required Expense Expense { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var expense = await context.Expenses.FindAsync(request.Expense.Id, cancellationToken)
            ?? throw new Exception("Cannot find Expense");

            mapper.Map(request.Expense, expense);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}