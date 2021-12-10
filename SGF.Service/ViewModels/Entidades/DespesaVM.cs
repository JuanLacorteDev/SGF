using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels.Entidades
{
    public class DespesaVM
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Double Valor { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
