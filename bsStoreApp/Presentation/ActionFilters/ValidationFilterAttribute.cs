using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) //Çalışmadan hemen önce
        {
            var controller = context.RouteData.Values["controller"]; //HANGİ CONTROLLER ?
            var action = context.RouteData.Values["action"]; //HANb Gİ METODUN ÇALIŞTIĞINI ÖĞRENMEK

            //DTO

            var param = context.ActionArguments
                .SingleOrDefault(p => p.Value.ToString().Contains("Dto")).Value;
            // parametre listesi üzerinden bir parametreye ihtiyacım var ve bu parametrenin ToString üzerinden 
            // Dto içermesini istiyorum. Çünkü isimlendirmeleri böyle verdim.

            if(param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. " +
                    $"Controller : {controller}" + 
                    $"Action : {action}");
                return; //void döner.
            }
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState); // 422
        }
    }
}
