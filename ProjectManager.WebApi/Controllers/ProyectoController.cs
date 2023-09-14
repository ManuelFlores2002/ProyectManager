using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.EntidadesDeNegocio;
using ProjectManager.LogicaDeNegocios;
using System.Text.Json;

namespace ProjectManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private ProyectoBL proyectoBL = new ProyectoBL();

        [HttpGet]
        public async Task<IEnumerable<Proyecto>> Get()
        {
            return await proyectoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Proyecto> Get(int id)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.Id = id;
            return await proyectoBL.ObtenerPorIdAsync(proyecto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Proyecto proyecto)
        {
            try
            {
                await proyectoBL.CrearAsync(proyecto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Proyecto proyecto)
        {
            if (proyecto.Id == id)
            {
                await proyectoBL.ModificarAsync(proyecto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Proyecto proyecto = new Proyecto();
                proyecto.Id = id;
                await proyectoBL.EliminarAsync(proyecto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Proyecto>> Buscar([FromBody] object pProyecto)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProyecto = JsonSerializer.Serialize(pProyecto);
            Proyecto proyecto = JsonSerializer.Deserialize<Proyecto>(strProyecto, option);
            var proyectos = await proyectoBL.BuscarIncluirUsuariosAsync(proyecto);
            proyectos.ForEach(s => s.Usuario.Proyecto = null);
            return proyectos;
        }

    }
}

