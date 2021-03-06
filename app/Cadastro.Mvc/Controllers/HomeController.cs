﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Interfaces;
using Cadastro.Mvc.Models;
using Cadastro.Repositories.Models;
using Cadastro.Repositories.Models.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cadastro.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICadastroRepository _cadastroRepository;
        private readonly CadastroDeContato _cadastro;

        public HomeController(ILogger<HomeController> logger
            , ICadastroRepository cadastroRepository)
        {
            _logger = logger;
            _cadastroRepository = cadastroRepository;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var contato = _cadastroRepository.ListarContatos(searchString);
            return View(await contato);
        }
        public IActionResult Incluir()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir([Bind("Id,Nome,Cep,Cpf,IdTelefone,Telefone")] ContatoTelefone contato)
        {
            if (ModelState.IsValid)
            {
                await _cadastroRepository.Cadastrar(contato);
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _cadastroRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
