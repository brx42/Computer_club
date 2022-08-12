using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.HistoryEquipmentService;

public class HistoryEquipService : IHistoryEquipService<HistoryEquip>
{
    private readonly AppDbContext _context;

    public HistoryEquipService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<HistoryEquip>?> GetAllAsync(CancellationToken token)
    {
        return await _context.HistoryEquips.ToListAsync(token);
    }

    public async Task<List<HistoryEquip>?> GetAllForThePeriodAsync(int pageNumber, int pageSize, DateTime start,
        DateTime end)
    {
        return await _context.HistoryEquips
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Where(hi => hi.DateOfWork.Date >= start.Date && hi.DateOfWork.Date <= end.Date)
            .ToListAsync();
    }

    public async Task<int?> GetSumExpensesAsync(DateTime start, DateTime end)
    {
        return await _context.HistoryEquips
            .Where(hi => hi.DateOfWork.Date >= start.Date && hi.DateOfWork.Date <= end.Date)
            .SumAsync(s => s.PriceOfWork);
    }

public async Task<HistoryEquip?> GetByIdAsync(int id)
    {
        return await _context.HistoryEquips.FindAsync(id);
    }

    public async Task<HistoryEquip> AddAsync(HistoryEquip equip, CancellationToken token)
    {
        await _context.HistoryEquips.AddAsync(equip, token);
        await _context.SaveChangesAsync(token);
        return equip;
    }

    public async Task UpdateAsync(HistoryEquip equip, CancellationToken token)
    {
        _context.HistoryEquips.Update(equip);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(HistoryEquip equip, CancellationToken token)
    {
        _context.HistoryEquips.Remove(equip);
        await _context.SaveChangesAsync(token);
    }
}