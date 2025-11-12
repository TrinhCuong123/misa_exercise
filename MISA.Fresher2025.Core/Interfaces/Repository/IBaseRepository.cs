using MISA.Fresher2025.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        public List<T> Get();
        public T Insert(T entity);
        public T Delete(Guid entityId);
        public T Update(T entity);
    }
}
