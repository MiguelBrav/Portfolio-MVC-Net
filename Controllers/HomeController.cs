using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services.Interfaces;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectService _projectRepository;
        private readonly IMailService _mailRepository;

        public HomeController(ILogger<HomeController> logger, IProjectService projectRepository, IMailService mailRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
            _mailRepository = mailRepository;
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
            if (contactModel.Email != null && contactModel.Message != null && contactModel.Name != null)
                return RedirectToAction("Thanks", contactModel);

            return View();
        }
        public async Task<IActionResult> Thanks(ContactViewModel contactModel)
        {
            try
            {
                bool isSuccess = await _mailRepository.SendEmail(contactModel);

                if(isSuccess)
                {
                    return View();
                }

                return RedirectToAction("Error");

            }
            catch (Exception)
            {

                return RedirectToAction("Error");

            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}