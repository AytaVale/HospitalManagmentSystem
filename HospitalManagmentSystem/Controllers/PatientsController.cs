using HospitalMS.DAL.DbModels;
using HospitalMS.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IGenericRepository<Patient> _repository;
        public PatientsController(IGenericRepository<Patient> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public List<Patient> GetList()
        {
            var response = _repository.GetList();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Patient> GetById(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _repository.GetById(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Patient> Create(Patient item)
        {

            var response = _repository.AddItem(item);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Patient> Update(int id, [FromBody] Patient obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }

            var response = _repository.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            response = _repository.Update(obj);
            return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _repository.GetById(id);
            if (response == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}