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
        List<T> Get();
        T Insert(T entity);
        T Delete(Guid entityId);
        T Update(T entity);
    }
}
