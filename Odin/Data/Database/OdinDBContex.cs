using Microsoft.EntityFrameworkCore;
using Odin.Data.Entities.Models;
using Odin.Data.Database.Maps;

namespace Odin.Data.Database
{
    public class OdinDBContex : DbContext
    {
        public OdinDBContex(DbContextOptions<OdinDBContex> options) : base(options)
        {

        }

        public DbSet<TicketModel> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TicketMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
