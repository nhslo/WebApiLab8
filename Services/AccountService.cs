using BankAccountApi.Models;

namespace BankAccountApi.Services;

public class AccountService
{
    private readonly List<BankAccount> accounts = new()
    {
        new() { Id = 1, Owner = "Ivan Petrov", Balance = 150000, Currency = "KZT", Status = "Active" },
        new() { Id = 2, Owner = "Anna Sidorova", Balance = 75000, Currency = "KZT", Status = "Active" },
        new() { Id = 3, Owner = "Sergey Ivanov", Balance = 50000, Currency = "KZT", Status = "Blocked" }
    };

    public List<BankAccount> GetAll()

    {

        return accounts;

    }
    public BankAccount? GetById(int id) => accounts.FirstOrDefault(accountItem => accountItem.Id == id);
}
