namespace BankAccountApi.Models;

public class BankAccount
{
    public int Id { get; set; }
    public string Owner { get; set; } = "";
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "";
    public string Status { get; set; } = "";
}
