using ComputerClub.DAL.Database;
using ComputerClub.DAL.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Services.ClubServices.HistoryEquipmentService;

public class HistoryEquipService : IHistoryEquipService<HistoryEquip>
{
    private readonly ApplicationDbContext _context;

    public HistoryEquipService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<HistoryEquip>?> GetAllForThePeriodAsync(int pageNumber, int pageSize, DateTime start,
        DateTime end)
    {
        return await _context.HistoryEquip
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Where(hi => hi.DateOfWork.Date >= start.Date && hi.DateOfWork.Date <= end.Date)
            .ToListAsync();
    }

    public async Task<int?> GetSumExpensesAsync(DateTime start, DateTime end)
    {
        return await _context.HistoryEquip
            .Where(hi => hi.DateOfWork.Date >= start.Date && hi.DateOfWork.Date <= end.Date)
            .SumAsync(s => s.PriceOfWork);
    }
}