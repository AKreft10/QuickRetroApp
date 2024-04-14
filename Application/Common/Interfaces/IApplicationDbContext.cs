using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<RetroBoard> RetroBoards { get; set; }
    public DbSet<RetroBoardColumn> RetroBoardColumns { get; set; }
    public DbSet<RetroBoardColumnItem> RetroBoardColumnItems { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}