﻿namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class User
{
    public int UserId { get; set; }

    public string? UserCode { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool? ActiveStatus { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}