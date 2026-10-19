using Application.Expenses.Queries;
using Microsoft.AspNetCore.Mvc;
using Domain;
using API.Dtos;

namespace API.Controllers;

public class ExpensesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Expense>>> GetExpenses()
    {
        return HandleResult(await Mediator.Send(new GetExpensesList.Query()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpenseById(int id)
    {
        return HandleResult(await Mediator.Send(new GetExpenseDetails.Query { Id = id }));
    }

    [HttpGet("average")]
    public async Task<ActionResult<decimal>> GetAverageExpenses()
    {
        return HandleResult(await Mediator.Send(new GetAverageExpenseDetails.Query()));
    }

    [HttpGet("total")]
    public async Task<ActionResult<decimal>> GetTotalExpenses()
    {
        return HandleResult(await Mediator.Send(new GetExpenseOverall.Query()));
    }

    [HttpGet("transactions")]
    public async Task<ActionResult<int>> GetTransactions()
    {
        return HandleResult(await Mediator.Send(new GetTransactions.Query()));
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateExpense([FromBody] ExpenseDto expense)
    {
        return HandleResult(await Mediator.Send(new CreateExpenseDetails.Command { Expense = expense }));
    }

    [HttpPut]
    public async Task<ActionResult> EditExpense(Expense expense)
    {
        await Mediator.Send(new EditExpenseDetails.Command { Expense = expense });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExpense(int id)
    {
        await Mediator.Send(new DeleteExpenseDetails.Command { Id = id });

        return Ok();
    }
}