namespace SchoolAPIcode.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoId, int professorId)
        {
            this.AlunoId = alunoId;
            this.ProfessorId = professorId;
        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}