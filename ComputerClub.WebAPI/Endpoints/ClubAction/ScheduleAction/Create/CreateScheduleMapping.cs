using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateScheduleRequest, Schedule>();

        config.ForType<Schedule, CreateScheduleResponse>();
    }
}