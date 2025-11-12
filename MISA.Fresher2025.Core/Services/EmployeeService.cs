using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repository;
using MISA.Fresher2025.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Services
{
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employerRepository;
        public EmployeeService(IEmployeeRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public Employee Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee Insert(Employee entity)
        {
            var invaid = base.validateDate(entity);
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
