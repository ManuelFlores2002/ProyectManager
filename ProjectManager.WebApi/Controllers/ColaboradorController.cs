using ProjectManager.EntidadesDeNegocio;
using ProjectManager.LogicaDeNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private ColaboradorBL colaboradorBL = new ColaboradorBL();

        [HttpGet]
        public async Task<IEnumerable<Colaborador>> Get()
        {
            return await colaboradorBL.ObtenerTodosAsync();
        }
        [HttpGet("{id}")]
        public async Task<Colaborador> Get(int id)
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Id = id;
            return await colaboradorBL.ObtenerPorIdAsync(colaborador);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Colaborador colaborador)
        {
            try
            {
                await colaboradorBL.CrearAsync(colaborador);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Colaborador colaborador)
        {
            if (colaborador.Id == id)
            {
                await colaboradorBL.ModificarAsync(colaborador);
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
                Colaborador colaborador = new Colaborador();
                colaborador.Id = id;
                await colaboradorBL.EliminarAsync(colaborador);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Colaborador>> Buscar([FromBody] object pColaborador)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strColaborador = JsonSerializer.Serialize(pColaborador);
            Colaborador colaborador = JsonSerializer.Deserialize<Colaborador>(strColaborador);
            var colaboradores = await colaboradorBL.BuscarIncluirRelacionesAsync(colaborador);
            colaboradores.ForEach(s => { s.Proyecto = null; s.Usuario = null; });
            return colaboradores;
        }
    }
}
