using Cadastro.Interfaces;
using Cadastro.Repositories.Models;
using Cadastro.Repositories.Models.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly CadastroDeContato _cadastro;
        public CadastroRepository(CadastroDeContato cadastro)
        {
            _cadastro = cadastro;
        }
        public async Task<IList<Entities.ContatoTelefone>> ListarContatos(string searchString)
        {
            IList<Entities.ContatoTelefone> contatos = new List<Entities.ContatoTelefone>();
            IQueryable<string> telefones = from m in _cadastro.Telefone
                                           orderby m.Numero
                                           select m.Numero;

            var contexto = from m in _cadastro.Contato select m;
            var contato = from m in _cadastro.Contato select m;
            var telefone = from m in _cadastro.Telefone select m;

            if (string.IsNullOrEmpty(searchString))
            {
                foreach (var id in contato.Select(s => s.Id).Distinct())
                {
                    contato = contexto.Where(w => w.Id == id).Select(s => s);
                    telefones = telefone.Where(w => w.IdTelefone == id).Select(s => s.Numero);

                    contatos.Add(new Entities.ContatoTelefone
                    {
                        Contato = await contato.ToListAsync(),
                        Telefones = await telefones.Distinct().ToListAsync()
                    });
                }
            }
            else
            {
                foreach (var id in contato.Where(w => w.Nome.Contains(searchString)).Select(s => s.Id).Distinct())
                {
                    contato = contato.Where(w => w.Id == id);

                    telefones = telefone.Where(w => w.IdTelefone == id).Select(s => s.Numero);

                    contatos.Add(new Entities.ContatoTelefone
                    {
                        Contato = await contato.ToListAsync(),
                        Telefones = await telefones.Distinct().ToListAsync()
                    });
                }
            }
            return contatos;
        }
        public async Task Cadastrar(Models.ContatoTelefone ct)
        {
            Models.Contato contato = null;
            Models.Telefone telefone = null;


            contato = new Models.Contato
            {
                Nome = ct.Nome,
                Cpf = ct.Cpf,
                Cep = ct.Cep,
            };
            _cadastro.Add(contato);
            await _cadastro.SaveChangesAsync();

            int id = (from m in _cadastro.Contato orderby m.Id descending select m.Id).First();

            foreach (var numero in ct.Telefone)
            {
                if (string.IsNullOrEmpty(numero))
                    continue;
                telefone = new Telefone
                {
                    IdTelefone = id,
                    Numero = numero
                };
                _cadastro.Add(telefone);
                await _cadastro.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var contato = await _cadastro.Contato.FindAsync(id);
            _cadastro.Contato.Remove(contato);
            await _cadastro.SaveChangesAsync();

            var telefone = await _cadastro.Telefone.FindAsync(id);
            _cadastro.Telefone.Remove(telefone);
            await _cadastro.SaveChangesAsync();
        }
    }
}
