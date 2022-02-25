using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Models;

namespace SindTech.Business.Interfaces.Services
{
    public interface IMoradorService : IDisposable
    {
        Task Adicionar(Morador morador);
        Task Atualizar(Morador morador);
        Task Remover(Guid id);
        Task<IList<Morador>> ObterTodos();
        Task<IEnumerable<Morador>> ObterMoradoresAtivos();
        Task<Morador> ObterPorId(Guid id);
        Task<Morador> ObterMoradorContato(Guid id);
        Task<Morador> ObterMoradorReclamacoesContato(Guid id);
    }
}
