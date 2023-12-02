using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services.Interfaces;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectService _projectRepository;

        public HomeController(ILogger<HomeController> logger, IProjectService projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            var proyects = _projectRepository.GetProyects().Take(3);
            var home = new HomeIndexViewModel() { Proyects = proyects };
            return View(home);
        }

        public IActionResult Projects()
        {
            var proyects = _projectRepository.GetProyects();
            return View(proyects);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contactModel)
        {
            if(contactModel.Email != null && contactModel.Message != null && contactModel.Name != null)
                return RedirectToAction("Thanks");

            return View();
        }
        public IActionResult Thanks()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}