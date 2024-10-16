using Merzigo.ContentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merzigo.ContentService.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Content> Contents { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
