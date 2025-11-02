using Microsoft.AspNetCore.Mvc;
using HelpDeskAI.Models;
using System.Collections.Generic;
using System.Linq;

namespace HelpDeskAI.Controllers
{
    public class DashboardController : Controller
    {
        //  "Banco de dados" em memória
        private static List<Chamado> chamados = new List<Chamado>();

        //  Acesso global para outros controllers
        public static List<Chamado> GetChamados() => chamados;

        public static void AdicionarChamado(Chamado chamado)
        {
            chamado.Id = chamados.Count + 1;
            chamados.Add(chamado);
        }

        //  Exibe dashboard com gráfico
        public IActionResult Index()
        {
            int pendentes = chamados.Count(c => c.Status == "Pendente");
            int andamento = chamados.Count(c => c.Status == "Em andamento");
            int finalizados = chamados.Count(c => c.Status == "Finalizado");

            ViewBag.Pendentes = pendentes;
            ViewBag.Andamento = andamento;
            ViewBag.Finalizados = finalizados;

            return View(chamados);
        }
    }
}
