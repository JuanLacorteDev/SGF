using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SGF.Application.ViewModels.Entidades
{
    public class CategoriaAdicionarVM
    {
        public CategoriaAdicionarVM()
        {
            Data_Cadastro = DateTime.Now;
        }

        public string Nome { get; set; }
        public Guid? UserId { get; set; }

        [JsonIgnore]
        public DateTime Data_Cadastro { get; set; }
    }
}
