using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels
{
    public class ReceitaVM
    {
        public Guid MesId { get; set; }
        public Double Valor { get; set; }
        public string Descricao { get; set; }
        public bool SalarioMensal { get; set; }
        public Guid? MesInicioId { get; set; }

    }
}
