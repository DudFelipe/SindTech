using SindTech.Business.Models;

namespace SindTech.Business.Interfaces.Repositories
{
    public interface IReclamacaoRepository : IRepository<Reclamacao>
    {
        Task<IEnumerable<Reclamacao>> ObterReclamacoesPorMorador(Guid moradorId);
        Task<IEnumerable<Reclamacao>> ObterReclamacoesMoradores();
        Task<Reclamacao> ObterReclamacaoMorador(Guid id);
    }
}
