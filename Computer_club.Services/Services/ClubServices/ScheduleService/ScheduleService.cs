using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.ScheduleService;

public class ScheduleService : IScheduleService<Schedule>
{
    private readonly AppDbContext _context;

    public ScheduleService(AppDbContext context)
    {
        _context = context;
    }
    

    public async Task<List<Schedule>> GetAllAsync(CancellationToken token)
    {
        return await _context.Schedules.ToListAsync(token);
    }

    public async Task<Schedule?> GetByIdAsync(int id)
    {
        return await _context.Schedules.FindAsync(id);
    }

    public async Task<Schedule> AddAsync(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();
        return schedule;
    }

    public async Task UpdateAsync(Schedule schedule, CancellationToken token)
    {
        _context.Schedules.Update(schedule);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Schedule schedule, CancellationToken token)
    {
        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync(token);
    }
}