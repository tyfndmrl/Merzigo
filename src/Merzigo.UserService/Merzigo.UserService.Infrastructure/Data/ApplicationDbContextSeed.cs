namespace Merzigo.UserService.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public async Task SeedAsync(ApplicationDbContext context)
        {
            await context.SaveChangesAsync();
        }
    }
}
