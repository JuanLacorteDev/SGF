using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class DespesaCategoriasMesesVM
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Double Valor { get; set; }
        public Guid CategoriaId { get; set; }


        //para mapeamento EF core
        public List<DespesaMesVM> DespesaMeses { get; set; }
        public CategoriaDespesasVM Categoria { get; set; }

    }
}
