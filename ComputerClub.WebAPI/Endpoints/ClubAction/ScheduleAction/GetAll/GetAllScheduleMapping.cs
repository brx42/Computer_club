using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetAll;

public class GetAllScheduleMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Schedule, GetAllScheduleResponse>();
    }
}