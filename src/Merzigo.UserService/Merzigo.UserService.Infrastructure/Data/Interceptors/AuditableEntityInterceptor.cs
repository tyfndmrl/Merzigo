using Merzigo.UserService.Application.Common.Interfaces;
using Merzigo.UserService.Domain.Common;
using Merzigo.UserService.Domain.Common.Auditing.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Merzigo.UserService.Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        private readonly IUser _user;
        public AuditableEntityInterceptor(IUser user)
        {
            _user = user;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) { return; }

            var dateTimeUtc = DateTime.UtcNow;

            foreach (var entry in context.ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        SetCreationAuditProperties(entry, dateTimeUtc);

                        break;
                    case EntityState.Modified:
                        SetModificationAuditProperties(entry, dateTimeUtc);

                        break;
                    case EntityState.Deleted:
                        SetDeletionAuditProperties(entry, dateTimeUtc);

                        break;
                }
            }
        }

        private void SetCreationAuditProperties(EntityEntry entry, DateTime dateTime)
        {

            if (entry.Entity is AuditableEntity<Guid> creation)
            {
                creation.Created = dateTime;
                creation.CreatorId = _user.Id;
            }
        }

        private void SetModificationAuditProperties(EntityEntry entry, DateTime dateTime)
        {
            if (entry.Entity is AuditableEntity<object> modification)
            {
                modification.LastModified = dateTime;
                modification.LastModifierId = _user.Id;
            }
        }

        private void SetDeletionAuditProperties(EntityEntry entry, DateTime dateTime)
        {
            if (entry.Entity is ISoftDelete softDelete)
            {
                softDelete.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
