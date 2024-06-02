using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.GetById;

public class GetByIdProviderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Provider, GetByIdProviderResponse>();
    }
}