using Gemini.Models;
using Gemini.ViewModels.paging;
using System.Collections.Generic;

namespace Gemini.IServices
{
    public interface IUserService
    {
        PageResponse GetUserWithPage(PageRequest request);
        Sys_User GetCurrentUser();
    }
}
