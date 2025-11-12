using MISA.Fresher2025.Core.MISAAttribute;

namespace MISA.Fresher2025.Core.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        [MISARequired("Thông tin không được để trống!")]
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ModifiedBy { get; set; }
        public string? Mobile { get; set; }
    }
}
