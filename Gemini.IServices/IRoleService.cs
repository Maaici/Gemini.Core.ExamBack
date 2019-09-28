using Gemini.ViewModels.paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.IServices
{
    public interface IRoleService
    {
        PageResponse GetRolesWithPage(PageRequest req);
    }
}
