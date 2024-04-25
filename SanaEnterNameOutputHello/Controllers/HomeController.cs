using Microsoft.AspNetCore.Mvc;
using SanaEnterNameOutputHello.Models;
using System.Diagnostics;

namespace SanaEnterNameOutputHello.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new UserNameModel());
        }

        [HttpPost]
        public IActionResult Index(UserNameModel model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                return RedirectToAction("Privacy", model);
            }
            else
            {
                ModelState.AddModelError("Name", "Please enter your name.");
                return View(model);
            }
        }

        public IActionResult Privacy(UserNameModel model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                return View(model);
            }
            else
            {
                // Handle the case where Name is not found
                return RedirectToAction("Index");
            }
        }
    }
}