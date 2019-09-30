using AutoMapper;
using Gemini.IServices;
using Gemini.ViewModels;
using Gemini.ViewModels.paging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace Gemini.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            @ViewBag.Title = "用户管理";
            return View();
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetUserWithPage(PageRequest request) {
            var ret = _userService.GetUserWithPage(request);
            return JsonConvert.SerializeObject(ret);
        }
    }
}