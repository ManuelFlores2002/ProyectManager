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
    public class ProyectoDALTests
    {
        private static Proyecto proyectoInicial = new Proyecto { Id = 18, IdAdministrador = 6 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.IdAdministrador = proyectoInicial.IdAdministrador;
            proyecto.Nombre = "GoldenGym";
            proyecto.Descripcion = "Proyecto de Membresias para un gym";
            proyecto.Estado = 1;

            int result = await ProyectoDAL.CrearAsync(proyecto);
            Assert.AreNotEqual(0, result);
            proyectoInicial.Id = proyecto.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.Id = proyectoInicial.Id;
            proyecto.IdAdministrador = proyectoInicial.IdAdministrador;
            proyecto.Nombre = "GymGoldem";
            proyecto.Descripcion = "Proyecto de Membresias para un gym";
            proyecto.Estado = 1;

            int result = await ProyectoDAL.ModificarAsync(proyecto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.Id = proyectoInicial.Id;
            var resultProyecto = await ProyectoDAL.ObtenerPorIdAsync(proyecto);
            Assert.AreEqual(proyecto.Id, resultProyecto.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProyectos = await ProyectoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProyectos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.IdAdministrador = proyectoInicial.IdAdministrador;
            proyecto.Nombre = "G";
            proyecto.Descripcion = "g";
            proyecto.Top_Aux = 10;
            var resultProyecto = await ProyectoDAL.BuscarAsync(proyecto);
            Assert.AreNotEqual(0, resultProyecto.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirUsuariosAsyncTest()
        {
            var proyecto = new Proyecto();
            proyecto.IdAdministrador = proyectoInicial.IdAdministrador;
            proyecto.Nombre = "P";
            proyecto.Descripcion = "P";
            proyecto.Top_Aux = 10;
            var resultProyecto = await ProyectoDAL.BuscarIncluirUsuariosAsync(proyecto);
            Assert.AreNotEqual(0, resultProyecto.Count);
            var ultimoProyecto = resultProyecto.FirstOrDefault();
            Assert.IsTrue(ultimoProyecto.Usuario != null && proyecto.IdAdministrador == ultimoProyecto.Usuario.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var proyecto = new  Proyecto();
            proyecto.Id = proyectoInicial.Id;
            int result = await ProyectoDAL.EliminarAsync(proyecto);
            Assert.AreNotEqual(0, result);
        }
    }
}