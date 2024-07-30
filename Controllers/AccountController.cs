using Microsoft.AspNetCore.Mvc;
using StorePIatform.Models;

namespace StorePIatform.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Here you would normally add code to save the user to the database.
                // For example, using a user service or directly via Entity Framework.

                // Redirect to the login page or another appropriate page
                return RedirectToAction("Login");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Here you would normally add code to authenticate the user.
                // For example, using a user service or directly via a database.

                // Redirect to the homepage or another appropriate page upon successful login
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
