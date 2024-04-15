using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
        
    }
    // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<RetroBoard> RetroBoards { get; set; }
    public DbSet<RetroBoardColumn> RetroBoardColumns { get; set; }
    public DbSet<RetroBoardColumnItem> RetroBoardColumnItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "Server=localhost;Database=QuickRetro;Trusted_Connection=True;TrustServerCertificate=true";


        optionsBuilder.UseSqlServer(connectionString);
    }
}