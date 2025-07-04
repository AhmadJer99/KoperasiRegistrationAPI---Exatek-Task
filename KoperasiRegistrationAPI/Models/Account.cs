﻿namespace KoperasiRegistrationAPI.Models;

public class Account
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? ICNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public PinInfo? PinInfo { get; set; }  
}