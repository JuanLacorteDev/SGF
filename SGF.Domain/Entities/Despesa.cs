﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities
{
    public class Despesa : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Double Valor { get; set; }
        public Guid CategoriaId { get; set; }



        //para mapeamento EF core
        public List<DespesaMes> DespesaMeses { get; set; }
        public Categoria Categoria { get; set; }

    }
}