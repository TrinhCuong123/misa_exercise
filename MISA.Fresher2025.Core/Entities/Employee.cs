using MISA.Fresher2025.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Entities
{
    [MISATableName("employee")]
    public class Employee
    {
        public string EmployeeId { get; set; }
        [MISACheckDuplicate("Mã nhân viên không được trùng!")]
        [MISARequired("Vui lòng nhập mã nhân viên!")]
        [MISAColumName("emloyee_code")]
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
