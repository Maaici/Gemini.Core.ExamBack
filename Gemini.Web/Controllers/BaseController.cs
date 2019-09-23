using System;
using Gemini.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gemini.Web.Controllers
{
    public class BaseController : Controller
    {
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