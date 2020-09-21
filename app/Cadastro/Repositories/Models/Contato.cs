using System.ComponentModel.DataAnnotations;

namespace Cadastro.Repositories.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
    }
}
