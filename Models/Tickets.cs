using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Modelvalidation;

namespace WebAPI.Models
{
    public class Ticket
    {
        public string TicketDescription { get; set; }
        public string Title { get; set; }

/*        [FromQuery(Name="tid")]
*/
       [Required]
        public int? TicketId { get; set; }
        
/*        [FromRoute(Name = "pid")]
*/      [Required]
        public int? ProjectId { get; set; }

        public string owner { get; set; }
        [Ticket_EnsureDueDateisFuture]
        [Ticket_EnsureDueDateForOwner]
        public DateTime? DueDate { get; set; }

        public DateTime? EnteredDate { get; set; }

    }
}
