using System.Text.Json.Serialization;
using System;

namespace SGF.Application.ViewModels.Entidades
{
    public class CategoriaListarVM
    {
        public CategoriaListarVM()
        {
            Data_Cadastro = DateTime.Now;
        }

        public string Nome { get; set; }
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }

        [JsonIgnore]
        public DateTime Data_Cadastro { get; set; }
    }
}
