using System.ComponentModel;

namespace Odin.Data.Entities.Enums { 

    public enum StatusTicket
    {
        [Description("Ativo")]
        Ativo,
        [Description("Em andamento")]
        EmAndamento,
        [Description("Concluído")]
        Concluido,
        [Description("Cancelado")]
        Cancelado
    }
}
