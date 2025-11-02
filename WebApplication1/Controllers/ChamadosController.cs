using Microsoft.AspNetCore.Mvc;
using HelpDeskAI.Models;
using System.Linq;

namespace HelpDeskAI.Controllers
{
    public class ChamadosController : Controller
    {
        //  Tela de abertura
        public IActionResult Abrir() => View();

        [HttpPost]
        public IActionResult Abrir(Chamado chamado)
        {
            chamado.NomeUsuario = "Administrador";
            chamado.Status = "Pendente";
            DashboardController.AdicionarChamado(chamado);
            return RedirectToAction("Index", "Dashboard");
        }

        //  Tela de detalhes
        public IActionResult Detalhes(int id)
        {
            var chamado = DashboardController.GetChamados().FirstOrDefault(c => c.Id == id);
            if (chamado == null)
                return NotFound();

            return View(chamado);
        }

        //  Atualiza o status via AJAX
        [HttpPost]
        public IActionResult AtualizarStatus(int id, string status)
        {
            var chamado = DashboardController.GetChamados().FirstOrDefault(c => c.Id == id);
            if (chamado != null)
                chamado.Status = status;

            return Ok();
        }
    }
}
