using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolAPIcode.Models;

namespace SchoolAPIcode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController() {}

        public List<Aluno> Alunos = new List<Aluno>()
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
        };



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }


        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.id == id);

            if(aluno == null) return BadRequest("Aluno não encontrado");


            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.nome.Contains(nome));

            if(aluno == null) return BadRequest("Aluno não encontrado");


            return Ok(aluno);
        }
        
    }
}