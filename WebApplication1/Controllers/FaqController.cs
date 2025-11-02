using Microsoft.AspNetCore.Mvc;

namespace HelpDeskAI.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index() => View();
    }
}
