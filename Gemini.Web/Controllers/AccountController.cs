using System;
using System.Collections.Generic;
using System.IO;
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

        #region 富文本编辑器用来导入word的操作,完成后将这个模块单独封装成viewComponent

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WordUpload()
        {
            var files = Request.Form.Files;
            if (files.Count == 0)
            {
                return Json(new CommonResponse { Success = false, RetMsg = "请选择文件！" });
            }
            else if (files.Count > 1)
            {
                return Json(new CommonResponse { Success = false, RetMsg = "请每次上传一个文件！" });
            }
            else
            {
                //判断是否为word格式
                string extName = Path.GetExtension(files[0].FileName);
                if (extName.ToUpper() == "DOC" || extName.ToUpper() == "DOCX")
                {

                }
                else
                {
                    return Json(new CommonResponse { Success = false, RetMsg = "请上传word文档！" });
                }
                //文件操作
                return Json(new CommonResponse { Success = true, RetMsg = "上传成功！" });
            }
        }

        #endregion

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
                return AlertValifyError();
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="model">只用到里面的用户名和密码</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(RegisterViewModel model)
        {
            var ret = _accountService.Login(model.UserName, model.Password);
            if (ret.Success)
            {
                //状态保持
                string useId = Common.EncryptMOAMutipParameter(ret.Data.Id, null);
                HttpContext.Response.Cookies.Append("AccessKey", useId, new CookieOptions { Expires = DateTime.Now.AddMinutes(10) });
            }
            return Json(ret);
        }
    }
}