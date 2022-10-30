using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Odin.Data.Entities.Enums;

namespace Odin.Data.Entities.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatorio")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatorio")]
        [StringLength(1000)]
        public string Description { get; set; }

        [DefaultValue(StatusTicket.Ativo)]
        public StatusTicket Status { get; set; }
        
        [DisplayFormat(DataFormatString = "MM/dd/yyyy hh:mm")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
