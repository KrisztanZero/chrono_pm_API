using Chrono_PM_API.Data;
using Chrono_PM_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Chrono_PM_API.Repositories;

public class AppDetailsRepository : IAppDetailsRepository
{
    private readonly AppDbContext _context;

    public AppDetailsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AppDetails>> GetAppDetailsListAsync()
    {
        return await _context.AppDetails.ToListAsync();
    }

    public async Task<AppDetails> GetAppDetailsByIdAsync(string id)
    {
        return await _context.AppDetails.FindAsync(id);
    }

    public async Task<AppDetails> CreateAppDetailsAsync(AppDetails appDetails)
    {
        await _context.AppDetails.AddAsync(appDetails);
        await _context.SaveChangesAsync();
        return appDetails;
    }

    public async Task<AppDetails> UpdateAppDetailsAsync(AppDetails appDetails)
    {
        _context.Entry(appDetails).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return appDetails;
    }

    public async Task<bool> DeleteAppDetailsAsync(string id)
    {
        var appDetails = await _context.AppDetails.FindAsync(id);
        if (appDetails == null) return false;

        _context.AppDetails.Remove(appDetails);
        await _context.SaveChangesAsync();
        return true;
    }
}