﻿using System.ComponentModel.DataAnnotations;

namespace ComputerClub.WebAPI.Endpoints.Account.Registration;

public class RegistrationRequest
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? SecondName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string? ContactDetails { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }
}