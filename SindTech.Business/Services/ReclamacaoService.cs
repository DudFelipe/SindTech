using SindTech.Business.Interfaces;
using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;
using SindTech.Business.Models.Validations;

namespace SindTech.Business.Services
{
    public class ReclamacaoService : BaseService, IReclamacaoService
    {
        private readonly IReclamacaoRepository _reclamacaoRepository;

        public ReclamacaoService(IReclamacaoRepository reclamacaoRepository,
                                 INotificador notificador) : base(notificador)
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

        public async Task<IEnumerable<Reclamacao>> ObterReclamacoesAtivasMoradores()
        {
            //return await _reclamacaoRepository.Buscar(r => r.Ativo == true);
            return await _reclamacaoRepository.ObterReclamacoesAtivasMoreadores();
        }

        public async Task<IEnumerable<Reclamacao>> ObterReclamacoesPorMorador(Guid moradorId)
        {
            return await _reclamacaoRepository.ObterReclamacoesPorMorador(moradorId);
        }
        public async Task Adicionar(Reclamacao reclamacao)
        {
            if(!ExecutarValidacao(new ReclamacaoValidation(), reclamacao))
            {
                return;
            }

            await _reclamacaoRepository.Adicionar(reclamacao);
        }

        public async Task Atualizar(Reclamacao reclamacao)
        {
            if(!ExecutarValidacao(new ReclamacaoValidation(), reclamacao))
            {
                return;
            }

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
