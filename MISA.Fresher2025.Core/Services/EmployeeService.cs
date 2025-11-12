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
        public EmployeeService(IEmployeeRepository employerService): base(employerService)
        {
        }

    }
}
