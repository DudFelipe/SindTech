using SindTech.Business.Models;

namespace SindTech.Business.Interfaces.Repositories
{
    public interface IMoradorRepository : IRepository<Morador>
    {
        Task<Morador> ObterMoradorContato(Guid id); //Obtem um morador com seu contato
        Task<Morador> ObterMoradorReclamacoesContato(Guid id); //Obtem um morador com seu contato e com suas reclamações.
    }
}
