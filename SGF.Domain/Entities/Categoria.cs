using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public Guid? UserId { get; set; }

        //Para mapeamento EF core
        public List<Despesa> Despesas { get; set; }

    }
}
