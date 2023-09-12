using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.AccesoADatos;
using System;
using ProjectManager.EntidadesDeNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.AccesoADatos.Tests
{
    [TestClass()]
    public class UsuarioDALTests
    {
        private static Usuario usuarioInicial = new Usuario { Id = 2, IdRol = 1, Login = "RobertoF", Password = "12345" };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Roberto";
            usuario.Apellido = "Funes";
            usuario.Login = "RobertoF";
            string Password = "12345";
            usuario.Password = Password;
            usuario.Estatus = (byte)Estatus_Usuario.INACTIVO;
            int result = await UsuarioDAL.CrearAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Id = usuario.Id;
            usuarioInicial.Password = Password;
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Roberto";
            usuario.Apellido = "Funes";
            usuario.Login = "RobertoF";
            usuario.Estatus = (byte)Estatus_Usuario.INACTIVO;
            int result = await UsuarioDAL.ModificarAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            var resultUsuario = await UsuarioDAL.ObtenerPorIdAsync(usuario);
            Assert.AreEqual(usuario.Id, resultUsuario.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultUsuarios = await UsuarioDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultUsuarios.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "R";
            usuario.Apellido = "F";
            usuario.Login = "R";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.top_aux = 10;
            var resultUsuarios = await UsuarioDAL.BuscarAsync(usuario);
            Assert.AreNotEqual(0, resultUsuarios.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRolesAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "R";
            usuario.Apellido = "r";
            usuario.Login = "R";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.top_aux = 10;
            var resultUsuarios = await UsuarioDAL.BuscarIncluirRolesAsync(usuario);
            Assert.AreNotEqual(0, resultUsuarios.Count);
            var ultimoUsuario = resultUsuarios.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.Rol != null && usuario.IdRol == ultimoUsuario.Rol.Id);

        }

        [TestMethod()]
        public async Task T7CambiarPasswordAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            String passwordNuevo = "12345";
            usuario.Password = passwordNuevo;
            var result = await UsuarioDAL.CambiarPasswordAsync(usuario, usuarioInicial.Password);
        }

        [TestMethod()]
        public async Task T8LoginAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Login = usuarioInicial.Login;
            usuario.Password = usuarioInicial.Password;
            var resultUsuario = await UsuarioDAL.LoginAsync(usuario);
            Assert.AreEqual(usuario.Login, resultUsuario.Login);
        }


        [TestMethod()]
        public async Task T9EliminarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            int result = await UsuarioDAL.EliminarAsync(usuario);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T10RegistrarUsuarioAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Roberto";
            usuario.Apellido = "Funes";
            usuario.Login = "RobertoF";
            string Password = "827ccb0eea8a706c4c34a16891f84e7b";
            usuario.Password = Password;
            usuario.Estatus = (byte)Estatus_Usuario.INACTIVO;
            int result = await UsuarioDAL.RegistrarUsuarioAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Id = usuario.Id;
            usuarioInicial.Password = Password;
            usuarioInicial.Login = usuario.Login;
        }
    }
}