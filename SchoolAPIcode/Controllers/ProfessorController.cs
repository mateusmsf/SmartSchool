using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPIcode.Data;
using SchoolAPIcode.Dtos;
using SchoolAPIcode.Helpers;
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
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var professores = await _repo.GetProfessoresAsync(pageParams, true);

            var profResult = _mapper.Map<IEnumerable<ProfessorDto>>(professores);

            Response.AddPagination(professores.CurrentPage, 
                                   professores.PageSize, 
                                   professores.TotalCount, 
                                   professores.TotalPage
            );

            return Ok(profResult);
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
            var prof = _repo.GetProfessorById(id);
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
            var prof = _repo.GetProfessorById(id);
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