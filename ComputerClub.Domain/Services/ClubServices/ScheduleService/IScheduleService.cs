using ComputerClub.DAL.Models.ClubModels;

namespace ComputerClub.Domain.Services.ClubServices.ScheduleService;

public interface IScheduleService<T>
{
    Task<Schedule?> GetTheScheduleOfASpecificDayAsync(string day, int gameClubId);
}