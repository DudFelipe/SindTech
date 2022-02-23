using AutoMapper;
using SindTech.App.ViewModels;
using SindTech.Business.Models;

namespace SindTech.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Morador, MoradorViewModel>().ReverseMap();
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
            CreateMap<Reclamacao, ReclamacaoViewModel>().ReverseMap();
        }
    }
}
