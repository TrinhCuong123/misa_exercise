using MISA.Fresher2025.Core.Interfaces.Repository;
using MISA.Fresher2025.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Services
{
    public class BaseService<T>
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual List<T> Get()
        {
            return _repository.Get();
        }

        public virtual T Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        public virtual T Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public bool validateDate(T entity)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var requiredAttr = property.GetCustomAttributes(typeof(MISARequired), true);
                if (requiredAttr.Length > 0)
                {
                    var value = property.GetValue(entity);
                    if (value != null || (value is string str && string.IsNullOrEmpty(str)))
                    {
                        throw new Exception($"{property.Name} không được để trống");
                    }
                }
            }
            return true;
        }
    }
}
