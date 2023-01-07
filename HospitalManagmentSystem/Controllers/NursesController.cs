using HospitalMS.DAL.DbModels;
using HospitalMS.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly IGenericRepository<Nurse> _repository;
        public NursesController(IGenericRepository<Nurse> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public List<Nurse> GetList()
        {
            var response = _repository.GetList();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Nurse> GetById(int id)

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
        public ActionResult<Nurse> Create(Nurse item)
        {

            var response = _repository.AddItem(item);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Nurse> Update(int id, [FromBody] Nurse obj)
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