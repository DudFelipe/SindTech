using SindTech.Business.Models;

namespace SindTech.Business.Interfaces.Services
{
    public interface IContatoService : IDisposable
    {
        Task<Contato> ObterContatoPorMorador(Guid moradorId);
        Task Adicionar(Contato contato);
        Task Atualizar(Contato contato);
        Task Excluir(Guid id);
    }
}
