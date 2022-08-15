using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services.ClubServices.HistoryEquipmentService;

public class HistoryEquipService : IHistoryEquipService<HistoryEquip>
{
    private readonly AppDbContext _context;

    public HistoryEquipService(AppDbContext context)
    {
        _context = context;
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
}