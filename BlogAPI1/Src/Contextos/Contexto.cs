using BlogAPI1.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI1.Src.Contextos
{
    public class BlogPessoalContexto : DbContext
    {
        #region Atributos

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Postagem> Postagens { get; set; }

        #endregion

        #region Construtores
        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)
        {
        }
        #endregion
    }
}