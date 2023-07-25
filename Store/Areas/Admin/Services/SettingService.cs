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
        var result = await GetValueAsync(SettingKeys.Language);

        return int.TryParse(result, out var id) ? id : null;
    }

    public async Task SetLanguageId(int id)
    {
        await SetValueAsync(SettingKeys.Language, id);
    }

    private async Task<string?> GetValueAsync(string key)
    {
        return await Settings
            .Where(s => s.Key == key)
            .Select(s => s.Value)
            .SingleOrDefaultAsync();
    }

    private async Task<Setting?> GetSettingAsync(string key)
    {
        return await Settings.SingleOrDefaultAsync(s => s.Key == key);
    }

    private async Task SetValueAsync(string key, object value)
    {
        var setting = await GetSettingAsync(key);
        var stringValue = value.ToString() ?? string.Empty;

        if (setting is not null)
        {
            setting.Value = stringValue;
        }
        else
        {
            setting = new Setting(key, stringValue);
            await Settings.AddAsync(setting);
        }

        await _context.SaveChangesAsync();
    }
}
