using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.GetAll;

public class GetAllProviderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Provider, GetAllProviderResponse>();
    }
}