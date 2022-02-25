using Microsoft.AspNetCore.Mvc;
using SindTech.Business.Interfaces;

namespace SindTech.App.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

            notificacoes.ForEach(notificacao => ViewData.ModelState.AddModelError(String.Empty, notificacao.Mensagem));

            return View();
        }
    }
}
