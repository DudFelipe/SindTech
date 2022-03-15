using SindTech.Business.Interfaces;
using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;
using SindTech.Business.Models.Validations;

namespace SindTech.Business.Services
{
    public class ContatoService : BaseService, IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository,
                              INotificador notificador) : base(notificador)
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
            if(!ExecutarValidacao(new ContatoValidation(), contato))
            {
                return;
            }

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
