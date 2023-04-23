using TokenNet6.Models;

namespace TokenNet6.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(LoginModel admin);
    }
}
