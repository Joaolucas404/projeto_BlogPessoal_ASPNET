using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI1.Src.Modelos;

namespace BlogAPI1.Src.Repositorios
{
    /// <summary>
    /// <para> Responsavel por representar ações de CRUD de usuario</para>
    /// </summary>
    public interface IUsuario
    {
        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        Task NovoUsuarioAsync(Usuario usuario);
    }
}
