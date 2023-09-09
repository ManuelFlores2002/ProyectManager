using Microsoft.EntityFrameworkCore;
using ProjectManager.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos
{
    public class TareaDAL
    {
        public static async Task<int> CrearAsync(Tarea pTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                bdContexto.Add(pTarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Tarea pTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var tarea = await bdContexto.Tarea.FirstOrDefaultAsync(s => s.Id == pTarea.Id);
                tarea.IdProyecto = pTarea.IdProyecto;
                tarea.IdColaborador = pTarea.IdColaborador;
                tarea.Nombre = pTarea.Nombre;
                tarea.Descripcion = pTarea.Descripcion;
                tarea.Prioridad = pTarea.Prioridad;
                tarea.Esfuerzo = pTarea.Esfuerzo;
                tarea.Estado = pTarea.Estado;

                bdContexto.Update(tarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Tarea pTarea)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var tarea = await bdContexto.Tarea.FirstOrDefaultAsync(s => s.Id == pTarea.Id);
                bdContexto.Tarea.Remove(tarea);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Tarea> ObtenerPorIdAsync(Tarea pTarea)
        {
            var tarea = new Tarea();
            using (var bdContexto = new BDContext())
            {
                tarea = await bdContexto.Tarea.FirstOrDefaultAsync(s => s.Id == pTarea.Id);
            }
            return tarea;
        }
        public static async Task<List<Tarea>> ObtenerTodosAsync()
        {
            var tarea = new List<Tarea>();
            using (var bdContexto = new BDContext())
            {
                tarea = await bdContexto.Tarea.ToListAsync();
            }
            return tarea;
        }
        internal static IQueryable<Tarea> QuerySelect(IQueryable<Tarea> pQuery, Tarea pTarea)
        {
            if (pTarea.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pTarea.Id);

            if (pTarea.IdProyecto > 0)
                pQuery = pQuery.Where(s => s.IdProyecto == pTarea.IdProyecto);

            if (pTarea.IdColaborador > 0)
                pQuery = pQuery.Where(s => s.IdColaborador == pTarea.IdColaborador);

            if (!string.IsNullOrWhiteSpace(pTarea.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pTarea.Nombre));

            if (!string.IsNullOrWhiteSpace(pTarea.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pTarea.Descripcion));

            if(pTarea.Prioridad > 0)
                pQuery = pQuery.Where(s => s.Prioridad == pTarea.Prioridad);

            if(pTarea.Esfuerzo > 0)
                pQuery = pQuery.Where(s => s.Esfuerzo == pTarea.Esfuerzo);

            if (pTarea.Estado > 0)
                pQuery = pQuery.Where(s => s.Estado == pTarea.Estado);

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pTarea.Top_Aux > 0)
                pQuery = pQuery.Take(pTarea.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Tarea>> BuscarAsync(Tarea pTarea)
        {
            var tareas = new List<Tarea>();
            using (var bdContexto = new BDContext())
            {
                var select = bdContexto.Tarea.AsQueryable();
                select = QuerySelect(select, pTarea);
                tareas = await select.ToListAsync();
            }
            return tareas;
        }

        public static async Task<List<Tarea>> BuscarIncluirRelacionesAsync(Tarea pTarea)
        {
            var tareas = new List<Tarea>();
            using (var bdContexto = new BDContext())
            {
                var select = bdContexto.Tarea.AsQueryable();
                select = QuerySelect(select, pTarea).Include(s => s.Proyecto).AsQueryable();
                select = QuerySelect(select, pTarea).Include(s => s.Colaborador).AsQueryable();
                tareas = await select.ToListAsync();
            }
            return tareas;
        }
    }
}

