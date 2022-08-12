﻿using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.PlaceService;

public class PlaceService : IPlaceService<Place>
{
    private readonly AppDbContext _context;

    public PlaceService(AppDbContext context)
    {
        _context = context;
    }
    

    public async Task<List<Place>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _context.Places
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllFreeSeatsAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _context.Places
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Where(x => x.IsFree == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllBusySeatsAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _context.Places
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Where(x => x.IsFree != true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllVipSeatsAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _context.Places
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Where(x => x.IsVip == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllSimpleSeatsAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _context.Places
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Where(x => x.IsVip != true)
            .ToListAsync(token);
    }

    public async Task<Place?> GetByIdAsync(int id)
    {
        return await _context.Places.FindAsync(id);
    }

    public async Task<Place> AddAsync(Place place, CancellationToken token)
    {
        await _context.Places.AddAsync(place, token);
        await _context.SaveChangesAsync(token);
        return place;
    }

    public async Task UpdateAsync(Place place, CancellationToken token)
    {
        _context.Places.Update(place);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Place place, CancellationToken token)
    {
        _context.Places.Remove(place);
        await _context.SaveChangesAsync(token);
    }
}