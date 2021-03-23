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
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var alunos = await _repo.GetAlunosAsync(pageParams, true);

            var alunosResult = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

            Response.AddPagination(alunos.CurrentPage, 
                                   alunos.PageSize, 
                                   alunos.TotalCount, 
                                   alunos.TotalPage
            );

            return Ok(alunosResult);
        }


        [HttpPost]
        public IActionResult Post([FromBody] AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado!");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não alterado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(aluno, model);

            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não alterado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if(_repo.SaveChanges())
            {
                return Ok("Aluno Excluido!");
            }

            return BadRequest("Aluno não Deletado!");
            
            
        }
        
        
    }
}