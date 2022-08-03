using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Src.Contextos
{
    /// <summary>
    /// <para> Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para> Criado por:João Lucas</para>
    /// <para> Versão: 1.0</para>
    /// <para> Data: 02/08/2022</para>
    /// </summary>
    public class BlogPessoalContexto : DbContext
    {
        #region Atributos

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Postagem> Postagems { get; set; }

        #endregion

        #region Construtores
        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)
        {
        }
        #endregion
    }
}