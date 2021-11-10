using System.Text.Json.Serialization;
using System;

namespace SGF.Application.ViewModels
{
    public class CategoriaVM
    {
        public CategoriaVM()
        {
            Data_Cadastro = DateTime.Now;
        }

        public string Nome { get; set; }
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime Data_Cadastro { get; set; }
    }
}
