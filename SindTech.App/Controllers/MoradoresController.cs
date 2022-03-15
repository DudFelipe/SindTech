using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SindTech.App.ViewModels;
using SindTech.Business.Interfaces;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;

namespace SindTech.App.Controllers
{
    public class MoradoresController : BaseController
    {
        private readonly IMoradorService _moradorService;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public MoradoresController(IMoradorService moradorService,
                                   IContatoService contatoService,
                                   IMapper mapper,
                                   INotificador notificador) : base(notificador)
        {
            _moradorService = moradorService;
            _contatoService = contatoService;
            _mapper = mapper;
        }

        [Route("moradores/listar-moradores")]
        public async Task<IActionResult> Index()
        {
            var moradores = await _moradorService.ObterMoradoresAtivos();

            return View(_mapper.Map<IEnumerable<MoradorViewModel>>(moradores));
        }

        [Route("moradores/adicionar-morador")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("moradores/adicionar-morador")]
        public async Task<IActionResult> Create(MoradorViewModel moradorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(moradorViewModel);
            }

            var morador = _mapper.Map<Morador>(moradorViewModel);

            await _moradorService.Adicionar(morador);

            if (!OperacaoValida())
            {
                return View(moradorViewModel);
            }

            return RedirectToAction("Index");
        }

        [Route("moradores/editar-morador/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var moradorViewModel = await ObterMoradorReclamacoesContato(id);

            if(moradorViewModel == null)
            {
                return NotFound();
            }

            return View(moradorViewModel);
        }

        [HttpPost]
        [Route("moradores/editar-morador/{id:guid}")]
        public async Task<IActionResult>Edit(Guid id, MoradorViewModel moradorViewModel)
        {
            var moradorAux = await ObterMoradorContato(moradorViewModel.Id);

            moradorViewModel.Contato = moradorAux.Contato;

            if(id != moradorViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(moradorViewModel);
            }

            var morador = _mapper.Map<Morador>(moradorViewModel);

            await _moradorService.Atualizar(morador);

            if (!OperacaoValida())
            {
                return View(moradorViewModel);
            }

            return RedirectToAction("Index");
        }

        [Route("contatos/atualizar-contato/{id:guid}")]
        public async Task<IActionResult>AtualizarContato(Guid id)
        {
            var moradorViewModel = _mapper.Map<MoradorViewModel>(await _moradorService.ObterMoradorContato(id));

            if(moradorViewModel == null)
            {
                return NotFound();
            }

            return View(moradorViewModel);
        }

        [HttpPost]
        [Route("contatos/atualizar-contato/{id:guid}")]
        public async Task<IActionResult>AtualizarContato(MoradorViewModel moradorViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("CPF");

            if(!ModelState.IsValid)
            {
                return View(moradorViewModel.Contato);
            }

            await _contatoService.Atualizar(_mapper.Map<Contato>(moradorViewModel.Contato));

            if(!OperacaoValida())
            {
                return View(moradorViewModel.Contato);
            }

            return RedirectToAction("Index");
        }

        [Route("moradores/detalhes/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var moradorViewModel = await ObterMoradorContato(id);

            if(moradorViewModel == null)
            {
                return NotFound();
            }

            return View(moradorViewModel);
        }

        [Route("moradores/apagar-morador/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var moradorViewModel = await ObterMoradorContato(id);

            if(moradorViewModel == null)
            {
                return NotFound();
            }

            return View(moradorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("moradores/apagar-morador/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var moradorViewModel = await ObterMoradorContato(id);

            if(moradorViewModel == null)
            {
                return NotFound();
            }

            var morador = _mapper.Map<Morador>(moradorViewModel);
            morador.Ativo = false;

            await _moradorService.Atualizar(morador);

            if (!OperacaoValida())
            {
                return View(moradorViewModel);
            }

            return RedirectToAction("Index");
        }

        private async Task<MoradorViewModel> ObterMoradorContato(Guid idMorador)
        {
            return _mapper.Map<MoradorViewModel>(await _moradorService.ObterMoradorContato(idMorador));
        }

        private async Task<MoradorViewModel> ObterMoradorReclamacoesContato(Guid idMorador)
        {
            return _mapper.Map<MoradorViewModel>(await _moradorService.ObterMoradorReclamacoesContato(idMorador));
        }
    }
}
