using Microsoft.EntityFrameworkCore;
using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Models;
using SindTech.Data.Context;

namespace SindTech.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(DatabaseContext db) : base(db)
        {
        }

        public async Task<Contato> ObterContatoPorMorador(Guid moradorId)
        {
            return await Db.Contatos
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MoradorId == moradorId);
        }
    }
}
