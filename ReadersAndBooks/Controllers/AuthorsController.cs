using Microsoft.AspNetCore.Mvc;
using ReadersAndBooks.Models;
using ReadersAndBooks.Services;

namespace ReadersAndBooks.Controllers
{
    [Route("api/[authorsController]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        { 
            _authorService = authorService;
        }

        [HttpGet("api/getAuthors")]
        public IActionResult GetAuthors()
        {
            return Ok(_authorService.GetAuthors());

        }

        [HttpPost("api/addAuthor")]
        public IActionResult AddAuthor(Author author)
        {
            _authorService.AddAuthor(author);
            return Ok(author);
        }

        [HttpDelete("api/deleteAuthor")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
            return Ok();
        }
    }
}
