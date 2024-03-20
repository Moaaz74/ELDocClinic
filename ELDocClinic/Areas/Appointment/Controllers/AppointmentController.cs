using Microsoft.AspNetCore.Mvc;

namespace ELDocClinic.Areas.Appointment.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
