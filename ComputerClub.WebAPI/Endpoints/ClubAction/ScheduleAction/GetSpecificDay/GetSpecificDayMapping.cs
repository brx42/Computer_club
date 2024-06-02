using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetSpecificDay;

public class GetSpecificDayMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Schedule, GetSpecificDayResponse>();
    }
}