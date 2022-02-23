using SindTech.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SindTech.Business.Interfaces.Repositories
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<Contato> ObterContatoPorMorador(Guid moradorId);
    }
}
