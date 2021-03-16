using System;
using System.Collections.Generic;

namespace SchoolAPIcode.Models
{
    public class Disciplina
    {
        public Disciplina()
        {

        }

        public Disciplina(int id, string nome, int professorId, int CursoId)
        {
            this.id = id;
            this.nome = nome;
            this.ProfessorId = professorId;
            this.CursoId = CursoId;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public Disciplina Prerequisito { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}