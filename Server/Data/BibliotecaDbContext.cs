using Biblioteca.Client.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Server.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Bibliotecas> Bibliotecas { get; set; }

    }
}
