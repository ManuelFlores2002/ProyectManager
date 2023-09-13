using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.AccesoADatos;
using ProjectManager.EntidadesDeNegocio;
using ProjectManager.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos.Tests
{
    [TestClass()]
    public class TareaDALTests
    {
        private static Tarea tareaInicial = new Tarea { Id = 2, IdProyecto = 1, IdColaborador = 1, Nombre = "Crear Pruevas Unitarias", Descripcion = "Crear pruevas unitarias para cada uno de los metodos de la clase DAL Tarea", Prioridad = 1, Esfuerzo = 1, Estado = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var tarea = new Tarea();
            tarea.IdProyecto = tareaInicial.IdProyecto;
            tarea.IdColaborador = tareaInicial.IdColaborador;
            tarea.Nombre = "Crear Entidades de Negocio";
            tarea.Descripcion = "Creación de las clases entidades de negocio del proyecto";
            tarea.Prioridad = 1;
            tarea.Esfuerzo = 1;
            tarea.Estado = (byte)Estado_Tarea.ACTIVO;
            int result = await TareaDAL.CrearAsync(tarea);
            Assert.AreNotEqual(0, result);
            tareaInicial.Id = tarea.Id;

        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var tarea = new Tarea();
            tarea.Id = tareaInicial.Id;
            tarea.IdProyecto = tareaInicial.IdProyecto;
            tarea.IdColaborador = tareaInicial.IdColaborador;
            tarea.Nombre = "Crear Entidades de Negocio";
            tarea.Descripcion = "Creación de las clases entidades de negocio del proyecto";
            tarea.Prioridad = 3;
            tarea.Esfuerzo = 2;
            int result = await TareaDAL.ModificarAsync(tarea);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var tarea = new Tarea();
            tarea.Id = tareaInicial.Id;
            var resultTarea = await TareaDAL.ObtenerPorIdAsync(tarea);
            Assert.AreEqual(tarea.Id, resultTarea.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultTarea = await TareaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultTarea.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var tarea = new Tarea();
            tarea.IdProyecto = tareaInicial.IdProyecto;
            tarea.IdColaborador = tareaInicial.IdColaborador;
            tarea.Nombre = "Crear";
            tarea.Descripcion = "Creación de las clases";
            tarea.Prioridad = 3;
            tarea.Estado = (byte)Estado_Tarea.ACTIVO;
            tarea.Top_Aux = 10;
            var resultTarea = await TareaDAL.BuscarAsync(tarea);
            Assert.AreEqual(0, resultTarea.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRelacionesAsyncTest()
        {
            var tarea = new Tarea();
            tarea.IdProyecto = tareaInicial.IdProyecto;
            tarea.IdColaborador = tareaInicial.IdColaborador;
            tarea.Nombre = "Creación de Capa de Entidades de Negocio";
            tarea.Descripcion = "Crear todas las clases de Entidades";
            tarea.Prioridad = 1;
            tarea.Estado = (byte)Estado_Tarea.ACTIVO;
            tarea.Top_Aux = 10;
            var resultTarea = await TareaDAL.BuscarIncluirRelacionesAsync(tarea);
            Assert.AreNotEqual(0, resultTarea.Count);
            var ultimaTarea = resultTarea.FirstOrDefault();
            Assert.IsTrue(ultimaTarea.Proyecto != null && tarea.IdProyecto == ultimaTarea.Proyecto.Id && ultimaTarea.Colaborador != null && tarea.IdColaborador == ultimaTarea.Colaborador.Id);
        }
        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var tarea = new Tarea();
            tarea.Id = tareaInicial.Id;
            int result = await TareaDAL.EliminarAsync(tarea);
            Assert.AreNotEqual(0, result);
        }
    }
}