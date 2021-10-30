using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities
{
    public class Remuneracao : BaseEntity
    {
        public Guid MesId { get; set; }
        public Double Valor { get; set; }
        public string Descricao { get; set; }

        //para mapping EF core
        public List<RemuneracaoMes> RemuneracaoMeses { get; set; }

    }
}
