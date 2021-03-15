using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPIcode.Data;
using SchoolAPIcode.Models;

namespace SchoolAPIcode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        private readonly IRepository _repo;
        public ProfessorController(SmartContext context, IRepository repo) {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if(_context.Professores == null) return BadRequest("Nenhum professor encontrado!");
            return Ok(_context.Professores);
        }
    
        [HttpGet("byId")] //Atribuição atravez do ?biId=1
        public IActionResult GetById(int id)
        { 
            Professor prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.id == id);
            if(prof == null) return BadRequest("Nenhum aluno encontrado com esse ID!");
            return Ok(prof);
        }

        [HttpGet("{nome}")]
        public IActionResult ByName(string nome)
        {
            Professor prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.nome.Contains(nome));
            if(prof == null) return BadRequest("Não existe nenhum professor com esse nome!");
            return Ok(prof);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            Professor prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.id == id);
            if(prof == null) return BadRequest("Não existe professor com o id informado");
            
            _repo.Update(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Professor prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.id == id);
            if(prof == null) return BadRequest("Não existe professor com esse id!");

            _repo.Delete(prof);
            if(_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }

            return BadRequest("Professor não deletado!");

        }




    }
}