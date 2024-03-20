using Microsoft.AspNetCore.Identity;

namespace ELDocClinic.Areas.Patient.ViewModels
{
    public class GetPatientVM
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
