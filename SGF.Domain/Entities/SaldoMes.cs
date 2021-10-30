using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities
{
    public class SaldoMes : BaseEntity
    {
        public Guid MesId { get; set; }
        public double Saldo { get; set; }

        //Para o mapeamento do EF
        public Mes Mes { get; set; }
    }
}
