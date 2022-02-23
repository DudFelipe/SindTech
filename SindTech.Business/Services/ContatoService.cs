using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;

namespace SindTech.Business.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Contato> ObterContatoPorMorador(Guid moradorId)
        {
            return await _contatoRepository.ObterContatoPorMorador(moradorId);
        }

        public async Task Adicionar(Contato contato)
        {
            await _contatoRepository.Adicionar(contato);
        }

        public async Task Atualizar(Contato contato)
        {
            await _contatoRepository.Atualizar(contato);
        }

        public async Task Excluir(Guid id)
        {
            await _contatoRepository.Excluir(id);
        }

        public void Dispose()
        {
            _contatoRepository?.Dispose();
        }
    }
}
