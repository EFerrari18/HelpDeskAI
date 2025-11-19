using HelpDeskAI.Data;
using HelpDeskAI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HelpDeskAI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ============================
        // LOGIN GET
        // ============================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var user = await _context.Usuario
                .FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha);

            if (user == null)
            {
                ViewBag.Erro = "E-mail ou senha incorretos!";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Perfil ?? "usuario")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // redireciona por perfil
            if (user.Perfil == "admin" || user.Perfil == "gestor")
                return RedirectToAction("Index", "Dashboard");

            return RedirectToAction("MeusChamados", "Chamados");
        }

        // ============================
        // LOGOUT
        // ============================
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        // ============================
        // LISTAR (apenas admin)
        // ============================
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // ============================
        // CADASTRAR GET
        // ============================
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        // CADASTRAR POST
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Usuario u)
        {
            _context.Usuario.Add(u);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        // ============================
        // EDITAR GET
        // ============================
        public async Task<IActionResult> Editar(int id)
        {
            var u = await _context.Usuario.FindAsync(id);
            return View(u);
        }

        // EDITAR POST
        [HttpPost]
        public async Task<IActionResult> Editar(Usuario u)
        {
            _context.Usuario.Update(u);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // ============================
        // EXCLUIR GET
        // ============================
        public async Task<IActionResult> Excluir(int id)
        {
            var u = await _context.Usuario.FindAsync(id);
            return View(u);
        }

        // EXCLUIR POST
        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(int id)
        {
            var u = await _context.Usuario.FindAsync(id);

            if (u != null)
            {
                _context.Usuario.Remove(u);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // ============================
        // PERFIL
        // ============================
        public async Task<IActionResult> Perfil()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Usuario
                .FirstOrDefaultAsync(x => x.Email == email);

            return View(user);
        }

        // ATUALIZAR PERFIL
        [HttpPost]
        public async Task<IActionResult> AtualizarPerfil(Usuario u, string novasenha)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var atual = await _context.Usuario
                .FirstOrDefaultAsync(x => x.Email == email);

            atual.Nome = u.Nome;
            atual.Email = u.Email;
            atual.Telefone = u.Telefone;

            if (!string.IsNullOrEmpty(novasenha))
                atual.Senha = novasenha;

            _context.Usuario.Update(atual);
            await _context.SaveChangesAsync();

            TempData["Sucesso"] = "Perfil atualizado!";
            return RedirectToAction("Perfil");
        }
    }
}
