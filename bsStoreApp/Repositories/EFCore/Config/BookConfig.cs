using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Gökhan ve Ekrem", Price = 85 },
                new Book { Id = 2, Title = "Elif", Price = 165 },
                new Book { Id = 3, Title = "Devlet", Price = 785 }
                ); //params istiyor : params bir dizi gibi istediğimiz kadar parametre geçmemize olanak sağlar.
        }
    }
}
