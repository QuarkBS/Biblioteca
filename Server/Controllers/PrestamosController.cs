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
    public class PrestamosController : ControllerBase
    {
        public BibliotecaDbContext _contexto;

        public PrestamosController(BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<PrestamosController>
        [HttpGet]
        public IEnumerable<Prestamos> Get()
        {
            var nombre = _contexto.Prestamos.Include(d => d.Libro).ToList();

            return nombre;
        }

        // GET api/<PrestamosController>/5
        [HttpGet("{id}")]
        public async Task<Prestamos> Get(int id)
        {
            return await _contexto.Prestamos.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        // POST api/<PrestamosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Prestamos prestamo)
        {
            _contexto.Add(prestamo);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        // PUT api/<PrestamosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Prestamos prestamo)
        {
            _contexto.Entry(prestamo).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<PrestamosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Prestamos elPrestamo = new Prestamos() { Id = id };
            _contexto.Prestamos.Remove(elPrestamo);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
