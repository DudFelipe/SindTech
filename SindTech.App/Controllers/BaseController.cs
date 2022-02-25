using Microsoft.AspNetCore.Mvc;
using SindTech.Business.Interfaces;

namespace SindTech.App.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            if (_notificador.TemNotificacao())
            {
                return false;
            }

            return true;
        }
    }
}
