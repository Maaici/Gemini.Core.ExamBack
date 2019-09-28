using System;
using Gemini.Models;
using Gemini.ToolBox;
using Gemini.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Gemini.Web.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (CurrentController != "Account" && CurrentUser == null)
            {
                context.Result = RedirectToAction("Login", "Account");
                return;
            }
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Current MVC Controller Name
        /// </summary>
        public string CurrentController
        {
            get
            {
                return ControllerContext.RouteData.Values["Controller"] as string;
            }
        }

        /// <summary>
        /// Current MVC Action Name
        /// </summary>
        public string CurrentAction
        {
            get
            {
                return ControllerContext.RouteData.Values["Action"] as string;
            }
        }

        /// <summary>
        /// Current MVC Area Name
        /// </summary>
        public string CurrentArea
        {
            get
            {
                string area = ControllerContext.RouteData.DataTokens["Area"] as string;
                return area ?? string.Empty;
            }
        }

        public Sys_User CurrentUser
        {
            get
            {
                var userId = HttpContext.Request.Cookies["AccessKey"];
                if (string.IsNullOrWhiteSpace(userId))
                {
                    return null;
                }
                var idStr = Common.DecryptMOAMutipParameter(userId);
                if (string.IsNullOrWhiteSpace(idStr?[0]))
                {
                    return null;
                }
                else
                {
                    var userStr = HttpContext.Session.GetString(idStr?[0]);
                    if (string.IsNullOrWhiteSpace(userStr))
                    {
                        return null;
                    }
                    var user = JsonConvert.DeserializeObject<Sys_User>(userStr);
                    return user;
                }
            }
        }

        public int CurrentUserId
        {
            get
            {
                if (CurrentUser == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentUser.Id;
                }
            }
        }

        /// <summary>
        /// 后台实体验证错误信息返回
        /// </summary>
        /// <returns></returns>
        public IActionResult AlertValifyError()
        {
            String errors = "";

            foreach (var value in ModelState.Values)
            {
                if (value.Errors.Count > 0)
                {
                    foreach (ModelError error in value.Errors)
                    {
                        if (!string.IsNullOrWhiteSpace(error.ErrorMessage))
                            errors += error.ErrorMessage;
                        else
                            errors += error.Exception.Message;
                    }
                }
            }

            return Json(new CommonResponse { Success = false, RetMsg = errors });
        }
    }
}