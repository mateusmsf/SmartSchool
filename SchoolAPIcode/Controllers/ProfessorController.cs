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
            var professor = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professor));
        }
    
        [HttpGet("byId")] //Atribuição atravez do ?biId=1
        public IActionResult GetById(int id)
        { 
            Professor prof = _repo.GetProfessorById(id, true);
            if(prof == null) return BadRequest("Nenhum aluno encontrado com esse ID!");
            return Ok(_mapper.Map<ProfessorDto>(prof));
        }

        [HttpGet("{nome}")]
        public IActionResult ByName(string nome)
        {
            Professor prof = _repo.GetProfessorByName(nome);
            if(prof == null) return BadRequest("Não existe nenhum professor com esse nome!");
            return Ok(_mapper.Map<ProfessorDto>(prof));
        }

        [HttpPost]
        public IActionResult Post(ProfessorDto model)
        {
            Professor professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if(_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            Professor prof = _repo.GetProfessorById(id);
            if(prof == null) return BadRequest("Não existe professor com o id informado");
            
            _mapper.Map(model, prof);

            _repo.Update(prof);
            if(_repo.SaveChanges())
            {
                return Ok(prof);
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