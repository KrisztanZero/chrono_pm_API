﻿using Chrono_PM_API.Data;
using Chrono_PM_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Chrono_PM_API.Repositories;

public class IssueRepository : IIssueRepository
{
    private readonly AppDbContext _context;

    public IssueRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Issue>> GetIssuesAsync()
    {
        return await _context.Issues.ToListAsync();
    }

    public async Task<Issue> GetIssueByIdAsync(string id)
    {
        return await _context.Issues.FindAsync(id);;
    }

    public async Task<Issue> CreateIssueAsync(Issue issue)
    {
        _context.Issues.Add(issue);
        await _context.SaveChangesAsync();
        return issue;
    }

    public async Task<bool> DeleteIssueAsync(string id)
    {
        var issue = await _context.Issues.FindAsync(id);
        if (issue == null) return false;

        _context.Issues.Remove(issue);
        await _context.SaveChangesAsync();
        return true;
    }
}