using Odin.Data.Entities.Models;

namespace Odin.Service
{
    public interface ITicketService
    {
        Task<List<TicketModel>> GetAll();
    }
}
