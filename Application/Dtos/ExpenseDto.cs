namespace API.Dtos;

public class ExpenseDto
{
    public required string Title { get; set; }
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }
    public required int CategoryId { get; set; }
}