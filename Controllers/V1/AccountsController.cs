using Asp.Versioning;
using BankAccountApi.DTOs.V1;
using BankAccountApi.Models;
using BankAccountApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountApi.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
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

    private static AccountResponse ToResponse(BankAccount account) => new()
    {
        Id = account.Id, Owner = account.Owner, Balance = account.Balance
    };
}
