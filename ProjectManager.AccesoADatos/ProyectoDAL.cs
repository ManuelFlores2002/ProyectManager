using Microsoft.EntityFrameworkCore;
using ProjectManager.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos
{
    public class ProyectoDAL
    {
        public static async Task<int> CrearAsync(Proyecto pProyecto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pProyecto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Proyecto pProyecto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var proyecto = await bdContexto.Proyecto.FirstOrDefaultAsync(s => s.Id == pProyecto.Id);
                proyecto.IdAdministrador = pProyecto.IdAdministrador;
                proyecto.Nombre = pProyecto.Nombre;
                proyecto.Descripcion = pProyecto.Descripcion;
                proyecto.Estado = pProyecto.Estado;
               
                bdContexto.Update(proyecto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Proyecto pProyecto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var proyecto = await bdContexto.Proyecto.FirstOrDefaultAsync(s => s.Id == pProyecto.Id);
                bdContexto.Proyecto.Remove(proyecto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Proyecto> ObtenerPorIdAsync(Proyecto pProyecto)
        {
            var proyecto = new Proyecto();
            using (var bdContexto = new BDContexto())
            {
                proyecto = await bdContexto.Proyecto.FirstOrDefaultAsync(s => s.Id == pProyecto.Id);
            }
            return proyecto;
        }
        public static async Task<List<Proyecto>> ObtenerTodosAsync()
        {
            var proyectos = new List<Proyecto>();
            using (var bdContexto = new BDContexto())
            {
                proyectos = await bdContexto.Proyecto.ToListAsync();
            }
            return proyectos;
        }
        internal static IQueryable<Proyecto> QuerySelect(IQueryable<Proyecto> pQuery, Proyecto pProyecto)
        {
            if (pProyecto.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pProyecto.Id);

            if (pProyecto.IdAdministrador > 0)
                pQuery = pQuery.Where(s => s.IdAdministrador == pProyecto.IdAdministrador);

            if (!string.IsNullOrWhiteSpace(pProyecto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProyecto.Nombre));

            if (!string.IsNullOrWhiteSpace(pProyecto.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pProyecto.Descripcion));

            if (pProyecto.Estado > 0)
                pQuery = pQuery.Where(s => s.Estado == pProyecto.Estado);

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pProyecto.Top_Aux > 0)
                pQuery = pQuery.Take(pProyecto.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Proyecto>> BuscarAsync(Proyecto pProyecto)
        {
            var proyectos = new List<Proyecto>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Proyecto.AsQueryable();
                select = QuerySelect(select, pProyecto);
                proyectos = await select.ToListAsync();
            }
            return proyectos;
        }
        
        public static async Task<List<Proyecto>> BuscarIncluirUsuariosAsync(Proyecto pProyecto)
        {
            var proyectos = new List<Proyecto>();
            using(var bdContexto = new BDContexto())
            {
                var select = bdContexto.Proyecto.AsQueryable();
                select = QuerySelect(select, pProyecto).Include(s => s.Usuario).AsQueryable();
                proyectos = await select.ToListAsync();
            }
            return proyectos;
        }
    }
}
