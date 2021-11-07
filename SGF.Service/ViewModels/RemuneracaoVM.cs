using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class RemuneracaoVM
    {
        public Guid MesId { get; set; }
        public Double Valor { get; set; }
        public string Descricao { get; set; }

        //para mapping EF core
        public List<RemuneracaoMesVM> RemuneracaoMeses { get; set; }
    }
}
