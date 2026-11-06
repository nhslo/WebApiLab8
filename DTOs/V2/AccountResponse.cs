namespace BankAccountApi.DTOs.V2;

public class AccountResponse
{
    public int Id { get; set; }
    public string OwnerName { get; set; } = "";
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "";
    public string Status { get; set; } = "";
}
