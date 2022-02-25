using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SindTech.Business.Notificacoes
{
    public class Notificacao
    {
        public string Mensagem { get; }

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
