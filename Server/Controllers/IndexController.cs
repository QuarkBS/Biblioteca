using Biblioteca.Client.Shared;
using Biblioteca.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {

        public BibliotecaDbContext _contexto;

        public IndexController(BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<IndexController>
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            return _contexto.Libros.Include(d => d.Biblioteca).ToList();
        }

        // GET api/<IndexController>/5
        [HttpGet("{id}")]
        public async Task<List<Libro>> Get(string id)
        {
            var queryable =_contexto.Libros.Include(b=>b.Biblioteca).AsQueryable();
            if (!string.IsNullOrEmpty(id))
            {
                queryable = queryable.Where(t => t.Titulo.Contains(id));
            }
            return await queryable.ToListAsync();
        }

        // POST api/<IndexController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IndexController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IndexController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
