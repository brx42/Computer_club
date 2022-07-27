namespace Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.Update;

public class UpdateAddressCommand
{
    public Guid Id { get; set; }
    public string Address { get; set; }
}