using HospitalMS.DAL.DbModels;
using HospitalMS.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IGenericRepository<Doctor> _repository;
        public DoctorsController(IGenericRepository<Doctor> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public List<Doctor> GetList()
        {
            var response = _repository.GetList();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Doctor> GetById(int id)

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
        public ActionResult<Doctor> Create(Doctor item)
        {

            var response = _repository.AddItem(item);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Doctor> Update(int id, [FromBody] Doctor obj)
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