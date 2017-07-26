using AutoMapper;
using Sommus.CodingDojo.Application.ViewModel;
using Sommus.CodingDojo.Domain.Entities;

namespace Sommus.CodingDojo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // Usuário
            CreateMap<PessoaVM, Pessoa>();
        }
    }
}