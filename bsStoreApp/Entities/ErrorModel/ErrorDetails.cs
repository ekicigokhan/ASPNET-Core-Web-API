using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } //Bazı hatalarda message ifadesi boş olabilir.
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);//Classın tamamını ilgilendiren bir işlem için this kullanılabilir.
        }
    }
}
