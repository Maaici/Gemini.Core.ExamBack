using Gemini.IServices;
using Gemini.ViewModels.paging;
using Microsoft.AspNetCore.Mvc;

namespace Gemini.Web.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetRolesWithPage(PageRequest ret)
        {
            var ss = _roleService.GetRolesWithPage(ret);
            return Json(ret);
        }
    }
}