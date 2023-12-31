﻿using Microsoft.EntityFrameworkCore;
using ProjectManager.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlServer(@"Data Source=DESKTOP-KT040TS;Initial Catalog=ProyectManager;Integrated Security=True; Trust Server Certificate=true");
            optionBuilder.UseSqlServer(@"Data Source=Servidor-01; Initial Catalog=ProyectManager; User Id=sa; Pwd=Admin2023#; encrypt = false; trustServerCertificate = true;");
        }
    }
}

