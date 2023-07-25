namespace Store.Areas.Admin.Services;

public interface ISettingService
{
    Task<int?> GetLanguageId();
    Task SetLanguageId(int id);
}
