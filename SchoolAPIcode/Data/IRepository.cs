using SchoolAPIcode.Models;

namespace SchoolAPIcode.Data
{
    public interface IRepository
    {
        //Metedos Genericos 
         void Add<T>(T entity)where T : class;
         void Update<T>(T entity)where T : class;
         void Delete<T>(T entity)where T : class;
         bool SaveChanges();


        //Metodos Alunos 
         Aluno[] GetAllAlunos(bool includeProfessor = false);
         Aluno[] GetAllAlunosByDisciplinaId( int disciplinaId, bool includeProfessor = false);
         Aluno GetAlunoById( int id, bool includeProfessor = false);


         //Metodos Professores 
         Professor[] GetAllProfessores(bool includeAlunos);
         Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
         Professor GetProfessorById(int id, bool includeAluno = false);

         
    }
}