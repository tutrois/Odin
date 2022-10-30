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
    }
}
