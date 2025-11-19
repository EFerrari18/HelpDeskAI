using HelpDeskAI.Data;
using HelpDeskAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAI.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChamadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _context.Chamado.ToListAsync();
            return View(lista);
        }

        public IActionResult Abrir()
        {
            ViewBag.Categorias = _context.Categoria.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Abrir(Chamado c)
        {
            c.DataAbertura = DateTime.Now;
            c.Status = "Aberto";

            _context.Chamado.Add(c);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AtualizarStatus(int id, string status)
        {
            var chamado = await _context.Chamado.FindAsync(id);

            if (chamado != null)
            {
                chamado.Status = status;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Detalhes", new { id });
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var chamado = await _context.Chamado.FirstOrDefaultAsync(c => c.Id == id);
            return View(chamado);
        }
    }
}
