using System;
using System.Collections.Generic;
using System.Linq;
using Gemini.IRepositories;
using Gemini.IServices;
using Gemini.Models;
using Gemini.ViewModels;
using Gemini.ViewModels.paging;
using Microsoft.Extensions.Logging;

namespace Gemini.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork,ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public PageResponse GetUserWithPage(PageRequest request)
        {
            var ret = new PageResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(request.searchVal))
                {
                    var data = _unitOfWork.Repository<Sys_User>().GetAll()
                        .Skip((request.page - 1) * request.limit).Take(request.limit).ToList();
                    ret.data = data;
                    ret.count = _unitOfWork.Repository<Sys_User>().GetAll().Count();
                }
                else {
                    ret.data = _unitOfWork.Repository<Sys_User>()
                    .GetAll(x => x.UserName.Contains(request.searchVal) || x.RealName.Contains(request.searchVal) || x.Mobile.Contains(request.searchVal))
                    .Skip((request.page - 1) * request.limit).Take(request.limit).ToList();
                    ret.count = _unitOfWork.Repository<Sys_User>().GetAll().Count();
                }
                return ret;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取用户列表时出现异常");
                return new PageResponse { code=500,msg=ex.Message};
            }
        }

        public Sys_User GetCurrentUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
