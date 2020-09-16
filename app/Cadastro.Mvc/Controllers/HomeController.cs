using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cadastro.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CadastroDeContato _cadastro;

        public HomeController(ILogger<HomeController> logger
            , CadastroDeContato cadastro)
        {
            _logger = logger;
            _cadastro = cadastro;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _cadastro.Contato.ToListAsync());
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
