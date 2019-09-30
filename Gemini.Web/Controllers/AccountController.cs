using System;
using System.IO;
using AutoMapper;
using Gemini.IServices;
using Gemini.Models;
using Gemini.ToolBox;
using Gemini.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gemini.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService,IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
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
                var user = ret.Data as Sys_User;
                var viewModel = _mapper.Map<UserRetViewModel>(user);
                //状态保持
                string token = Common.EncryptMOAMutipParameter(user.UserName, null);
                HttpContext.Response.Cookies.Append("AccessKey", token, new CookieOptions { Expires = DateTime.Now.AddMinutes(30) });
                HttpContext.Response.Cookies.Append("UserInfo", JsonConvert.SerializeObject(viewModel), new CookieOptions { Expires = DateTime.Now.AddMinutes(30) });
                HttpContext.Session.SetString(viewModel.UserName, (string)JsonConvert.SerializeObject(ret.Data));
            }
            return Json(ret);
        }
    }
}