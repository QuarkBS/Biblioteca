using Biblioteca.Client.Shared;
using Biblioteca.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        public BibliotecaDbContext _contexto;

        public BibliotecaController(BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<BibliotecaController>
        [HttpGet]
        public IEnumerable<Bibliotecas> Get()
        {
            return _contexto.Bibliotecas.ToList(); 
        }

        // GET api/<BibliotecaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BibliotecaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BibliotecaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BibliotecaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
