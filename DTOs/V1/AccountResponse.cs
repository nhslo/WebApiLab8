namespace BankAccountApi.DTOs.V1;

public class AccountResponse
{
    public int Id { get; set; }
    public string Owner { get; set; } = "";
    public decimal Balance { get; set; }
}
