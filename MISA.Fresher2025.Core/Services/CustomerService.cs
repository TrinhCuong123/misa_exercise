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
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customersRepository;
        public CustomerService(ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public List<Customer> GetCustomers()
        {
            var data = _customersRepository.Get();
            return data;
        }

        public void Import(List<Customer> customerList)
        {
            throw new NotImplementedException();
        }

        public Customer Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
