using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SindTech.App.ViewModels;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Models;

namespace SindTech.App.Controllers
{
    public class MoradoresController : Controller
    {
        private readonly IMoradorService _moradorService;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public MoradoresController(IMoradorService moradorService, 
                                   IContatoService contatoService,
                                   IMapper mapper)
        {
            _moradorService = moradorService;
            _contatoService = contatoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var moradores = await _moradorService.ObterMoradoresAtivos();

            return View(_mapper.Map<IEnumerable<MoradorViewModel>>(moradores));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MoradorViewModel moradorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(moradorViewModel);
            }

            var morador = _mapper.Map<Morador>(moradorViewModel);

            await _moradorService.Adicionar(morador);

            return RedirectToAction("Index");
        }

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

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var moradorViewModel = await ObterMoradorContato(id);

            if(moradorViewModel == null)
            {
                return NotFound();
            }

            return View(moradorViewModel);
        }

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
