using LeaveManagmentSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagmentSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Shoeb",
                DOB = new DateTime(1985,06,23)
            };
            return View(data);
        }
    }
}
