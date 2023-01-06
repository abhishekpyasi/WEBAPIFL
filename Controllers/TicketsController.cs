using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Filters;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    public class TicketsController : ControllerBase
    {

        [HttpGet]
        [Route("/api/tickets")]

        public IActionResult Get()
        {
            return Ok("Reading all tickets");
        }

        [HttpGet]

        [Route("/projects/{pid}/tickets/{tid}")]

        public IActionResult Get(int pid , [FromQuery] int tid)
        {
            return Ok($"Reading  project # {pid} and ticket {tid} ");
        }

        [HttpPost]
        [Route("/api/tickets")]

        public IActionResult Create([FromBody] Ticket ticket)

        { return Ok(ticket); }

        [HttpPost]
        [Route("/api/v2/tickets")]
        [Ticket_EnterDateFilter]
        public IActionResult Createv2([FromBody] Ticket ticket)

        { return Ok(ticket); }


        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]  

        public IActionResult GetProjectTicket([FromQuery] Ticket ticket)
        {
            if(ticket.TicketId ==0)
            return Ok($"Reading  all tickets belong to project {ticket.ProjectId} ");
            else
                return Ok( $"  tickets belong to project {ticket.ProjectId} and ticket  {ticket.TicketId} and desc {ticket.TicketDescription}");
        }


    }
}
