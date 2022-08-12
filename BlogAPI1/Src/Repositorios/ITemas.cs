using BlogAPI1.Src.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI1.Src.Repositorios
{
    public interface ITema
    {
        Task<List<Tema>> PegarTodasTemasAsync();
        Task<Tema> PegarTemaPeloIdAsync(int id);
        Task NovaTemaAsync(Tema tema);
        Task AtualizarTemaAsync(Tema tema);
        Task DeletarTemaAsync(int id);
    }
}