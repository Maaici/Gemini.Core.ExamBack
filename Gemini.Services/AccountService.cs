using Gemini.IRepositories;
using Gemini.IServices;
using Gemini.Models;
using Gemini.ToolBox;
using Gemini.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Gemini.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IUnitOfWork unitOfWork,ILogger<AccountService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public CommonResponse AddUser(RegisterViewModel model)
        {
            try
            {
                //判断用户名是否已经存在
                var item = _unitOfWork.Repository<Sys_User>().GetAll(x => x.UserName == model.UserName).ToList();
                if (item.Any()) {
                    return new CommonResponse { Success = false, RetMsg = "用户名已经被注册！" };
                }

                Sys_User user = new Sys_User();
                user.UserName = model.UserName;
                user.Password = Common.ConvertToMD5(model.Password);
                user.Mobile = model.Mobile;
                user.RealName = model.RealName;

                user.CreateTime = DateTime.Now;
                //user.CreateUser = CurrentUser().UserName;

                _unitOfWork.Repository<Sys_User>().Add(user);
                _unitOfWork.SaveChanges();
                return new CommonResponse { Success = true, RetMsg = "注册成功！" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "添加用户时出现异常！");
                return new CommonResponse { Success = false, RetMsg = ex.Message };
            }
            
        }

        public CommonResponse Login(string userName, string pass)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass)) {
                return new CommonResponse { Success = false, RetMsg = "用户名和密码均不可以为空！" };
            }
            try
            {
                var user = _unitOfWork.Repository<Sys_User>().GetAll(x => x.UserName == userName).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == Common.ConvertToMD5(pass))
                    {
                        return new CommonResponse { Success = true, RetMsg = "登陆成功！" ,Data = user};
                    }
                    else
                    {
                        return new CommonResponse { Success = false, RetMsg = "密码错误！" };
                    }
                }
                else
                {
                    return new CommonResponse { Success = false, RetMsg = "用户名不存在！" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"用户:{userName} 登陆时报异常。");
                return new CommonResponse { Success = false, RetMsg = ex.Message };
            }
            
        }
    }
}
