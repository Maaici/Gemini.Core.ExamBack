using Gemini.ViewModels;

namespace Gemini.IServices
{
    public interface IAccountService
    {
        CommonResponse AddUser(RegisterViewModel model);

        CommonResponse Login(string userName, string pass);
    }
}
