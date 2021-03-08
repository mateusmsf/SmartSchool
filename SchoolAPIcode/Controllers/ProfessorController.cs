using Microsoft.AspNetCore.Mvc;

namespace SchoolAPIcode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() {}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: Mateus, Moises, Davi, Paula, Jose");
        }
        
    }
}