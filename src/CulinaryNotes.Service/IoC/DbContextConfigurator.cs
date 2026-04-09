using CulinaryNotes.DataAccess.Context;
using CulinaryNotes.Settings;
using Microsoft.EntityFrameworkCore;

namespace CulinaryNotes.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, CulinaryNotesSettings settings)
    {
        services.AddDbContextFactory<CulinaryNotesDbContext>(options =>
        {
            options.UseNpgsql(settings.CulinaryNotesDbConnectionString);
        }, ServiceLifetime.Scoped);

    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<CulinaryNotesDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}