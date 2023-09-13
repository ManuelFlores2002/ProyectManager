using Microsoft.EntityFrameworkCore;
using ProjectManager.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos
{
    public class ColaboradorDAL
    {
        public static async Task<int> CrearAsync(Colaborador pColaborador)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pColaborador);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Colaborador pColaborador)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var colaborador = await bdContexto.Colaborador.FirstOrDefaultAsync(s => s.Id == pColaborador.Id);
                colaborador.IdProyecto = pColaborador.IdProyecto;
                colaborador.IdUsuario = pColaborador.IdUsuario;
                colaborador.Estado = pColaborador.Estado;

                bdContexto.Update(colaborador);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Colaborador pColaborador)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var colaborador = await bdContexto.Colaborador.FirstOrDefaultAsync(s => s.Id == pColaborador.Id);
                bdContexto.Colaborador.Remove(colaborador);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Colaborador> ObtenerPorIdAsync(Colaborador pColaborador)
        {
            var colaborador = new Colaborador();
            using (var bdContexto = new BDContexto())
            {
                colaborador = await bdContexto.Colaborador.FirstOrDefaultAsync(s => s.Id == pColaborador.Id);
            }
            return colaborador;
        }
        public static async Task<List<Colaborador>> ObtenerTodosAsync()
        {
            var colaborador = new List<Colaborador>();
            using (var bdContexto = new BDContexto())
            {
                colaborador = await bdContexto.Colaborador.ToListAsync();
            }
            return colaborador;
        }
        internal static IQueryable<Colaborador> QuerySelect(IQueryable<Colaborador> pQuery, Colaborador pColaborador)
        {
            if (pColaborador.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pColaborador.Id);

            if (pColaborador.IdProyecto > 0)
                pQuery = pQuery.Where(s => s.IdProyecto == pColaborador.IdProyecto);

            if (pColaborador.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pColaborador.IdUsuario);

            if (pColaborador.Estado > 0)
                pQuery = pQuery.Where(s => s.Estado == pColaborador.Estado);

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pColaborador.Top_Aux > 0)
                pQuery = pQuery.Take(pColaborador.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Colaborador>> BuscarAsync(Colaborador pColaborador)
        {
            var colaboradores = new List<Colaborador>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Colaborador.AsQueryable();
                select = QuerySelect(select, pColaborador);
                colaboradores = await select.ToListAsync();
            }
            return colaboradores;
        }
        public static async Task<List<Colaborador>> BuscarIncluirRelacionesAsync(Colaborador pColaborador)
        {
            var colaboradores = new List<Colaborador>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Colaborador.AsQueryable();
                select = QuerySelect(select, pColaborador).Include(s => s.Proyecto).Include(s => s.Usuario).AsQueryable();
                colaboradores = await select.ToListAsync();
            }
            return colaboradores;
        }
    }
}