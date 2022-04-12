using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity101.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles="Admin")]
        //[AllowAnonymous
        public IActionResult Index()
        {
            return View();
        }
    }
}
