using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolAPIcode.Models;

namespace SchoolAPIcode.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }



        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }






        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.id);
            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }
            
            query = query.AsNoTracking()
                         .OrderBy(a => a.id)
                         .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int id,
                                  bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().Where(aluno => aluno.id == id);
            return query.FirstOrDefault();
        }




        public Professor[] GetAllProfessores(bool includeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includeAlunos)
            {
                query = query.Include(ad => ad.Disciplinas)
                             .ThenInclude(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includeAlunos)
            {
                query = query.Include(ad => ad.Disciplinas)
                             .ThenInclude(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Aluno);
            }
            
            query = query.AsNoTracking()
                         .OrderBy(a => a.id)
                         .Where(aluno => aluno.Disciplinas.Any(
                                d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId)));

            return query.ToArray();
        }

        public Professor GetProfessorById(int id,
                                          bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includeAluno)
            {
                query = query.Include(ad => ad.Disciplinas)
                             .ThenInclude(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Aluno);
            }
            query = query.AsNoTracking().Where(professor => professor.id == id);
            return query.FirstOrDefault();
        }
    }
}