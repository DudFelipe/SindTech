using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;

namespace SindTech.Business.Services
{
    public class ReclamacaoService : IReclamacaoService
    {
        private readonly IReclamacaoRepository _reclamacaoRepository;

        public ReclamacaoService(IReclamacaoRepository reclamacaoRepository)
        {
            _reclamacaoRepository = reclamacaoRepository;
        }

        public async Task<Reclamacao> ObterReclamacaoMorador(Guid id)
        {
            return await _reclamacaoRepository.ObterReclamacaoMorador(id);
        }

        public async Task<IEnumerable<Reclamacao>> ObterReclamacoesMoradores()
        {
            return await _reclamacaoRepository.ObterReclamacoesMoradores();
        }

        public async Task<IEnumerable<Reclamacao>> ObterReclamacoesPorMorador(Guid moradorId)
        {
            return await _reclamacaoRepository.ObterReclamacoesPorMorador(moradorId);
        }
        public async Task Adicionar(Reclamacao reclamacao)
        {
            await _reclamacaoRepository.Adicionar(reclamacao);
        }

        public async Task Atualizar(Reclamacao reclamacao)
        {
            await _reclamacaoRepository.Atualizar(reclamacao);
        }

        public async Task Excluir(Guid id)
        {
            await _reclamacaoRepository.Excluir(id);
        }

        public void Dispose()
        {
            _reclamacaoRepository?.Dispose();
        }
    }
}
