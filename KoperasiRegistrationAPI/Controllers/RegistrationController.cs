using KoperasiRegistrationAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using KoperasiRegistrationAPI.DTOs;
using AutoMapper;
using KoperasiRegistrationAPI.Models;
using KoperasiRegistrationAPI.Helpers;

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

    [HttpPost("api/registration/start")]
    public IActionResult StartRegistration([FromBody] RegisterRequest request)
    {
        var sessionId = RegistrationSessionStore.CreateSession(request);

        var phoneCode = CodeGenerator.GenerateCode();
        var emailCode = CodeGenerator.GenerateCode();
        var expiry = DateTime.UtcNow.AddMinutes(4);

        ConfirmationCodeStore.StoreCode(request.PhoneNumber, new ConfirmationCode
        {
            ContactType = "Phone",
            ContactValue = request.PhoneNumber,
            Code = phoneCode,
            Expiry = expiry
        });

        ConfirmationCodeStore.StoreCode(request.Email, new ConfirmationCode
        {
            ContactType = "Email",
            ContactValue = request.Email,
            Code = emailCode,
            Expiry = expiry
        });

        Console.WriteLine($"[Mock] SMS to {request.PhoneNumber}: {phoneCode}");
        Console.WriteLine($"[Mock] Email to {request.Email}: {emailCode}");

        return Ok(new { Message = "Codes sent", SessionId = sessionId });
    }

    [HttpPost("api/registration/verify-code")]
    public IActionResult VerifyCode([FromBody] VerifyCodeRequest request)
    {
        var session = RegistrationSessionStore.GetSession(request.SessionId);
        if (session == null)
            return NotFound(new { Message = "Session not found" });

        var stored = ConfirmationCodeStore.GetCode(request.ContactValue);
        if (stored == null || stored.Expiry < DateTime.UtcNow || stored.Code != request.Code)
            return BadRequest(new { Message = "Invalid or expired code" });

        ConfirmationCodeStore.RemoveCode(request.ContactValue);

        if (stored.ContactType == "Phone") session.IsPhoneVerified = true;
        if (stored.ContactType == "Email") session.IsEmailVerified = true;

        return Ok(new
        {
            Message = $"{stored.ContactType} verified",
            EmailVerified = session.IsEmailVerified,
            PhoneVerified = session.IsPhoneVerified
        });
    }

    [HttpPost("api/registration/complete")]
    public async Task<IActionResult> CompleteRegistration([FromQuery] string sessionId)
    {
        var session = RegistrationSessionStore.GetSession(sessionId);
        if (session == null)
            return NotFound(new { Message = "Session not found" });

        if (!session.IsEmailVerified || !session.IsPhoneVerified)
            return BadRequest(new { Message = "Both phone and email must be verified before registration." });

        var account = _mapper.Map<Account>(session.RegistrationData);
        await _accountRepository.RegisterAccountAsync(account);

        RegistrationSessionStore.RemoveSession(sessionId); // Clean up

        return Ok(new { Message = "Member registered successfully", AccountId = account.Id });
    }
}