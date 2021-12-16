using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels.Entidades
{
    public class CategoriaDespesasVM
    {
        public string Nome { get; set; }
        public DateTime Data_Cadastro { get; set; }

        //Para mapeamento EF core
        public List<DespesaAdicionarVM> Despesas { get; set; }
    }
}
