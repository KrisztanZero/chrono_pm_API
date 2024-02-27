﻿using Chrono_PM_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chrono_PM_API.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
        
    }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Comment> Comments { get; set; }
}