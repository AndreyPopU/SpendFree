using API.Dtos;
using Domain;
using MediatR;
using Persistence;

namespace Application.Expenses.Queries;

public class CreateExpenseDetails
{
    public class Command : IRequest<int>
    {
        public required ExpenseDto Expense { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, int>
    {
        public async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            Expense newExpense = new Expense
            {
                Name = request.Expense.Title,
                CategoryId = request.Expense.CategoryId,
                Description = request.Expense.Description,
                Amount = request.Expense.Amount,
                Date = DateTime.UtcNow
            };

            context.Expenses.Add(newExpense);

            await context.SaveChangesAsync(cancellationToken);

            return newExpense.Id;
        }
    }
}