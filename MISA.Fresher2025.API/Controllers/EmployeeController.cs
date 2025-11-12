using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repository;
using MISA.Fresher2025.Core.Interfaces.Services;

namespace MISA.Fresher2025.API.Controllers
{
    public class EmployeeController: MISABaseController<Employee>
    {
        public EmployeeController(IEmployeeService employ): base(employ)
        {
        }
    }
}
