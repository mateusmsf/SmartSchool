using AutoMapper;
using SchoolAPIcode.Models;

namespace SchoolAPIcode.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, Dtos.AlunoDto>()
                .ForMember(
                    dest => dest.nome,
                    opt => opt.MapFrom(src => $"{src.nome} {src.sobreNome}")
                )
                .ForMember(
                    dest => dest.idade,
                    opt => opt.MapFrom(src => src.dataNasc.GetCurrentAge())
                );
            ;
        }
    }
}