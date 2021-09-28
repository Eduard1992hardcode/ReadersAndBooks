using Microsoft.AspNetCore.Mvc;
using ReadersAndBooks.Models;
using ReadersAndBooks.Services;
using System.Threading.Tasks;

namespace ReadersAndBooks.Controllers
{
    [Route("api/[personsController]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService) 
        { 
            _personService = personService;
        }

        [HttpPost("api/addPerson")]
        public IActionResult AddPerson(Person person)
        {
            _personService.AddPerson(person);
            return Ok(person);
        }

        [HttpPost("api/updatePerson")]
        public IActionResult UpdatePerson(Person person)
        {
            _personService.UpdatePerson(person);
            return Ok(person);
        }
        
        [HttpDelete("api/deletePerson")]
        public IActionResult DeletePerson(int id)
        {
            _personService.DeletePerson(id);
            return Ok("Запись удалена");
        }

        [HttpDelete("api/deletePersonByQuery")]
        public IActionResult DeletePerson(string query) 
        {
            _personService.DeletePerson(query);
            return Ok();
        }

        [HttpGet("api/getUsersBooks")]
        public async Task<IActionResult> GetUsersBooks(int id) 
        {
            return Ok(await _personService.GetUsersBooks(id));
        }

        [HttpPost("api/addUseBook")]
        public IActionResult AddUseBook(int bookId, int personId)
        {
            _personService.AddUseBook(bookId, personId);
            return Ok();
        }

        [HttpDelete("api/delUseBook")]
        public IActionResult DelUseBook(int bookId, int personId)
        {
            _personService.DelUseBook(bookId, personId);
            return Ok();
        }
    }
}
