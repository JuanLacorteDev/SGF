using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class ReceitaVM
    {
        public Double Valor { get; set; }
        public string Descricao { get; set; }
        public bool SalarioMensal { get; set; }
        public DateTime Data_Lancamento { get; set; }

    }
}
