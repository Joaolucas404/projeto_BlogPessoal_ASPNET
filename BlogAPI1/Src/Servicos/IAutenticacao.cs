using System.Threading.Tasks;
using BlogAPI1.Src.Modelos;

namespace BlogAPI1.Src.Servicos
{
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(Usuario usuario);
        string GerarToken(Usuario usuario);
    }
}
