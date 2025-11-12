using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Interfaces.Services
{
    public interface IEmployeeService: IBaseRepository<Employee>
    {
    }
}
