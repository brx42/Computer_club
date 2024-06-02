using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.Create;

public class CreateProviderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateProviderRequest, Provider>();

        config.ForType<Provider, CreateProviderResponse>();
    }
}