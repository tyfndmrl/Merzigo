using Merzigo.ContentService.Infrastructure.Data;

namespace Merzigo.ContentService.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }
}
