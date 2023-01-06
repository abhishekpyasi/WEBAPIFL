using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Modelvalidation
{
    public class Ticket_EnsureDueDateisFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.owner))
            {
                if (!ticket.DueDate.HasValue)
                    return new ValidationResult("Due date is required when ticket has owner");
                else
                {
                    if (ticket.DueDate < DateTime.Now)
                        return new ValidationResult("Due date should be of future date");


                }





            }

            return ValidationResult.Success;


        }

    }

}
