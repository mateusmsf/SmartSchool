using AutoMapper;
using SchoolAPIcode.Dtos;
using SchoolAPIcode.Models;

namespace SchoolAPIcode.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.nome,
                    opt => opt.MapFrom(src => $"{src.nome} {src.sobreNome}")
                )
                .ForMember(
                    dest => dest.idade,
                    opt => opt.MapFrom(src => src.dataNasc.GetCurrentAge())
                );

            CreateMap<AlunoDto, Aluno>();

            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

            CreateMap<Professor, ProfessorDto>()
                .ForMember(
                    dest => dest.nome,
                    opt => opt.MapFrom(src => $"{src.nome} {src.sobreNome}")
                );

            CreateMap<ProfessorDto, Professor>();

            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();

        }
    }
}