using System;
using System.Collections.Generic;

namespace SchoolAPIcode.Models
{
    public class Professor
    {
        public Professor() {}

        public Professor(int id, int registro, string nome, string sobreNome)
        {
            this.id = id;
            this.registro = registro;
            this.nome = nome;
            this.sobreNome = sobreNome;

        }
        public int id { get; set; }
        public int registro { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string telefone { get; set; }
        public DateTime dataInicio { get; set; } = DateTime.Now;
        public DateTime? dataFim { get; set; } = null;
        public bool ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }

    }
}