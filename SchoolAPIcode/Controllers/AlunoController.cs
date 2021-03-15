using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPIcode.Data;
using SchoolAPIcode.Models;

namespace SchoolAPIcode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        private readonly IRepository _repo;

        public AlunoController(SmartContext context, IRepository repo) {
            _context = context;
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }


        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.id == id);

            if(aluno == null) return BadRequest("Aluno não encontrado");


            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.nome.Contains(nome));

            if(aluno == null) return BadRequest("Aluno não encontrado");


            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não alterado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _context.Alunos.FirstOrDefault(a => a.id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(alu);
            if(_repo.SaveChanges())
            {
                return Ok("Aluno Excluido!");
            }

            return BadRequest("Aluno não Deletado!");
            
            
        }
        
        
    }
}