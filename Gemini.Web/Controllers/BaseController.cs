using System;
using Gemini.Models;
using Gemini.ToolBox;
using Gemini.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gemini.Web.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (CurrentController != "Account" && CurrentUser() == null) {
                RedirectToAction("Login", "Account");
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

        public Sys_User CurrentUser() {
            var id = CurrentUserId();
            if (id == 0) {
                return null;
            }
            else
            {
                var currentUser = Redis.RedisHelper.Default.Get<Sys_User>(id.ToString());
                if (currentUser != null)
                {
                    return currentUser;
                }
                else {
                    return null;
                }
            }
        }

        public int CurrentUserId()
        {
            int id;
            var userId = HttpContext.Request.Cookies["AccessKey"];
            var idStr = Common.DecryptMOAMutipParameter(userId);
            if (int.TryParse(idStr[0], out id))
            {
                return id;
            }
            else {
                return 0;
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

            return Json(new CommonResponse{ Success = false, RetMsg = errors });
        }
    }
}