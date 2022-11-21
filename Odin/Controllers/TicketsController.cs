using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odin.Data.Entities.Enums;
using Odin.Data.Entities.Models;
using Odin.Service;
using System.Collections.Generic;
using System.Net.Sockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Odin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/<TicketsController>
        [HttpGet]
        public async Task<ActionResult<List<TicketModel>>> GetAll()
        {
            List<TicketModel> result = await _ticketService.GetAll();

            return Ok(result);
        }


        //// POST api/<TicketsController>
        [HttpPost]
        public async Task<ActionResult<TicketModel>> Add([FromBody] TicketModel ticket)
        {
            TicketModel result = await _ticketService.Add(ticket);
            return Ok(result);
        }

        //// GET api/<TicketsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketModel>> Get(Guid id)
        {
            var result = await _ticketService.GetById(id);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TicketModel>> Atualizar([FromBody] TicketModel tarefa, Guid id)
        {
            if(tarefa == null)
            {
                return BadRequest();
            }

            TicketModel result = await _ticketService.Update(tarefa, id);
            return Ok(result);
        }

        //// POST api/<TicketsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// DELETE api/<TicketsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
