using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetById;

public class GetByIdScheduleMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Schedule, GetByIdScheduleResponse>();
    }
}