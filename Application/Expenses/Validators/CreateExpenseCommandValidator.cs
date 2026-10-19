

using Application.Expenses.Queries;
using FluentValidation;

public class CreateExpenseCommandValidator
    : AbstractValidator<CreateExpenseDetails.Command>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(x => x.Expense.Title).NotEmpty().MaximumLength(20).WithMessage("Title is required");
        RuleFor(x => x.Expense.Description).NotEmpty().MaximumLength(100).WithMessage("Description shouldn't be empty");
        RuleFor(x => x.Expense.CategoryId).GreaterThan(0).WithMessage("Select a valid category");
        RuleFor(x => x.Expense.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0");
    }
}