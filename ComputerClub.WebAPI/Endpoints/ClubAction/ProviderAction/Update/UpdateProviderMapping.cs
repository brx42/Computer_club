using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.Update;

public class UpdateProviderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdateProviderRequest, Provider>();

        config.ForType<Provider, UpdateProviderResponse>();
    }
}