using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Client.Shared
{
    public class Prestamos
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}
