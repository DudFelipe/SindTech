using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SindTech.App.ViewModels;
using SindTech.Business.Interfaces;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;

namespace SindTech.App.Controllers
{
    public class ReclamacoesController : BaseController
    {
        private readonly IReclamacaoService _reclamacaoService;
        private readonly IMoradorService _moradorService;
        private readonly IMapper _mapper;

        public ReclamacoesController(IReclamacaoService reclamacaoService,
                                     IMoradorService moradorService, 
                                     IMapper mapper,
                                     INotificador notificador) : base(notificador)
        {
            _reclamacaoService = reclamacaoService;
            _moradorService = moradorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var reclamacoes = await _reclamacaoService.ObterReclamacoesAtivas();

            return View(_mapper.Map<IEnumerable<ReclamacaoViewModel>>(reclamacoes));
        }

        public async Task<IActionResult> Create()
        {
            var reclamacaoViewModel = await PopularMoradores(new ReclamacaoViewModel());

            return View(reclamacaoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReclamacaoViewModel reclamacaoViewModel)
        {
            reclamacaoViewModel = await(PopularMoradores(reclamacaoViewModel));

            if(!ModelState.IsValid)
            {
                return View(reclamacaoViewModel);
            }

            await _reclamacaoService.Adicionar(_mapper.Map<Reclamacao>(reclamacaoViewModel));

            if(!OperacaoValida())
            {
                return View(reclamacaoViewModel);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var reclamacaoViewModel = await ObterReclamacaoMorador(id);

            if(reclamacaoViewModel == null)
            {
                return NotFound();
            }

            return View(reclamacaoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReclamacaoViewModel reclamacaoViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(reclamacaoViewModel);
            }

            var reclamacaoAntigo = await ObterReclamacaoMorador(reclamacaoViewModel.Id);

            reclamacaoViewModel.Morador = reclamacaoAntigo.Morador;
            reclamacaoViewModel.MoradorId = reclamacaoAntigo.MoradorId;

            await _reclamacaoService.Atualizar(_mapper.Map<Reclamacao>(reclamacaoViewModel));

            if(!OperacaoValida())
            {
                return View(reclamacaoViewModel);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var reclamacaoViewModel = await ObterReclamacaoMorador(id);

            if(reclamacaoViewModel == null)
            {
                return NotFound();
            }

            return View(reclamacaoViewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var reclamacaoViewModel = await ObterReclamacaoMorador(id);

            if(reclamacaoViewModel == null)
            {
                return NotFound();
            }

            return View(reclamacaoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var reclamacaoViewModel = await ObterReclamacaoMorador(id);

            var reclamacao = _mapper.Map<Reclamacao>(reclamacaoViewModel);

            reclamacao.Ativo = false;

            await _reclamacaoService.Atualizar(reclamacao);

            if(!OperacaoValida())
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        private async Task<ReclamacaoViewModel> PopularMoradores(ReclamacaoViewModel reclamacaoViewModel)
        {
            reclamacaoViewModel.Moradores = _mapper.Map<IEnumerable<MoradorViewModel>>(await _moradorService.ObterMoradoresAtivos());

            return reclamacaoViewModel;
        }

        private async Task<ReclamacaoViewModel> ObterReclamacaoMorador(Guid idReclamacao)
        {
            return _mapper.Map<ReclamacaoViewModel>(await _reclamacaoService.ObterReclamacaoMorador(idReclamacao));
        }

        private async Task<IEnumerable<ReclamacaoViewModel>> ObterReclamacoesAtivas()
        {
            return _mapper.Map<IEnumerable<ReclamacaoViewModel>>(await _reclamacaoService.ObterReclamacoesAtivas());
        }
    }
}
