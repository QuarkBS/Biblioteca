using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Client.Shared
{
    public class Libro
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Clasificacion { get; set; }
        public string ISBN { get; set; }
        public int Edicion { get; set; }
        public int Volumen { get; set; }
        public int NoEjemplar { get; set; }
        public int BibliotecaId { get; set; }
        public Bibliotecas Biblioteca { get; set; }
        public string Campus { get; set; }
    }
}
