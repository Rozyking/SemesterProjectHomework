using Microsoft.AspNetCore.Mvc;

namespace DaggerheartProject.Controllers;

public class DaggerheartController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}