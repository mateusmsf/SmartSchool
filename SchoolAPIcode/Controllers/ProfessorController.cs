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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public ProfessorController(IRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            /*var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));*/

            return null;
        }
    
        [HttpGet("byId")] //Atribuição atravez do ?biId=1
        public IActionResult GetById(int id)
        { 
            Professor prof = _repo.GetProfessorById(id, true);
            if(prof == null) return BadRequest("Nenhum aluno encontrado com esse ID!");
            return Ok(prof);
        }

        [HttpGet("{nome}")]
        public IActionResult ByName(string nome)
        {
            Professor prof = _repo.GetProfessorByName(nome);
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
            Professor prof = _repo.GetProfessorById(id);
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
            Professor prof = _repo.GetProfessorById(id);
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