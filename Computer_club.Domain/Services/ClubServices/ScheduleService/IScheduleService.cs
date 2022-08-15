using Computer_club.Data.Models.ClubModels;

namespace Computer_club.Domain.Services.ClubServices.ScheduleService;

public interface IScheduleService<T>
{
    Task<Schedule?> GetTheScheduleOfASpecificDayAsync(string day, int gameClubId);
}