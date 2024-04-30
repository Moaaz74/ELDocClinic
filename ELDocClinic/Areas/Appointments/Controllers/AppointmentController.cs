using Microsoft.AspNetCore.Mvc;

namespace ELDocClinic.Areas.Appointments.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
