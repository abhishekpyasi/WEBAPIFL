using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Filters
{
    public class Ticket_EnterDateFilter : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;

            if(ticket != null &&  !string.IsNullOrWhiteSpace(ticket.owner) && ticket.EnteredDate.HasValue == false)
            {

                context.ModelState.AddModelError("EnteredDate", "EnteredDate is required");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }





        }
    }
}
