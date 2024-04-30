using Microsoft.AspNetCore.Mvc;

namespace ELDocClinic.Areas.Patients.Controllers
{
    [Area("Patient")]
    public class PatientController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetPatientById(int id)
        {
            return View(viewName:"GetPatientVM");
        }
    }
}
