using AutoMapper;
using ELDocClinic.Areas.Accounts.ViewModels;
using ELDocClinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;  

namespace ELDocClinic.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        //private readonly IJwtService _jwtService;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager ,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _mapper.Map<ApplicationUser>(registerVM);

                IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user , isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                
                foreach(var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }

            return View(registerVM);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginVM.Username);
                if(user != null)
                {
                    bool userExists = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (userExists)
                    {
                        await _signInManager.SignInAsync(user , false);
                        return RedirectToAction("Index", "Home");
                    }
                }ModelState.AddModelError("", "User is not exists");
            }return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
