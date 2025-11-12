using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repository;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MISA.Fresher2025.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MISABaseController<T> : ControllerBase where T : class
    {
        IBaseRepository<T> _repository;

        protected MISABaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        protected MySqlConnection ConnectionDB()
        {
            // Declare database information
            var connectionString = "Host=localhost; Port=3306; Database=misa_sale_order; User=root; Password=123456;";
            // Initiate connection
            return new MySqlConnection(connectionString);
        }
        /// <summary>
        /// Function get list customer
        /// created by tncuong 6.11.2025
        /// </summary>
        [HttpGet]
        //public virtual IActionResult Get() // Cha cho phép con ghi đè
        public IActionResult Get()

        {
            using var connection = ConnectionDB();
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr?.Name ?? typeof(T).Name.ToLower();
            var sqlCommand = @$"SELECT * FROM {tableName}";
            var data = connection.Query<T>(sqlCommand);
            return Ok(data);
        }

        /// <summary>
        /// Function paging data
        /// created by tncuong 10.11.2025
        /// </summary>
        //[HttpPost("datatable")]
        //public IActionResult Datatable([FromBody] BaseParamDatatable param, [FromQuery] string[] columnSearch)
        //{
        //    using var connection = ConnectionDB();

        //    // Get table name from attribute
        //    var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
        //    var tableName = tableAttr?.Name ?? typeof(T).Name.ToLower();

        //    // Build condition
        //    string condition = "1=1"; // Default is true

        //    // Search when have text
        //    if (!string.IsNullOrEmpty(param.search) && columnSearch.Length > 0)
        //    {
        //        var searchConditions = columnSearch
        //            .Select(c => $"{c} LIKE @searchText");
        //        condition += " AND (" + string.Join(" OR ", searchConditions) + ")";
        //    }

        //    // Paging
        //    var sqlCommand = @$"
        //        SELECT * FROM {tableName}
        //        WHERE {condition}
        //        LIMIT @length OFFSET @start;
        //    ";

        //    // Parameter
        //    var res = connection.Query<T>(sqlCommand, new
        //    {
        //        searchText = $"%{param.search}%",
        //        length = param.length,
        //        start = param.start
        //    });

        //    return Ok(res);
        //}

        /// <summary>
        /// Function create customer
        /// created by tncuong 6.11.2025
        /// </summary>
        [HttpPost]
        public IActionResult Create(T entity)
        {
            using var connection = ConnectionDB();
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

        /// <summary>
        /// Function update customer by ID
        /// created by tncuong 6.11.2025
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Updatex(T entity, string id)
        {
            using var connection = ConnectionDB();

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

        /// <summary>
        /// Function delete customer by ID
        /// created by tncuong 6.11.2025
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            using var connection = ConnectionDB();

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
