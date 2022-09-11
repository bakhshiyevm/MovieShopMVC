using AutoMapper;
using DataAccess;
using DataAccess.Entites;
using DTO;
using Helper;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
        public UserService(IMapper mapper, DataContext dataContext) : base(mapper, dataContext)
        {
        }

        public override UserDTO Create(UserDTO dto, int userId)
        {
            var ent = _dbSet.Where(u => u.Email.ToLower() == dto.Email.ToLower());

            if (ent.Any()) 
            {
                throw new Exception("User with same email exists!");
            }

            dto.Salt = Crypto.GenerateSalt();

            dto.PasswordHash = Crypto.GenerateSHA256Hash(dto.Password, dto.Salt);

            return base.Create(dto, userId);
        }

        public UserDTO SignIn(UserDTO dto)
        {
            var ent = _dbSet.Where(u => u.Email.ToLower() == dto.Email.ToLower());

            if (ent.Any()) 
            {
                var user = ent.First();
                var hash = Crypto.GenerateSHA256Hash(dto.Password, user.Salt);

                if(hash == user.PasswordHash) 
                {
                    var res = _mapper.Map<UserDTO>(user);
                    return res;
                }
                else
                {
                    throw new Exception("Incorrect password!");
                }
            }
            else
            {
                throw new Exception("User not found!");
            }
        }


    }
}
