using KoperasiRegistrationAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using KoperasiRegistrationAPI.DTOs;
using AutoMapper;
using KoperasiRegistrationAPI.Models;

namespace KoperasiRegistrationAPI.Controllers;

public class RegistrationController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    public RegistrationController(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    [HttpGet("api/registration")]
    public async Task<IActionResult>  GetRegistrationInfo()
    {
        return Ok(new { Message = "Registration information retrieved successfully." });
    }

    [HttpPost("api/registration")]
    public async Task<IActionResult> RegisterMember([FromBody] RegisterRequest registrationData)
    {
        try
        {
            var account = _mapper.Map<Account>(registrationData);
            await _accountRepository.RegisterAccountAsync(account);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "An error occurred while registering.", Error = ex.Message });
        }
        return CreatedAtAction(nameof(GetRegistrationInfo), new { }, new { Message = "Member registered successfully." });
    }
}