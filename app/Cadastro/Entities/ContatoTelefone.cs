using Cadastro.Repositories.Models;
using System.Collections.Generic;

namespace Cadastro.Entities
{
    public class ContatoTelefone
    {
        public List<Contato> Contato { get; set; }
        public List<string> Telefones { get; set; }
    }
}
