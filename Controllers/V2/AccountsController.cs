using Asp.Versioning;
using BankAccountApi.DTOs.V2;
using BankAccountApi.Models;
using BankAccountApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountApi.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/accounts")]
public class AccountsController : ControllerBase
{
    private readonly AccountService service;
    public AccountsController(AccountService service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(service.GetAll().Select(ToResponse));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var account = service.GetById(id);
        if (account == null)
        {
            return NotFound();
        }
        return Ok(ToResponse(account));
    }

    [HttpGet("summary")]
    public IActionResult Summary() => Ok(new
    {
        count = service.GetAll().Count,
        totalBalance = service.GetAll().Sum(accountItem => accountItem.Balance)
    });

    private static AccountResponse ToResponse(BankAccount account) => new()
    {
        Id = account.Id, OwnerName = account.Owner, Balance = account.Balance,
        Currency = account.Currency, Status = account.Status
    };
}
