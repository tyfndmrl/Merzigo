using Merzigo.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merzigo.UserService.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
