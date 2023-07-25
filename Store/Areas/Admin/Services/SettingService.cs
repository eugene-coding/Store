using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Data.Models;

namespace Store.Areas.Admin.Services;

public class SettingService : ISettingService
{
    private readonly ApplicationDbContext _context;

    public SettingService(ApplicationDbContext context)
    {
        _context = context;
    }

    private DbSet<Setting> Settings => _context.Settings;

    public async Task<int?> GetLanguageId()
    {
        var result = await Settings
            .Where(s => s.Key == SettingKeys.Language)
            .Select(language => language.Value)
            .SingleOrDefaultAsync();

        return int.TryParse(result, out var id) ? id : null;
    }

    public async Task SetLanguageId(int id)
    {
        var setting = await Settings.SingleOrDefaultAsync(s => s.Key == SettingKeys.Language);

        if (setting is not null)
        {
            setting.Value = id.ToString();
        }
        else
        {
            setting = new Setting(SettingKeys.Language, id);

            Settings.Add(setting);
        }

        await _context.SaveChangesAsync();
    }
}
