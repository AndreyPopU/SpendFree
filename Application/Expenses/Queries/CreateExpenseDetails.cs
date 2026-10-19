using System.ComponentModel.DataAnnotations;
using API.Dtos;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Application.Expenses.Queries;

public class CreateExpenseDetails
{
    public class Command : IRequest<Result<int>>
    {
        public required ExpenseDto Expense { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<int>>
    {
        public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var newExpense = mapper.Map<Expense>(request.Expense);

            context.Expenses.Add(newExpense);

            await context.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(newExpense.Id);
        }
    }
}