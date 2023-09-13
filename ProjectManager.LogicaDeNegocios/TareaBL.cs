using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.AccesoADatos;
using ProjectManager.EntidadesDeNegocio;

namespace ProjectManager.LogicaDeNegocios
{
    public class TareaBL
    {
        public async Task<int> CrearAsync(Tarea pTarea)
        {
            return await TareaDAL.CrearAsync(pTarea);
        }

        public async Task<int> ModificarAsync(Tarea pTarea)
        {
            return await TareaDAL.ModificarAsync(pTarea);
        }

        public async Task<int> EliminarAsync(Tarea pTarea)
        {
            return await TareaDAL.EliminarAsync(pTarea);
        }

        public async Task<Tarea> ObtenerPorIdAsync(Tarea pTarea)
        {
            return await TareaDAL.ObtenerPorIdAsync(pTarea);
        }

        public async Task<List<Tarea>> ObtenerTodosAsync()
        {
            return await TareaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Tarea>> BuscarAsync(Tarea pTarea)
        {
            return await TareaDAL.BuscarAsync(pTarea);
        }

        public async Task<List<Tarea>> BuscarIncluirRelacionesAsync(Tarea pTarea)
        {
            return await TareaDAL.BuscarIncluirRelacionesAsync(pTarea);
        }
    }
}
