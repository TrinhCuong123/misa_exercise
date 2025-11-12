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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config) : base(config)
        {
        }

        public bool checkDuplicate(Customer customer)
        {
            var sqlCheck = $"SELECT COUNT(*) FROM Customer WHERE CustomerCode = @CustomerCode";
            var count = dbConnection.Query(sqlCheck, new { customer.CustomerCode });
            return Convert.ToInt32(count) > 0;
        }
    }
}
