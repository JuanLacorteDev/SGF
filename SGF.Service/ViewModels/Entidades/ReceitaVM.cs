using System;

namespace SGF.Application.ViewModels.Entidades
{
    public class ReceitaVM
    {
        public Double Valor { get; set; }
        public string Descricao { get; set; }
        public bool SalarioMensal { get; set; }
        public DateTime Data_Lancamento { get; set; }

    }
}
