using AutoMapper;
using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserInsertDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
