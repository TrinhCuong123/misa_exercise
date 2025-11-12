using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repository;
using MISA.Fresher2025.Core.Interfaces.Services;

namespace MISA.Fresher2025.Core.Services
{
    public class CustomerService: BaseService<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerService) : base(customerService)
        {
        }
    }
}
