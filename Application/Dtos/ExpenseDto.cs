namespace API.Dtos;

public class ExpenseDto
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }
    public int CategoryId { get; set; }
}