using app11.BAL;
using app11.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace app11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ProfessorsBal _professorsBusiness;

        public ProfessorsController(ProfessorsBal professorsBusiness)
        {
            _professorsBusiness = professorsBusiness;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var professors = _professorsBusiness.GetProfessors();

            return Ok(professors);
        }       

        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessorById(int id)
        {
            var professor = _professorsBusiness.GetProfessorById(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public ActionResult<Professor> AddProfessor([FromBody]Professor professor)
        {
            var createdProfessor = _professorsBusiness.AddProfessor(professor);

            return Created(string.Empty, createdProfessor);
        }

    
    }

}