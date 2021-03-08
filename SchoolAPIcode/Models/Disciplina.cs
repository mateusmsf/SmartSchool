using System.Collections.Generic;

namespace SchoolAPIcode.Models
{
    public class Disciplina
    {
        public Disciplina()
        {

        }

        public Disciplina(int id, string nome, int professorId)
        {
            this.id = id;
            this.nome = nome;
            this.ProfessorId = professorId;
        }
        public int id { get; set; }
        public string nome { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}