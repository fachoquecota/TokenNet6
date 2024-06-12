using TokenNet6.Models;

namespace TokenNet6.Interfaces
{
    public interface ITokenNet
    {
        DBBoolResult LoginValidation(LoginModel loginModel);
    }
}
