using BlogAPI1.Src.Modelos;
using BlogAPI1.Src.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI1.Src.Controladores
{
    [ApiController]
    [Route("api/Temas")]
    [Produces("application/json")]
    public class TemaController : ControllerBase
    {
        #region Atributos
        private readonly ITema _repositorio;
        #endregion

        #region Construtores
        public TemaController(ITema repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Metodo
       
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> PegaTodosTemasAsync()
        {
            var lista = await _repositorio.PegarTodasTemasAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpGet("id/{idTema}")]
        [Authorize]
        public async Task<ActionResult> PegarTemaPeloIdAsync([FromRoute] int idTema)
        {
            try
            {
                return Ok(await _repositorio.PegarTemaPeloIdAsync(idTema));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NovoTemaAsync([FromBody] Tema tema)
        {
            try
            {
                await _repositorio.NovaTemaAsync(tema);
                return Created($"api/Temas", tema);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ActionResult> AtualizarTemaAsync([FromRoute] Tema tema)
        {
            try
            {
                await _repositorio.AtualizarTemaAsync(tema);
                return Ok(tema);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpDelete("id/{idTema}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ActionResult> DeletarTemaAsync([FromRoute] int idTema)
        {
            try
            {
                await _repositorio.DeletarTemaAsync(idTema);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
        #endregion
    }
}