using HelpDeskAI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Pendentes = await _context.Chamado.CountAsync(c => c.Status == "Aberto");
            ViewBag.Andamento = await _context.Chamado.CountAsync(c => c.Status == "Em andamento");
            ViewBag.Finalizados = await _context.Chamado.CountAsync(c => c.Status == "Finalizado");

            var lista = await _context.Chamado
                .OrderByDescending(c => c.DataAbertura)
                .Take(10)
                .ToListAsync();

            return View(lista);
        }
    }
}
