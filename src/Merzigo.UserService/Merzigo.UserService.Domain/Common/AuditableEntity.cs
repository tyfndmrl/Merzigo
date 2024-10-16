namespace Merzigo.UserService.Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }

    public abstract class AuditableEntity<TKey> : Entity<TKey>
        where TKey : notnull
    {
        public Guid? CreatorId { get; set; }
        public DateTimeOffset Created { get; set; }
        public Guid? LastModifierId { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}
