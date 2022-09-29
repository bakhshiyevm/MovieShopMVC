using DataAccess.Entites;
using DTO;
using Services.Concrete;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;

namespace Services.Abstract
{
	public class RoleService : BaseService<RoleDTO, Role, RoleDTO>, IRoleService
	{
		public RoleService(IMapper mapper, DataContext dataContext) : base(mapper, dataContext)
		{

		}
	}
}
