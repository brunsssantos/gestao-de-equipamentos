using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;

public class HomeController : Controller
{
    // Ação que retorna a View padrão do HomeController
    public IActionResult Index()
    {
        return View();
    }
}
