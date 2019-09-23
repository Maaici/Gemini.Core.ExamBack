using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemini.IServices;
using Gemini.ToolBox;
using Gemini.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gemini.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">注册信息</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ret = _accountService.AddUser(model);
                return Json(ret);
            }
            else
            {
                return Json(AlertValifyError());
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="model">只用到里面的用户名和密码</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(RegisterViewModel model) {
            var ret = _accountService.Login(model.UserName, model.Password);
            if (ret.Success) {
                //状态保持
            }
            return Json(ret);
        }
    }
}