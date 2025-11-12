using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Services;

namespace MISA.Fresher2025.API.Controllers
{
    public class CustomerController: MISABaseController<Customer>
    {
        //[HttpGet]
        //public new IActionResult Get() // Báo warning vì lớp cha đã tồn tại muốn ghi đè ở lớp con thì dùng new nhưng theo cách ép buộc, bạo l
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //public override IActionResult Get() // Sử dụng khi được cho phép bởi cha do từ khóa virtual
        //{
        //    return Ok();
        //}

        public CustomerController(ICustomerService cusRepo): base(cusRepo)
        {
        }
    }
}
