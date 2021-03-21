using System;

namespace SchoolAPIcode.Dtos
{
    public class ProfessorRegistrarDto
    {
        public int id { get; set; }
        public int registro { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string telefone { get; set; }
        public DateTime dataInicio { get; set; } = DateTime.Now;
        public DateTime? dataFim { get; set; } = null;
        public bool ativo { get; set; } = true;
    }
}