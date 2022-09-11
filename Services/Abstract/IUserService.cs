﻿using DataAccess.Entites;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUserService : IBaseService<UserDTO,User,UserDTO>
    {
        public UserDTO SignIn(UserDTO userdto);
    }
}
