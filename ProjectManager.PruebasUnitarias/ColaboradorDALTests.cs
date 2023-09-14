using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.AccesoADatos;
using ProjectManager.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos.Tests
{
    [TestClass()]
    public class ColaboradorDALTests
    {
        private static Colaborador colaboradorInicial = new Colaborador { Id = 4, IdProyecto = 1, IdUsuario = 1, Estado = 1};

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var colaborador = new Colaborador();
            colaborador.IdProyecto = colaboradorInicial.IdProyecto;
            colaborador.IdUsuario = colaboradorInicial.IdUsuario;
            colaborador.Estado = (byte)Estatus_Colaborador.ACTIVO;
            int result = await ColaboradorDAL.CrearAsync(colaborador);
            Assert.AreNotEqual(0, result);
            colaboradorInicial.Id = colaborador.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var colaborador = new Colaborador();
            colaborador.Id = colaboradorInicial.Id;
            colaborador.IdProyecto = colaboradorInicial.IdProyecto;
            colaborador.IdUsuario = colaboradorInicial.IdUsuario;
            colaborador.Estado = (byte)Estatus_Colaborador.ACTIVO;
            int result = await ColaboradorDAL.ModificarAsync(colaborador);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var colaborador = new Colaborador();
            colaborador.Id = colaboradorInicial.Id;
            var resultColaborador = await ColaboradorDAL.ObtenerPorIdAsync(colaborador);
            Assert.AreEqual(colaborador.Id, resultColaborador.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultColaboradores = await ColaboradorDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultColaboradores.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var colaborador = new Colaborador();
            colaborador.IdProyecto = colaboradorInicial.IdProyecto;
            colaborador.IdUsuario = colaboradorInicial.IdUsuario;
            colaborador.Estado = (byte)Estatus_Colaborador.ACTIVO;
            colaborador.Top_Aux = 10;
            var resultColaboradores = await ColaboradorDAL.BuscarAsync(colaborador);
            Assert.AreNotEqual(0, resultColaboradores.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRelacionesAsyncTest()
        {
            var colaborador = new Colaborador();
            colaborador.IdProyecto = colaboradorInicial.IdProyecto;
            colaborador.IdUsuario = colaboradorInicial.IdUsuario;
            colaborador.Estado = (byte)Estatus_Colaborador.ACTIVO;
            colaborador.Top_Aux = 10;
            var resultColaboradores = await ColaboradorDAL.BuscarIncluirRelacionesAsync(colaborador);
            Assert.AreNotEqual(0, resultColaboradores.Count);
            var ultimoColaborador = resultColaboradores.FirstOrDefault();
            Assert.IsTrue(ultimoColaborador.Proyecto != null && colaborador.IdProyecto == ultimoColaborador.Proyecto.Id && ultimoColaborador.Usuario != null && colaborador.IdUsuario == ultimoColaborador.Usuario.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var colaborador = new Colaborador();
            colaborador.Id = colaboradorInicial.Id;
            int result = await ColaboradorDAL.EliminarAsync(colaborador);
            Assert.AreNotEqual(0, result);
        }
    }
}