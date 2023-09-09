using Microsoft.EntityFrameworkCore;
using ProjectManager.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos
{
    public class BDContext : DbContext
    {
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {


            optionBuilder.UseSqlServer(@"Data Source=DESKTOP-CC30LNJ;Initial Catalog=ProjectManager;Integrated Security=True; Trust Server Certificate=true");

        }
    }
}

