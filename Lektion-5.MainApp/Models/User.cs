﻿namespace Lektion_5.MainApp.Models;
public class User
{
    public string Id { get; set; }
    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string Email { get; set; } = null;
    public string? PhoneNumber { get; set; }
}