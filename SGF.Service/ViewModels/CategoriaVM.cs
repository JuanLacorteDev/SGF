using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class CategoriaVM
    {
        public string Nome { get; set; }
        public DateTime Data_Cadastro { get; set; }

        //Para mapeamento EF core
        public List<DespesaVM> Despesas { get; set; }
    }
}
