using Microsoft.EntityFrameworkCore;

namespace Store.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new Database(
            serviceProvider.GetRequiredService<
                DbContextOptions<Database>>());

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        List<Social> socials = new()
        {
            new Social
            {
                Title = "Вконтакте",
                Url = new("https://vk.com/led.ice34"),
                Icon = "vk.svg",
                Enabled = true
            },

            new Social
            {
                Title="Телеграм",
                Url = new("https://t.me/ledice34"),
                Icon= "telegram.svg",
                Enabled = true
            },

            new Social
            {
                Title="Одноклассники",
                Url = new("https://ok.ru/group/63187876053175"),
                Icon= "ok.svg",
                Enabled = true
            },
            
            new Social
            {
                Title="YouTube",
                Url = new("https://www.youtube.com/channel/UCoGEyZyySQMHTIysvfFbPqQ"),
                Icon= "youtube.svg",
                Enabled = true
            },

            
        };

        List<Badge> badges = new()
        {
            new Badge
            {
                Title = "Доступно на Google Play",
                Url = new("https://play.google.com/store/apps/details?id=com.LedIce.LedIce&hl=ru&gl=US"),
                Image = "google-play.svg",
                Enabled = true
            }
        };

        context.AddRange(socials);
        context.AddRange(badges);

        context.SaveChanges();
    }
}
