using Microsoft.AspNetCore.Mvc;
using Models;

namespace DaggerheartProject.Controllers;

public class DaggerheartController : Controller
{

    public IActionResult Index()
    {
        return View(DaggerheartCharacterData.All);
    }

}