using AutoMapper;
using Sommus.CodingDojo.Application.ViewModel;
using Sommus.CodingDojo.Domain.Entities;

namespace Sommus.CodingDojo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // Usuário
            CreateMap<Pessoa, PessoaVM>();
        }
    }
}