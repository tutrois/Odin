using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Odin.Data.Entities.Models;

namespace Odin.Data.Database.Maps
{
    public class TicketMap : IEntityTypeConfiguration<TicketModel>
    {
        public void Configure(EntityTypeBuilder<TicketModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number).IsRequired().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
