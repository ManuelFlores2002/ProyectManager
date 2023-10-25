using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.EntidadesDeNegocio;
using ProjectManager.LogicaDeNegocios;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TareaController : ControllerBase
    {
        private TareaBL tareaBL = new TareaBL();
        [HttpGet]
        public async Task<IEnumerable<Tarea>> Get()
        {
            return await tareaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Tarea> Get (int id)
        {
            Tarea tarea = new Tarea();
            tarea.Id = id;
            return await tareaBL.ObtenerPorIdAsync(tarea);
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody]Tarea tarea)
        {
            try
            {
                await tareaBL.CrearAsync(tarea);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody] Tarea tarea)
        {
            if(tarea.Id == id)
            {
                await tareaBL.ModificarAsync(tarea);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            try
            {
                Tarea tarea = new Tarea();
                tarea.Id = id;
                await tareaBL.EliminarAsync(tarea);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Tarea>>Buscar([FromBody] object pTarea)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string srtTarea = JsonSerializer.Serialize(pTarea);
            Tarea tarea = JsonSerializer.Deserialize<Tarea>(srtTarea, option);
            var tareas = await tareaBL.BuscarIncluirRelacionesAsync(tarea);
            tareas.ForEach(s => s.Proyecto.Tarea = null);
            tareas.ForEach(s => s.Colaborador.Tarea = null);
            return tareas;
        }
          
         

    }
}
