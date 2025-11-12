using Microsoft.AspNetCore.Mvc;
using HelpDeskAI.Models;
using HelpDeskAI.Services;

namespace HelpDeskAI.Controllers
{
    public class FaqController : Controller
    {
        private readonly GeminiService _geminiService;

        public FaqController(GeminiService geminiService)
        {
            _geminiService = geminiService;
        }

        public IActionResult Index()
        {
            // Cria o modelo vazio ao abrir a página
            return View(new FaqPergunta());
        }

        [HttpPost]
        public async Task<IActionResult> Index(FaqPergunta model)
        {
            if (!string.IsNullOrWhiteSpace(model.Pergunta))
            {
                try
                {
                    model.Resposta = await _geminiService.GetRespostaAsync(model.Pergunta);
                }
                catch (Exception ex)
                {
                    model.Resposta = "⚠️ Erro ao processar: " + ex.Message;
                }
            }
            else
            {
                model.Resposta = "Por favor, digite uma pergunta.";
            }

            // Retorna o mesmo modelo para a mesma View
            return View(model);
        }
    }
}
