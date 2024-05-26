using Cartools.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Controllers
{   
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
               SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {

                    var userRoles = await _userManager.GetRolesAsync(user);

                    if (userRoles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                    }
                    else if (userRoles.Contains("Parceiro"))
                    {
                        return RedirectToAction("Index", "Parceiro", new { area = "Parceiro" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }



                    //if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}
                    //return Redirect(loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Usuário ou senha não encontrados! Tente novamente ou cadastre-se logo abaixo.");
            return View(loginVM);
        } 
        [HttpGet]
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM, string selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registroVM.UserName };
                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, registroVM.SelectedRole);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
                }
            }
            return View(registroVM);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }           
    }
}
