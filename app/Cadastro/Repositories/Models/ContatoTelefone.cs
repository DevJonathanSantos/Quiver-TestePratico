using Cadastro.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Repositories.Models
{
    public class ContatoTelefone
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatorio!")]
        public string Nome { get; set; }
        [CepAttribute(ErrorMessage = "O CEP informado não é valido!")]
        public string Cep { get; set; }
        [CpfAttribute(ErrorMessage = "O CPF informado não é valido!")]
        public string Cpf { get; set; }
        public int IdTelefone { get; set; }
        [TelefoneAttribute(ErrorMessage ="O telefone informado não é valido!")]
        public List<string> Telefone { get; set; }
    }
}
