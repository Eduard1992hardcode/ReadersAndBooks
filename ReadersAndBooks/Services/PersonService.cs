using Microsoft.Extensions.Logging;
using ReadersAndBooks.Data;
using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Services
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<PersonService> _logger;

        public PersonService(DataContext dataContext, ILogger<PersonService> logger) 
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public Person AddPerson(Person person)
        {
            _dataContext.Add(person);
            _dataContext.SaveChanges();
            return person;
        }

        public Book AddUseBook(int bookId, int personId)
        {
            var libraryCard = new LibraryCard { BookId = bookId, PersonId = personId };
            _dataContext.Add(libraryCard);
            _dataContext.SaveChanges();
            return _dataContext.Books.Find(bookId);
        }

        public bool DeletePerson(int id)
        {
           var person = _dataContext.People.Find(id);
            if (person == null)
            {
             return false;
            }
            _dataContext.People.Remove(person);
            _dataContext.SaveChanges();
            return true;
           
        }

        public void DeletePerson(string query)
        {
            var persons = _dataContext.People.Where(x => x.Name.Contains(query)
                || x.LastName.Contains(query)
                ||
         x.MiddleName.Contains(query)).ToList();
            foreach (var p in persons)
            {
                _dataContext.People.Remove(p);
            }
            _dataContext.SaveChanges();
        }

        public Book DelUseBook(int bookId, int personId)
        {
            var libraryCard = _dataContext.LibraryCards.Where(x => x.BookId == bookId
                && x.PersonId == personId).FirstOrDefault();
            _dataContext.LibraryCards.Remove(libraryCard);
            _dataContext.SaveChanges();
           return _dataContext.Books.Find(bookId);


        }

        public string GetUsersBooks(int id)
        {
            throw new NotImplementedException();
        }

        public Person UpdatePerson(Person person)
        {
            var updatePerson = _dataContext.People.Find(person.Id);
            _dataContext.People.Remove(updatePerson);
            _dataContext.People.Add(person);
            _dataContext.SaveChanges();
            return person;


        }
    }
}
