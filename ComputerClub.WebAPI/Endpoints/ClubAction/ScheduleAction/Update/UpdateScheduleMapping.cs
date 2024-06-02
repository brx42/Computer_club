using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

public class UpdateScheduleMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Schedule, UpdateScheduleResponse>();
    }
}