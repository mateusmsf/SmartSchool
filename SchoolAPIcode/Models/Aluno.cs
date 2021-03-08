using System.Collections.Generic;

namespace SchoolAPIcode.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }

        public Aluno(int id, string nome, string sobreNome, string telefone)
        {
            this.id = id;
            this.nome = nome;
            this.sobreNome = sobreNome;
            this.telefone = telefone;

        }

        public int id { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}