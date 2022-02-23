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
            var moradores = await _moradorService.ObterTodos();

            return View(_mapper.Map<IEnumerable<MoradorViewModel>>(moradores));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MoradorViewModel moradorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(moradorViewModel);
            }

            var morador = _mapper.Map<Morador>(moradorViewModel);

            _moradorService.Adicionar(morador);

            return RedirectToAction("Index");
        }
    }
}
