using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services.ClubServices.ScheduleService;

public class ScheduleService : IScheduleService<Schedule>
{
    private readonly AppDbContext _context;

    public ScheduleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Schedule?> GetTheScheduleOfASpecificDayAsync(string day, int gameClubId)
    {
        return await _context.Schedules
            .Where(x => x.Day == day && x.GameClubId == gameClubId)
            .FirstOrDefaultAsync();
    }
}