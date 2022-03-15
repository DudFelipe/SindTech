using Microsoft.EntityFrameworkCore;
using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Models;
using SindTech.Data.Context;

namespace SindTech.Data.Repository
{
    public class ReclamacaoRepository : Repository<Reclamacao>, IReclamacaoRepository
    {
        public ReclamacaoRepository(DatabaseContext db) : base(db)
        {
        }

        public async Task<Reclamacao> ObterReclamacaoMorador(Guid id)
        {
            return await Db.Reclamacoes
                .AsNoTracking()
                .Include(m => m.Morador)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reclamacao>> ObterReclamacoesMoradores()
        {
            return await Db.Reclamacoes
                .AsNoTracking()
                .Include(m => m.Morador)
                .OrderBy(r => r.Descricao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reclamacao>> ObterReclamacoesAtivasMoreadores()
        {
            return await Db.Reclamacoes
                .AsNoTracking()
                .Include(m => m.Morador)
                .Where(r => r.Ativo == true)
                .OrderBy(r => r.Descricao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reclamacao>> ObterReclamacoesPorMorador(Guid moradorId)
        {
            return await Buscar(r => r.MoradorId == moradorId);
        }
    }
}
