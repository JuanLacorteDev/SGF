using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities
{
    public class Receita : BaseEntity
    {
        public Double Valor { get; set; }
        public string Descricao { get; set; }
        public bool SalarioMensal { get; set; }
        public DateTime Data_Lancamento { get; set; }

    }
}
