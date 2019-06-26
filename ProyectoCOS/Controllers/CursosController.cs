using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoCOS.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        // GET: api/Cursos
        [HttpGet(Name = "GetCursos")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cursos/5
        [HttpGet("{id}", Name = "GetCursoPorID")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cursos
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cursos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
