using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]//Classımıza bir davranış kazandırıyor.
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetByIdBooks([FromRoute(Name ="id")]int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))//LİNQ : Dile entegre sorgu 
                .SingleOrDefault();//Tek bir kayıt veya default değer(null). Kitap ya null olacak yada var olacak.
            if(book is null) return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody]Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name ="id")]int id, [FromBody]Book book)
        {
            //check book
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));
            if (entity is null) 
                return NotFound(); //404
            if (id != book.Id)
                return BadRequest(); //400
            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }
        [HttpDelete]
        public IActionResult DeleteAllBooks() //204 : Bu işlem okey fakat boş bir body döneceğim.
        {
            ApplicationContext
            .Books
            .Clear();
            return NoContent(); //204 
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute]int id)         {
            var entity = ApplicationContext
            .Books
            .Find(b => b.Id.Equals(id));
            if(entity is null)
                return NotFound();
            ApplicationContext.Books.Remove(entity);
            //return Ok(entity.Title + " isimli kitap başarıyla silindi"); bunu da dönebiliriz.
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateBook([FromRoute]int id, [FromBody]JsonPatchDocument<Book> bookPatch)
        {
            //check entity
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound();//404
            bookPatch.ApplyTo(entity);//NEWTONSOFTJSON PAKETİ SAYESİNDE.
            return NoContent();//204

        }
    }
}
