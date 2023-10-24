using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record BookDtoForUpdate(int id, String title, decimal Price); // struct : Değer tipli bir yapıya çektik. // record : ref tipli bir ifade

    //record type : İmmutable olmalıdır.

    //public int Id { get; init; }
    //public String Title { get; init; }
    //public decimal Price { get; init; }
}
