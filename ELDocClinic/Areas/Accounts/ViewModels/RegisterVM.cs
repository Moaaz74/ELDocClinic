using System.ComponentModel.DataAnnotations;

namespace ELDocClinic.Areas.Accounts.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        [DataType(DataType.EmailAddress , ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number field is required")]
        [DataType(DataType.PhoneNumber , ErrorMessage = "Invalid Phone number")]
        [Display(Name = "Phone number")]
        [RegularExpression("^(([+]?\\d{1,3}[ -]?)?\\d{10})|(^+?\\d{2,5}[ -]?\\d{7,14})$\r\n" , ErrorMessage = "Invalid Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType (DataType.Password , ErrorMessage = "Passwod should contain Uppercase & Alphanumeric letters and digits ")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password field is required")]
        [DataType (DataType.Password)]
        [Compare("Password" , ErrorMessage = "Confirm Password field does not match with Password field")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirmed { get; set; }

    }
}
