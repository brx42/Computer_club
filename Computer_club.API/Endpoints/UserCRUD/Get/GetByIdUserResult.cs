﻿namespace Computer_club.Endpoints.UserCRUD.Get;

public class GetByIdUserResult
{
    public string FirstName { get; set; } 
    public string SecondName { get; set; }
    public string LastName { get; set; } 
    public string Login { get; set; } 
    public string Password { get; set; }
    public string ContactDetails { get; set; }
    public string Email { get; set; } 
    public string PhoneNumber { get; set; } 
    public DateTime DateOfBirth { get; set; }
}