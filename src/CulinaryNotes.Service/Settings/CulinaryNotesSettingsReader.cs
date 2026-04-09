namespace CulinaryNotes.Settings;

public class CulinaryNotesSettingsReader
{
    public static CulinaryNotesSettings Read(IConfiguration configuration)
    {
        return new CulinaryNotesSettings()
        {
            CulinaryNotesDbConnectionString =
                configuration.GetConnectionString("CulinaryNotesDbContext")
        };
    }
}