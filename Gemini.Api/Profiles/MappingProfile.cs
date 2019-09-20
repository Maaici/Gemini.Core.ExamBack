using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemini.Api.Profiles
{
    /// <summary>
    /// AutoMapper配置类，用来配置映射关系
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MappingProfile()
        {
            //将你需要进行映射的类型写在这边
            //CreateMap<User, UserDto>();
            //CreateMap<UserDto, User>();
        }
    }
}
