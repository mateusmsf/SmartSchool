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

        public AlunoController(SmartContext context) {
            _context = context;
        }

        /*public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                id = 1,
                nome = "Mateusa",
                sobreNome = "oliveira",
                telefone = "12345"
            },

            new Aluno(){
                id = 2,
                nome = "Silva",
                sobreNome = "lucas",
                telefone = "12345"
            },

            new Aluno(){
                id = 3,
                nome = "França",
                sobreNome = "carlos",
                telefone = "12345"
            }
        };*/



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
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
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
            _context.Remove(alu);
            _context.SaveChanges();
            return Ok();
            
            
        }
        
        
    }
}