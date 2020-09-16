using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Mvc.Controllers
{
    public class CadastroController : Controller
    {
        private readonly CadastroDeContato _cadastro;
        public CadastroController(CadastroDeContato cadastro)
        {
            _cadastro = cadastro;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Incluir()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir([Bind("Id,Nome,DataDoCadastro,Cep,Cpf,Telefone")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _cadastro.Add(contato);
                await _cadastro.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
    }
}