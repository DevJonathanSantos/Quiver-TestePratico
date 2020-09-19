using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Interfaces
{
    public interface ICadastroRepository
    {
        public Task<IList<Entities.ContatoTelefone>> ListarContatos();
        public Task Cadastrar(Repositories.Models.ContatoTelefone contato);
    }
}
