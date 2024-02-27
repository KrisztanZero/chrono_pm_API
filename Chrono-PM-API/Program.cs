using Chrono_PM_API.Data;
using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;
using Chrono_PM_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder
        .Configuration
        .GetConnectionString("DefaultConnection")));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IIssueService, IssueService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.MapIdentityApi<AppUser>();

app.Run();