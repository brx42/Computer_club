using System.Text.Json.Serialization;
using Computer_club.Domain.Models;

namespace Computer_club.Domain.Entities.User;

public class UserModel : BaseUserModel
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string ContactDetails { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string DateOfBirth { get; set; } = new DateTime().Date.ToString("d");
    
    public List<RefreshToken> RefreshTokens { get; set; }
}