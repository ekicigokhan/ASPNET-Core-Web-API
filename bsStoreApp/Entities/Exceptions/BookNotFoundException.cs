namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException// sealed : Ben bunu zırhlıyorum herhangibir şekilde kalıtılamaz.
    {
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found.")
        {

        }
    }
}
