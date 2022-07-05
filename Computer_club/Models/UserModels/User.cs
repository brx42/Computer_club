namespace Computer_club.Models.UserModels;

public class User : BaseModel
{
    public string FullName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string ContactDetails { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string DateOfBirth { get; set; }
}