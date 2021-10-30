using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGF.Domain.Entities
{
    public class DespesaMes : BaseEntity
    {
        [NotMapped]
        override public Guid Id { get; set; }

        public Guid MesId { get; set; }
        public Guid DespesaId { get; set; }

        //Propriedades para mapeamento relacional N : N
        public Despesa Despesa { get; set; }
        public Mes Mes { get; set; }

    }
}
