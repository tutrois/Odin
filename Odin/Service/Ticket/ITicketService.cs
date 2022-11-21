using Odin.Data.Entities.Models;

namespace Odin.Service
{
    public interface ITicketService
    {
        Task<List<TicketModel>> GetAll();
        Task<TicketModel> Add(TicketModel usuario);
        Task<TicketModel> GetById(Guid ticketId);
    }
}
