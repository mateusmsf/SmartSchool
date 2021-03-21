using System;

namespace SchoolAPIcode.Dtos
{
    public class ProfessorDto
    {
        public int id { get; set; }
        public int registro { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public DateTime dataInicio { get; set; }
        public bool ativo { get; set; } = true;
    }
}