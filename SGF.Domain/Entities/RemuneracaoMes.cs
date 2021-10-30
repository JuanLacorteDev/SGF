using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGF.Domain.Entities
{
    public class RemuneracaoMes : BaseEntity
    {
        [NotMapped]
        override public Guid Id { get; set; }

        public Guid RemuneracaoId { get; set; }
        public Guid MesId { get; set; }

        public Mes Mes { get; set; }
        public Remuneracao Remuneracao { get; set; }
    }
}
