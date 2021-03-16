using System;

namespace SchoolAPIcode.Dtos
{
    public class AlunoDto
    {

        public int id { get; set; }
        public int matricula { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public int idade { get; set; }
        public DateTime dataInicio { get; set; }
        public bool ativo { get; set; }
    }
}