using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Services;
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
        IBaseService<T> _service;

        protected MISABaseController(IBaseService<T> repository)
        {
            _service = repository;
        }

        /// <summary>
        /// Function get list customer
        /// created by tncuong 6.11.2025
        /// </summary>
        // [HttpGet]
        // //public virtual IActionResult Get() // Cha cho phép con ghi đè
        // public IActionResult Get()

        // {
        //     var data = _service.Get();
        //     return Ok(data);
        // }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.Get();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var data = _service.Insert(entity);
            return Ok(data);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] T entity)
        {
            var data = _service.Update(entity);
            return Ok(data);

        }

    }
}
