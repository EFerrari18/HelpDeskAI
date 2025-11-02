using Microsoft.AspNetCore.Mvc;
using HelpDeskAI.Models;

namespace HelpDeskAI.Controllers
{
    public class UsuarioController : Controller
    {
        private static Usuario usuario = new Usuario
        {
            Nome = "Admin",
            Email = "admin@helpdesk.com",
            Telefone = "(11) 99999-9999",
            Senha = "1234"
        };

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if (email == usuario.Email && senha == usuario.Senha)
                return RedirectToAction("Index", "Dashboard");

            ViewBag.Mensagem = "E-mail ou senha incorretos!";
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            usuario = novoUsuario;
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Perfil() => View(usuario);

        [HttpPost]
        public IActionResult Atualizar(Usuario atualizado)
        {
            usuario.Nome = atualizado.Nome;
            usuario.Email = atualizado.Email;
            usuario.Telefone = atualizado.Telefone;
            if (!string.IsNullOrEmpty(atualizado.Senha))
                usuario.Senha = atualizado.Senha;

            return RedirectToAction("Perfil");
        }
    }
}
