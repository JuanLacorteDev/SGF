using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class MesVM
    {
        public string Nome { get; set; }
        public int Identificador_Numerico { get; set; }
        public int Ano { get; set; }

        //para mapeamento EF core N : N
        public List<DespesaMesVM> DespesaMeses { get; set; }
        public List<RemuneracaoMesVM> RemunecaoMeses { get; set; }
    }
}
