using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGF.Domain.Entities
{
    public class DespesaMes : BaseEntity
    {
        [NotMapped]
        public static new Guid Id { get; set; }

        public Guid MesId { get; set; }
        public Guid DespesaId { get; set; }

        //Propriedades para mapeamento relacional N : N
        public Despesa Despesa { get; set; }
        public Mes Mes { get; set; }

    }
}
