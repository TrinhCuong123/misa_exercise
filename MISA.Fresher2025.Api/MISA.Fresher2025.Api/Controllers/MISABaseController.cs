using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Api.Model;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using static Dapper.SqlMapper;

namespace MISA.Fresher2025.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MISABaseController<T> : ControllerBase where T : class
    {
        /// <summary>
        /// hàm lấy id
        /// created by tncuong 20.10.2025
        /// </summary>
        
        [HttpGet]
        public IActionResult Get()
        {
            // Khai báo thông tin database
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

            // Khởi tạo kết nối
            var connection = new MySqlConnection(connectionString);

            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr?.Name ?? typeof(T).Name.ToLower();
            //var tableName = typeof(T).Name.ToLower();
            var sqlCommand = @$"SELECT * FROM {tableName}";
            var data = connection.Query<T>(sqlCommand);
            return Ok(data);
        }

        // [HttpPost("datatable")]
        // public IActionResult Datatable(BaseParamDatatable param)
        // {
        //     // Khai báo thông tin database
        //     var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

        //     // Khởi tạo kết nối
        //     var connection = new MySqlConnection(connectionString);

        //     var properties = typeof(T).GetProperties();
        //     //var tableName = typeof(T).Name.ToLower();
        //     var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
        //     var tableName = tableAttr?.Name ?? typeof(T).Name.ToLower();
        //     var columns = "";
        //     var columnParam = "";
        //     var parameters = new DynamicParameters();

        //     foreach (var property in properties)
        //     {
        //         //columns += $"{property.Name},";
        //         var columnAttr = property.GetCustomAttribute<ColumnAttribute>();
        //         var columnName = columnAttr?.Name ?? property.Name; // Nếu không có thì lấy property.Name
        //         columns += $"{columnName},";
        //         //columns += $"{property.Name},";
        //         columnParam += $"@{property.Name},";
        //         parameters.Add($"@{property.Name}", property.GetValue(param.search));
        //     }

        //     columns = columns.TrimEnd(',');
        //     columnParam = columnParam.TrimEnd(',');


        //     // Khai báo lệnh truy vấn
        //     var sqlCommand = @$"INSERT INTO {tableName} ({columns}) VALUES ({columnParam})";

        //     // Thực hiện lệch
        //     var res = connection.Execute(sqlCommand, param: parameters);

        //     return Ok(param);
        // }

        [HttpPost]
        public IActionResult Create(T entity)
        {
            // Khai báo thông tin database
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

            // Khởi tạo kết nối
            var connection = new MySqlConnection(connectionString);

            var properties = typeof(T).GetProperties();
            //var tableName = typeof(T).Name.ToLower();
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr?.Name ?? typeof(T).Name.ToLower();
            var columns = "";
            var columnParam = "";
            var parameters = new DynamicParameters();

            foreach (var property in properties)
            {
                //columns += $"{property.Name},";
                var columnAttr = property.GetCustomAttribute<ColumnAttribute>();
                var columnName = columnAttr?.Name ?? property.Name; // Nếu không có thì lấy property.Name
                columns += $"{columnName},";
                //columns += $"{property.Name},";
                columnParam += $"@{property.Name},";
                parameters.Add($"@{property.Name}", property.GetValue(entity));
            }

            columns = columns.TrimEnd(',');
            columnParam = columnParam.TrimEnd(',');


            // Khai báo lệnh truy vấn
            var sqlCommand = @$"INSERT INTO {tableName} ({columns}) VALUES ({columnParam})";

            // Thực hiện lệch
            var res = connection.Execute(sqlCommand, param: parameters);

            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Updatex(T entity, string id)
        {
            // Chuỗi kết nối tới MySQL
            var connectionString = "Server=localhost;Port=3306;Database=misa_sale_order;Uid=root;Pwd=123456;";

            using var connection = new MySqlConnection(connectionString);

            // Lấy tên bảng (ưu tiên attribute [Table], fallback = tên class)
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr?.Name ?? typeof(T).Name.ToLower();

            //  Lấy danh sách thuộc tính
            var properties = typeof(T).GetProperties();

            // Tìm khóa chính (có [Key])
            var keyProp = properties.FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);
            if (keyProp == null)
                return BadRequest("Không tìm thấy khóa chính ([Key]) trong entity.");

            // Lấy tên cột khóa chính
            var keyColumnAttr = keyProp.GetCustomAttribute<ColumnAttribute>();
            var keyColumnName = keyColumnAttr?.Name ?? keyProp.Name;

            // Xây dựng danh sách cột cần UPDATE (bỏ qua khóa chính)
            var setClauses = new List<string>();
            var parameters = new DynamicParameters();

            foreach (var prop in properties)
            {
                // Bỏ qua cột [Key]
                if (prop == keyProp) continue;

                // Lấy tên cột (nếu có [Column], dùng tên đó)
                var columnAttr = prop.GetCustomAttribute<ColumnAttribute>();
                var columnName = columnAttr?.Name ?? prop.Name;

                // Tạo cặp "column = @param"
                setClauses.Add($"{columnName} = @{prop.Name}");

                // Thêm tham số vào Dapper
                parameters.Add($"@{prop.Name}", prop.GetValue(entity));
            }

            // Ghép thành câu lệnh SQL hoàn chỉnh
            var setClauseSql = string.Join(", ", setClauses);
            var sql = $"UPDATE {tableName} SET {setClauseSql} WHERE {keyColumnName} = @id";

            // Thêm id vào parameters
            parameters.Add("@id", id);

            // Thực thi UPDATE
            var affectedRows = connection.Execute(sql, parameters);

            //  Trả về kết quả
            return Ok(affectedRows);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password= 123456;";

            // Khởi tạo kết nối
            var connection = new MySqlConnection(connectionString);

            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr?.Name ?? typeof(T).Name.ToLower();
            //var tableName = typeof(T).Name.ToLower();

            var properties = typeof(Customer).GetProperties();
            var keyProp = properties.FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);

            var columnAttr = keyProp?.GetCustomAttribute<ColumnAttribute>();
            var columnName = columnAttr?.Name;

            var sqlCommand = @$"DELETE FROM {tableName} WHERE {columnName} = @id";
            var data = connection.Execute(sqlCommand, new { id });
            return Ok(data);
        }
    }
}
