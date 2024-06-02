using ComputerClub.DAL.Database;
using ComputerClub.DAL.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Services.ClubServices.ScheduleService;

public class ScheduleService : IScheduleService<Schedule>
{
    private readonly ApplicationDbContext _context;

    public ScheduleService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Schedule?> GetTheScheduleOfASpecificDayAsync(string day, int gameClubId)
    {
        return await _context.Schedule
            .Where(x => x.Day == day && x.GameClubId == gameClubId)
            .FirstOrDefaultAsync();
    }
}