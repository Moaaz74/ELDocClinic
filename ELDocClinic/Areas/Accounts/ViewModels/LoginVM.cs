using System.ComponentModel.DataAnnotations;

namespace ELDocClinic.Areas.Accounts.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password, ErrorMessage = "Passwod should contain Uppercase & Alphanumeric letters and digits ")]
        public string Password { get; set; }
    }
}
