using Biblioteca.Client.Shared;
using Biblioteca.Server.Data;
using Biblioteca.Shared;
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
    public class LibrosController : ControllerBase
    {
        public BibliotecaDbContext _contexto;

        public LibrosController(BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<AgregarController>
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            return _contexto.Libros.Include(d => d.Biblioteca).ToList();
        }

        // GET api/<AgregarController>/5
        [HttpGet("{id}")]
        public async Task<Libro> Get(int id)
        {
            return await _contexto.Libros.Where(r=>r.Id == id).FirstOrDefaultAsync();
        }

        // POST api/<AgregarController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Libro libro)
        {
            _contexto.Add(libro);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        // PUT api/<AgregarController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Libro libro)
        {
            _contexto.Entry(libro).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<AgregarController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Libro elLibro = new Libro() { Id = id };
            _contexto.Libros.Remove(elLibro);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
