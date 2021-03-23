using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolAPIcode.Helpers;
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

        
        public async Task<PageList<Aluno>> GetAlunosAsync(PageParams pageParams, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            //join
            if(includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            //Filtros
            //Filtrando por nome
            if(!string.IsNullOrEmpty(pageParams.Nome))
                query = query.AsNoTracking().Where(aluno => aluno.nome
                                                                 .ToUpper()
                                                                 .Contains(pageParams.Nome.ToUpper())  ||
                                                            aluno.sobreNome
                                                                 .ToUpper()
                                                                 .Contains(pageParams.Nome.ToUpper()));
            //filtrando por matricula
            if(pageParams.Matricula > 0)
                query = query.AsNoTracking().Where(aluno => aluno.matricula == pageParams.Matricula);
            //Filtrando por id
            if(pageParams.id > 0)
                query = query.AsNoTracking().Where(aluno => aluno.id == pageParams.id);
            //Filtrando por disciplina
            if(pageParams.disciplinaId > 0)
            query = query.AsNoTracking()
                         .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == pageParams.disciplinaId));
            //ordenando os alunos pelo id
            query = query.AsNoTracking().OrderBy(a => a.id);

            //retornando os obj paginados de forma assincrona
            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }





        public async Task<PageList<Professor>> GetProfessoresAsync(PageParams pageParams, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            //join
            if(includeAluno)
            {
                query = query.Include(ad => ad.Disciplinas)
                             .ThenInclude(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Aluno);
            }

            //Filtros
            //Filtrando por nome
            if(!string.IsNullOrEmpty(pageParams.Nome))
                query = query.AsNoTracking().Where(porf => porf.nome
                                                                 .ToUpper()
                                                                 .Contains(pageParams.Nome.ToUpper())  ||
                                                            porf.sobreNome
                                                                 .ToUpper()
                                                                 .Contains(pageParams.Nome.ToUpper()));
            //Filtrando por id
            if(pageParams.id > 0)
                query = query.AsNoTracking().Where(porf => porf.id == pageParams.id);
            //Filtrando por disciplina
            if(pageParams.disciplinaId > 0)
            query = query.AsNoTracking()
                         .Where(porf => porf.Disciplinas.Any(ad => ad.AlunosDisciplinas
                                                        .Any(x => x.DisciplinaId == pageParams.disciplinaId)));
            //ordenando os alunos pelo id
            query = query.AsNoTracking().OrderBy(a => a.id);

            //retornando os obj paginados de forma assincrona
            return await PageList<Professor>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Aluno GetAlunoById(int id)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.AsNoTracking().Where(x => x.id == id);
            return query.FirstOrDefault();
        }

        public Professor GetProfessorById(int id)
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.AsNoTracking().Where(x => x.id == id);
            return query.FirstOrDefault();
        }

    }
}