using Merzigo.ContentService.Application.Common.Interfaces;
using Merzigo.ContentService.Domain.Common.Auditing.Interfaces;
using Merzigo.ContentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace Merzigo.ContentService.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFilters(modelBuilder, entityType);
            }

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureGlobalFilters(ModelBuilder modelBuilder, IMutableEntityType mutableEntityType)
        {
            if (mutableEntityType.BaseType != null || !ShouldFilterEntity(mutableEntityType))
            {
                return;
            }

            var filterExpression = CreateFilterExpression(mutableEntityType.ClrType);

            if (filterExpression != null)
            {
                modelBuilder.Entity(mutableEntityType.ClrType).HasQueryFilter(filterExpression);
            }
        }

        private bool ShouldFilterEntity(IMutableEntityType entityType)
        {
            return typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType);
        }

        private LambdaExpression? CreateFilterExpression(Type entityType)
        {
            LambdaExpression? expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(entityType))
            {
                var parameter = Expression.Parameter(entityType, "e");
                var property = Expression.Property(parameter, "IsDeleted");
                var condition = Expression.Equal(property, Expression.Constant(false));
                expression = Expression.Lambda(condition, parameter);
            }

            return expression;
        }
    }
}
