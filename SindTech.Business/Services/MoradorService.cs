using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;

namespace SindTech.Business.Services
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;

        public MoradorService(IMoradorRepository moradorRepository)
        {
            _moradorRepository = moradorRepository;
        }

        public async Task<Morador> ObterMoradorContato(Guid id)
        {
            return await _moradorRepository.ObterMoradorContato(id);
        }

        public async Task<Morador> ObterMoradorReclamacoesContato(Guid id)
        {
            return await _moradorRepository.ObterMoradorReclamacoesContato(id);
        }

        public async Task<Morador> ObterPorId(Guid id)
        {
            return await _moradorRepository.ObterPorId(id);
        }

        public async Task<IList<Morador>> ObterTodos()
        {
            return await _moradorRepository.ObterTodos();
        }

        public async Task Adicionar(Morador morador)
        {
            await _moradorRepository.Adicionar(morador);
        }

        public async Task Atualizar(Morador morador)
        {
            await _moradorRepository.Atualizar(morador);
        }

        public async Task Remover(Guid id)
        {
            await _moradorRepository.Excluir(id);
        }

        public void Dispose()
        {
            //_moradorRepository?.Dispose();
        }
    }
}
