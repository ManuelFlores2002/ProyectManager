using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectManager.AccesoADatos;
using ProjectManager.EntidadesDeNegocio;

namespace ProjectManager.LogicaDeNegocios
{
    public class ColaboradorBL
    {
        public async Task<int> CrearAsync(Colaborador pColaborador)
        {
            return await ColaboradorDAL.CrearAsync(pColaborador);
        }

        public async Task<int> ModificarAsync(Colaborador pColaborador)
        {
            return await ColaboradorDAL.ModificarAsync(pColaborador);
        }

        public async Task<int> EliminarAsync(Colaborador pColaborador)
        {
            return await ColaboradorDAL.EliminarAsync(pColaborador);
        }

        public async Task<Colaborador> ObtenerPorIdAsync(Colaborador pColaborador)
        {
            return await ColaboradorDAL.ObtenerPorIdAsync(pColaborador);
        }

        public async Task<List<Colaborador>> ObtenerTodosAsync()
        {
            return await ColaboradorDAL.ObtenerTodosAsync();
        }

        public async Task<List<Colaborador>> BuscarAsync(Colaborador pColaborador)
        {
            return await ColaboradorDAL.BuscarAsync(pColaborador);
        }

        public async Task<List<Colaborador>> BuscarIncluirRelacionesAsync (Colaborador pColaborador)
        {
            return await ColaboradorDAL.BuscarIncluirRelacionesAsync(pColaborador);
        }
    }
}
