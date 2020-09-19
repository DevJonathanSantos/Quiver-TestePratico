using Cadastro.Entities;
using Cadastro.Interfaces;
using Cadastro.Repositories.Models.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly CadastroDeContato _cadastroDeContato;
        public CadastroRepository(CadastroDeContato cadastroDeContato)
        {
            _cadastroDeContato = cadastroDeContato;
        }
        public async Task<IList<Entities.ContatoTelefone>> ListarContatos(string searchString)
        {
            IList<ContatoTelefone> contatos = new List<ContatoTelefone>();
            IQueryable<string> telefones = from m in _cadastroDeContato.Contato
                                           orderby m.Telefone
                                           select m.Telefone;

            var contexto = from m in _cadastroDeContato.Contato select m;
            var ct = from m in _cadastroDeContato.Contato select m;

            if (string.IsNullOrEmpty(searchString))
            {
                foreach (var id in contexto.Select(s => s.IdTelefone).Distinct())
                {
                    telefones = contexto.Where(w => w.IdTelefone == id).Select(s => s.Telefone);
                    ct = contexto.Where(w => w.Id == id);

                    contatos.Add(new ContatoTelefone
                    {
                        Contato = await ct.ToListAsync(),
                        Telefones = await telefones.Distinct().ToListAsync()
                    });
                }
            }
            else
            {
                foreach (var id in contexto.Where(w => w.Nome.Contains(searchString)).Select(s => s.IdTelefone).Distinct())
                {
                    telefones = contexto.Where(w => w.IdTelefone == id).Select(s => s.Telefone);
                    ct = ct.Where(w => w.Id == id);

                    contatos.Add(new ContatoTelefone
                    {
                        Contato = await ct.ToListAsync(),
                        Telefones = await telefones.Distinct().ToListAsync()
                    });
                }
            }
            return contatos;
        }
        public async Task Cadastrar(Models.ContatoTelefone contato)
        {
            Models.Contato contato1 = null;
            int id = (from m in _cadastroDeContato.Contato orderby m.Id descending select m.Id).First();
            id++;
            foreach (var telefone in contato.Telefone)
            {
                contato1 = new Models.Contato
                {
                    Nome = contato.Nome,
                    Cpf = contato.Cpf,
                    Cep = contato.Cep,
                    IdTelefone = id,
                    Telefone = telefone
                };
                _cadastroDeContato.Add(contato1);
                await _cadastroDeContato.SaveChangesAsync();
            }
        }
    }
}
