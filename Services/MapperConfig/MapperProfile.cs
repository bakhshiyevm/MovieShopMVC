using AutoMapper;
using DataAccess.Entites;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MapperConfig
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
