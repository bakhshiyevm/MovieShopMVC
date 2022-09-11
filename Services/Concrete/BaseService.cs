using AutoMapper;
using DataAccess;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public abstract class BaseService<TRqDTO, TEntity, TRsDTO> : IBaseService<TRqDTO, TEntity, TRsDTO>
        where TEntity : BaseEntity
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;
        public BaseService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;   
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<TEntity>();
        }

        public virtual TRsDTO Create(TRqDTO dto,int userId)
        {
            var ent = _mapper.Map<TEntity>(dto);

            ent.CreatedAt = DateTime.Now;
            ent.CreatedUser = userId;

            _dbSet.Add(ent);
            _dataContext.SaveChanges();

            var res = _mapper.Map<TRsDTO>(ent);
            return res;
        }

        public virtual int Delete(int id, int userId)
        {
            var ent = _dbSet.Find(id);
            _dbSet.Remove(ent);
            return ent.Id;            
        }

        public virtual IEnumerable<TRsDTO> Get()
        {
            var dtos = _mapper.Map<IEnumerable<TRsDTO>>(_dbSet);
            return dtos;
        }

        public virtual IEnumerable<TRsDTO> Get(int page, int pageSize)
        {
            var ents = _dbSet.Skip((page - 1) * pageSize).Take(pageSize);
            var dtos = _mapper.Map<IEnumerable<TRsDTO>>(ents);
            return dtos;
        }

        public virtual TRsDTO Get(int id)
        {
            var ent = _dbSet.Find(id);
            var dto = _mapper.Map<TRsDTO>(ent);
            return dto;
        }

        public virtual void Update(TRqDTO dto, int userId)
        {
            var ent = _mapper.Map<TEntity>(dto);

            ent.UpdatedAt = DateTime.Now;
            ent.UpdatedUser = userId;

            _dbSet.Update(ent);
            _dataContext.SaveChanges();

        }
    }
}
