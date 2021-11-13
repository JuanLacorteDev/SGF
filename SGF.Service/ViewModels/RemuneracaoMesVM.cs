using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class RemuneracaoMesVM
    {
        public Guid RemuneracaoId { get; set; }
        public Guid MesId { get; set; }

        public MesVM Mes { get; set; }
        public RemuneracaoVM Remuneracao { get; set; }
    }
}
