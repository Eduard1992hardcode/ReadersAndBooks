using Microsoft.AspNetCore.Mvc;
using ReadersAndBooks.Models;
using ReadersAndBooks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersAndBooks.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService) { _personService = personService; }

        [HttpPost("api/")]
        public IActionResult AddPerson(Person person)
        {
            _personService.AddPerson(person);
            return Ok(person);
        }

        public IActionResult UpdatePerson(Person person)
        {
            _personService.UpdatePerson(person);
            return Ok(person);
        }


        public IActionResult DeletePerson(int id)
        {
            _personService.DeletePerson(id);
            return Ok("Запись удалена");
        }


        public IActionResult DeletePerson(string query) 
        {
            _personService.DeletePerson(query);
            return Ok();
        }

        public async Task<IActionResult> GetUsersBooks(int id) 
        {
            return Ok(await _personService.GetUsersBooks(id));
           
        }

        
        public IActionResult AddUseBook(int bookId, int personId)
        {
            _personService.AddUseBook(bookId, personId);
            return Ok();
        }

        
        public IActionResult DelUseBook(int bookId, int personId)
        {
            _personService.DelUseBook(bookId, personId);
            return Ok();
        }
    }
}
