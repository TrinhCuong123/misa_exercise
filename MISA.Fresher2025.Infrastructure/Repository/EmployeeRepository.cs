using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration config) : base(config)
        {
        }

        public bool checkDuplicate(Employee employee)
        {
            var sqlCheck = $"SELECT COUNT(*) FROM Employee WHERE EmployeeCode = @EmployeeCode";
            var count = dbConnection.Query(sqlCheck, new { employee.EmployeeCode });
            return Convert.ToInt32(count) > 0;
        }
    }
}
