using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPIcode.Data;
using SchoolAPIcode.Dtos;
using SchoolAPIcode.Models;

namespace SchoolAPIcode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }


        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, true);

            if(aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(_mapper.Map<AlunoDto>(aluno));
        }

        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _repo.GetAlunoByName(nome, true);

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
            var alu = _repo.GetAlunoById(id);
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
            var alu = _repo.GetAlunoById(id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não alterado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAlunoById(id);
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