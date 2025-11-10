using Dapper;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Api.Model;
using MySqlConnector;

namespace MISA.Fresher2025.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCustomer()
        {
            // Khai báo thông tin database
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

            // Khởi tạo kết nối
            var connection = new MySqlConnection(connectionString);

            // Khai báo lệnh truy vấn
            var sqlCommand = "SELECT * FROM Customer";

            // Thực hiện lệch
            var data = connection.Query<Customer>(sqlCommand);

            return Ok(data);
        }

        [HttpPost("method_1")]
        public IActionResult CreateCustomer1(Customer customer)
        {
            // Khai báo thông tin database
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

            // Khởi tạo kết nối 
            var connection = new MySqlConnection(connectionString);

            // Khai báo lệnh truy vấn
            var sqlCommand = @"INSERT INTO customer (customer_id, customer_code, customer_name, customer_addr)
                               VALUES (@customerId, @customerCode, @customerName, @customerAddr)";

            // Thực hiện lệch
            var data = connection.Execute(sqlCommand, param: customer);

            return Ok(data);
        }

        [HttpPost("method_2")]
        public IActionResult CreateCustomer2(Customer customer)
        {
            // Khai báo thông tin database
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

            // Khởi tạo kết nối
            var connection = new MySqlConnection(connectionString);

            // Khai báo lệnh truy vấn
            var sqlCommand = @"INSERT INTO customer (customer_id, customer_code, customer_name, customer_addr)
                               VALUES (@customerId, @customerCode, @customerName, @customerAddr)";

            var parameters = new DynamicParameters();
            parameters.Add("@customerId", customer.customerId);
            parameters.Add("@customerCode", customer.customerCode);
            parameters.Add("@customerName", customer.customerName);
            parameters.Add("@customerAddr", customer.customerAddr);


            // Thực hiện lệch
            var data = connection.Execute(sqlCommand, param: parameters);

            return Ok(data);
        }

        [HttpPost("method_3")]
        public IActionResult CreateCustomer3(Customer customer)
        {
            // Khai báo thông tin database
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

            // Khởi tạo kết nối
            var connection = new MySqlConnection(connectionString);

            var properties = typeof(Customer).GetProperties();
            var tableName = typeof(Customer).Name.ToLower();
            var columns = "";
            var columnParam = "";
            var parameters = new DynamicParameters();

            foreach (var property in properties)
            {
                columns += $"{property.Name},";
                columnParam += $"@{property.Name},";
                parameters.Add($"@{property.Name}", property.GetValue(customer));
            }

            columns = columns.TrimEnd(',');
            columnParam = columnParam.TrimEnd(',');


            // Khai báo lệnh truy vấn
            var sqlCommand = @$"INSERT INTO {tableName} (customer_id, customer_code, customer_name, customer_addr) VALUES ({columnParam})";

            // Thực hiện lệch
            var data = connection.Execute(sqlCommand, param: parameters);

            return Ok(data);
        }

    }
}
