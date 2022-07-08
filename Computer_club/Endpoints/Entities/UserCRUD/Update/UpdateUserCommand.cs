using System.ComponentModel.DataAnnotations;

namespace Computer_club.Endpoints.Entities.UserCRUD.Update;

public class UpdateUserCommand
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string ContactDetails { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string DateOfBirth { get; set; } = new DateTime().ToString("d");
}