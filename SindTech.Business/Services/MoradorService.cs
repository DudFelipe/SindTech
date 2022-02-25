using SindTech.Business.Interfaces;
using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;
using SindTech.Business.Models.Validations;

namespace SindTech.Business.Services
{
    public class MoradorService : BaseService, IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;

        public MoradorService(IMoradorRepository moradorRepository,
                              INotificador notificador) : base(notificador)
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

        public async Task<IEnumerable<Morador>> ObterMoradoresAtivos()
        {
            return await _moradorRepository.Buscar(m => m.Ativo == true);
        }

        public async Task Adicionar(Morador morador)
        {
            if(!ExecutarValidacao(new MoradorValidation(), morador) ||
                !ExecutarValidacao(new ContatoValidation(), morador.Contato))
            {
                return;
            }

            if(_moradorRepository.Buscar(m => m.CPF == morador.CPF).Result.Any())
            {
                Notificar("Já existe um morador com esse CPF.");
                return;
            }

            await _moradorRepository.Adicionar(morador);
        }

        public async Task Atualizar(Morador morador)
        {
            if (!ExecutarValidacao(new MoradorValidation(), morador) ||
                !ExecutarValidacao(new ContatoValidation(), morador.Contato))
            {
                return;
            }

            if (_moradorRepository.Buscar(m => m.CPF == morador.CPF && m.Id != morador.Id).Result.Any())
            {
                Notificar("Já existe um morador com esse CPF.");
                return;
            }

            await _moradorRepository.Atualizar(morador);
        }

        public async Task Remover(Guid id)
        {
            if (_moradorRepository.ObterMoradorReclamacoesContato(id).Result.Reclamacoes.Any())
            {
                Notificar("O morador possui reclamações registradas!");
                return;
            }

            await _moradorRepository.Excluir(id);
        }

        public void Dispose()
        {
            _moradorRepository?.Dispose();
        }
    }
}
