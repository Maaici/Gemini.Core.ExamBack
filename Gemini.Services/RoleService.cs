using Gemini.IRepositories;
using Gemini.IServices;
using Gemini.Models;
using Gemini.ViewModels.paging;
using System.Linq;

namespace Gemini.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MyDbContext _dbContext;

        public RoleService(IUnitOfWork unitOfWork,MyDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }
        public PageResponse GetRolesWithPage(PageRequest req)
        {
            if (!string.IsNullOrWhiteSpace(req.searchVal)) {
                var ss = _unitOfWork.Repository<Sys_Role>().GetAll(x => req.searchVal.StartsWith(x.RoleName)).ToList();
            }
            return new PageResponse() ;
        }
    }
}
