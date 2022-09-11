using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBaseService<TRqDTO, TEntity,TRsDTO>
    {
        public IEnumerable<TRsDTO> Get();
        public IEnumerable<TRsDTO> Get(int page, int pageSize);
        public TRsDTO Get(int id);
        public TRsDTO Create(TRqDTO dto, int userId);
        public void Update(TRqDTO dto, int userId);
        public int Delete(int id, int userId);

    }
}
