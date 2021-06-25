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
    public class EstudiantesController : ControllerBase
    {
        public BibliotecaDbContext _contexto;

        public EstudiantesController(BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<EstudiantesController>
        [HttpGet]
        public IEnumerable<Estudiante> Get()
        {
            return _contexto.Estudiantes.ToList();
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public async Task<Estudiante> Get(int id)
        {
            return await _contexto.Estudiantes.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Estudiante estudiante)
        {
            _contexto.Add(estudiante);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put ([FromBody] Estudiante estudiante)
        {
            _contexto.Entry(estudiante).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Estudiante elEstudiante = new Estudiante() { Id = id };
            _contexto.Estudiantes.Remove(elEstudiante);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
