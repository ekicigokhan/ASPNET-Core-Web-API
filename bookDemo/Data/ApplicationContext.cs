using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext //static : bellekte bu alana bir veri koyacağız ve bu alana her kim ulaşıorsa ulaşsın buradaki değişiklikleri doğrudan gözlemlemiş olacak.
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1, Title="Ben Öteki ve Ötesi", Price=75},
                new Book(){Id=2, Title="Mor ve Ötesi", Price=115},
                new Book(){Id=3, Title="Ben Kimim ?", Price=165},
            };
        }
    }
}
