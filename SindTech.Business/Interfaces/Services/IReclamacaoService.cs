using SindTech.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SindTech.Business.Interfaces.Services
{
    public interface IReclamacaoService : IDisposable
    {
        Task<IEnumerable<Reclamacao>> ObterReclamacoesPorMorador(Guid moradorId);
        Task<IEnumerable<Reclamacao>> ObterReclamacoesMoradores();
        Task<IEnumerable<Reclamacao>> ObterReclamacoesAtivas();
        Task<Reclamacao> ObterReclamacaoMorador(Guid id);
        Task Adicionar(Reclamacao reclamacao);
        Task Atualizar(Reclamacao reclamacao);
        Task Excluir(Guid id);
    }
}
