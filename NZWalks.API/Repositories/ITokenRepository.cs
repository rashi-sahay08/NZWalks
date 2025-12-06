using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string createJWTToken(IdentityUser user, List<string> roles);
    }
}
