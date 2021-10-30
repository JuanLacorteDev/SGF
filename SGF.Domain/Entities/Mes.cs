using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities
{
    public class Mes : BaseEntity
    {
        public string Nome { get; set; }
        public int Identificador_Numerico { get; set; }
        public int Ano { get; set; }

        //para mapeamento EF core N : N
        public List<DespesaMes> DespesaMeses { get; set; }
        public List<RemuneracaoMes> RemunecaoMeses { get; set; }

    }
}
