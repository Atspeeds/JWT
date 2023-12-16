using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Models;
using System.Diagnostics;
using UniversityManagement.Application.Conteract.StudentCo;

namespace ServiceHost.Controllers
{
    public class HomeController : Controller
    {

        private readonly IStudentApplication _studentApplication;

        public HomeController(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        public IActionResult Index()
        {
            return View(_studentApplication.GetAll());
        }

        public IActionResult Privacy()
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
