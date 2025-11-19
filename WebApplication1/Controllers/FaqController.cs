using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HelpDeskAI.Controllers
{
    public class FaqController : Controller
    {
        private readonly Dictionary<string, string> respostas = new()
        {
            { "senha", "Para recuperar sua senha, clique em 'Esqueci minha senha' na página de login." },
            { "login", "Se não conseguir acessar, verifique seu e-mail e senha ou contate o suporte." },
            { "erro",  "Erros podem ocorrer por instabilidade. Reinicie o navegador e tente novamente." },
            { "chamado", "Para abrir um chamado, vá em 'Abrir Chamado' no menu lateral." },
            { "suporte", "Nosso suporte funciona 24h para chamados críticos." }
        };

        public IActionResult Index(string busca)
        {
            ViewBag.Busca = busca;

            if (!string.IsNullOrEmpty(busca))
            {
                busca = busca.ToLower();

                var resposta = respostas
                    .Where(x => busca.Contains(x.Key))
                    .Select(x => x.Value)
                    .FirstOrDefault();

                ViewBag.Resposta = resposta ?? "Nenhuma resposta encontrada. Tente mudar a pergunta!";
            }

            return View();
        }
    }
}
