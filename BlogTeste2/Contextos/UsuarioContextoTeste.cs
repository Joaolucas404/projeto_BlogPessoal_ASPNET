using BlogAPI.Src.Contextos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogTeste.Contextos
{
    ///<summary>
    ///
    /// </summary>
    [TestClass]
    public class UsuarioContextoTeste
    {
        #region Atributos

        private BlogPessoalContexto _contexto;

        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "joao Lucas",
                Email = "joaol@email.com",
                Senha = "1234",
                Foto = "UrlFotoJoao"
            });
            _contexto.SaveChanges();

            // QUANDO - Quando eu pesquiso pelo e-mail do usuario adicionado
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email == "joaol@email.com");

            // ENTÃO - Então deve retornar resultado não nulo
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void LerListaDeUsuariosRetornaTresUsuarios()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Ana Lu",
                Email = "analu@email.com",
                Senha = "1234",
                Foto = "UrlFotoana"
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Mauricio",
                Email = "mauricio@email.com",
                Senha = "1234",
                Foto = "UrlFotoMau"
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Matheus",
                Email = "matheus@email.com",
                Senha = "1234",
                Foto = "UrlFotoMatheus"
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.ToList();

            Assert.AreEqual(3, resultado.Count);
        }

        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT3")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "joao lucas",
                Email = "joaol@email.com",
                Senha = "1234",
                Foto = "UrlFotoJoao"
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "joaol@email.com");
            auxiliar.Nome = "Joao Lucas";
            _contexto.Usuarios.Update(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Joao Lucas");

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void DeletaUsurarioRetornaUsuarioInserido()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT4")
                .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "joao lucas",
                Email = "joaol@email.com",
                Senha = "1234",
                Foto = "UrlFotoJoao"
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "rjoaol@email.com");
            _contexto.Usuarios.Remove(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Joao Lucas");

            Assert.IsNull(resultado);
        }
        #endregion
    }
}
