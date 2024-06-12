using TokenNet6.Models;

namespace TokenNet6.Interfaces
{
    public interface ISprBusiness
    {
        List<DBBoolResult> LoginValidation(LoginModel loginModel);
    }
}
