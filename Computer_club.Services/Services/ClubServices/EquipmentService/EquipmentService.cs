using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.EquipmentService;

public class EquipmentService : IEquipmentService<Equipment>
{
    private readonly AppDbContext _context;

    public EquipmentService(AppDbContext context)
    {
        _context = context;
    }

    
    public async Task<List<Equipment>> GetAllAsync(CancellationToken token)
    {
        return await _context.Equipments.ToListAsync(token);
    }

    public async Task<Equipment?> GetByIdAsync(int id)
    {
        return await _context.Equipments.FindAsync(id);
    }

    public async Task<Equipment> AddAsync(Equipment equipment, CancellationToken token)
    {
        await _context.Equipments.AddAsync(equipment, token);
        await _context.SaveChangesAsync(token);
        return equipment;
    }

    public async Task UpdateAsync(Equipment equipment, CancellationToken token)
    {
        _context.Equipments.Update(equipment);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Equipment equipment, CancellationToken token)
    {
        _context.Equipments.Remove(equipment);
        await _context.SaveChangesAsync(token);
    }
}