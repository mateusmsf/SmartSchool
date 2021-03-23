using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolAPIcode.Helpers;
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
         Task<PageList<Aluno>> GetAlunosAsync(PageParams pageParams, bool includeProfessor = false);
         Aluno GetAlunoById(int id);
    
         
         //Metodos Professores 
          Task<PageList<Professor>> GetProfessoresAsync(PageParams pageParams, bool includeAluno = false);
          Professor GetProfessorById(int id);
      

         
    }
}