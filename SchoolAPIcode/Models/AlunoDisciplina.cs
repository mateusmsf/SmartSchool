using System;

namespace SchoolAPIcode.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
        }

        public DateTime dataInicio { get; set; } = DateTime.Now;
        public DateTime? dataFim { get; set; } = null;
        public int? nota { get; set; } = null;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}