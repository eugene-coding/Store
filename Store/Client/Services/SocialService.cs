using Store.Client.Data;

namespace Store.Client.Services;

public class SocialService : ISocialService
{
    public IReadOnlyCollection<Social> Get()
    {
        return MockDatabase.Socials;
    }
}
