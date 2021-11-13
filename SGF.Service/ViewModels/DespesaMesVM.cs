using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class DespesaMesVM
    {
        public Guid MesId { get; set; }
        public Guid DespesaId { get; set; }

        //Propriedades para mapeamento relacional N : N
        public DespesaCategoriasMesesVM Despesa { get; set; }
        public MesVM Mes { get; set; }
    }
}
