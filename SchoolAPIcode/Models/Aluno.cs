using System;
using System.Collections.Generic;

namespace SchoolAPIcode.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }

        public Aluno(int id, 
                     int matricula, 
                     string nome, 
                     string sobreNome, 
                     string telefone, 
                     DateTime dataNasc)
        {
            this.id = id;
            this.matricula = matricula;
            this.nome = nome;
            this.sobreNome = sobreNome;
            this.telefone = telefone;
            this.dataNasc = dataNasc;

        }

        public int id { get; set; }
        public int matricula { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string telefone { get; set; }
        public DateTime dataNasc { get; set; }
        public DateTime dataInicio { get; set; } = DateTime.Now;
        public DateTime? dataFim { get; set; } = null;
        public bool ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}