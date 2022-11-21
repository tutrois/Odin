using Microsoft.EntityFrameworkCore;
using Odin.Data.Database;
using Odin.Data.Entities.Models;

namespace Odin.Service
{
    public class TicketService : ITicketService
    {
        private readonly OdinDBContex _dbContex;

        public TicketService(OdinDBContex odinDBContex)
        {
            _dbContex = odinDBContex;
        }

        public async Task<List<TicketModel>> GetAll()
        {
            return await _dbContex.Tickets.OrderBy(e => e.CreatedOn).ToListAsync();
        }

        public async Task<TicketModel> Add(TicketModel ticket)
        {
            await _dbContex.Tickets.AddAsync(ticket);
            await _dbContex.SaveChangesAsync();

            return ticket;
        }

        public async Task<TicketModel> GetById(Guid ticketId)
        {
            var ticket = await _dbContex.Tickets.FirstOrDefaultAsync(e => e.Id == ticketId);

            if (ticket == null)
            {
                throw new Exception($"o Chamado não foi encontrado, pois o ID: {ticketId} não existe no banco de dados.");
            }

            return ticket;
        }

        public async Task<TicketModel> Update(TicketModel uTicket, Guid id)
        {
            TicketModel ticket = await GetById(id);

            ticket.Status = uTicket.Status;

            _dbContex.Tickets.Update(ticket);
            await _dbContex.SaveChangesAsync();

            return ticket;
        }
    }
}
