using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Models;
using SindTech.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SindTech.Data.Repository
{
    public class MoradorRepository : Repository<Morador>, IMoradorRepository
    {
        public MoradorRepository(DatabaseContext db) : base(db)
        {

        }

        public async Task<IEnumerable<Morador>> ObterMoradoresAtivos()
        {
            return await Db.Moradores
                .AsNoTracking()
                .Include(c => c.Contato)
                .ToListAsync();
        }

        public async Task<Morador> ObterMoradorContato(Guid id)
        {
            return await Db.Moradores
                .AsNoTracking()
                .Include(c => c.Contato)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Morador> ObterMoradorReclamacoesContato(Guid id)
        {
            return await Db.Moradores
                .AsNoTracking()
                .Include(r => r.Reclamacoes)
                .Include(c => c.Contato)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
