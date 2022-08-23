using BlogAPI1.Src.Modelos;
using BlogAPI1.Src.Repositorios;
using BlogAPI1.Src.Servicos;
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
    [Route("api/Usuarios")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        #region Atributos
        private readonly IUsuario _repositorio;
        private readonly IAutenticacao _servicos;
        #endregion

        #region Construtores
        public UsuarioController(IUsuario repositorio, IAutenticacao servicos)
        {
            _repositorio = repositorio;
            _servicos = servicos;
        }
        #endregion

        #region Metodos
       
        [HttpGet("email/{emailUsuario}")]
        [Authorize(Roles = "NORMAL, ADMINISTRADOR")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(emailUsuario);

            if (usuario == null) return NotFound(new { Mensagem = "Usuario não encontrado" });

            return Ok(usuario);
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] Usuario usuario)
        {
            try
            {
                await _servicos.CriarUsuarioSemDuplicarAsync(usuario);
                return Created($"api/Usuarios/email/{usuario.Email}", usuario);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary> 
        /// Pegar Autorização 
        /// </summary> 
        /// <param name="usuario">Construtor para logar usuario</param> 
        /// <returns>ActionResult</returns> 
        /// <remarks> 
        /// Exemplo de requisição: 
        ///     POST /api/Usuarios/logar 
        ///     { 
        ///         "email": "gustavo@domain.com", 
        ///         "senha": "134652" 
        ///     } 
        /// </remarks> 
        /// <response code="201">Retorna usuario criado</response> 
        /// <response code="401">E-mail ou senha invalido</response>
        [HttpPost("logar")]
        [AllowAnonymous]
        public async Task<ActionResult> LogarAsync([FromBody] Usuario usuario)
        {
            var auxiliar = await _repositorio.PegarUsuarioPeloEmailAsync(usuario.Email);

            if (auxiliar == null) return Unauthorized(new { Mensagem = "E-mail inválio" });

            if (auxiliar.Senha != _servicos.CodificarSenha(usuario.Senha))
                return Unauthorized(new { Mensagem = "Senha inválida" });

            var token = "Bearer " + _servicos.GerarToken(auxiliar);

            return Ok(new { Usuario = auxiliar, Token = token });
        }
        #endregion
    }
}