using Microsoft.AspNetCore.Mvc;
using StorePlatform.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StorePIatform.Models;
using StorePIatform.Data;

namespace StorePlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    // Kullanıcıyı oturum açma işlemleri
                    return RedirectToAction("Index", "about");
                }
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUserViewModel
                {
                    Username = model.Username,
                    Email = model.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
                };

                _context.User.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View(model);
        }

    }
}




























//using Microsoft.AspNetCore.Mvc;
//using StorePIatform.Models;

//namespace StorePIatform.Controllers
//{
//    public class AccountController : Controller
//    {


//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Login(LoginViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Kullanıcı giriş işlemleri
//                // Örneğin: Kullanıcı doğrulama ve oturum açma
//                return RedirectToAction("Index", "Home");
//            }
//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Register(RegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Yeni kullanıcı kayıt işlemleri
//                // Örneğin: Veritabanına yeni kullanıcı ekleme
//                return RedirectToAction("Login");
//            }
//            return View(model);
//        }







//        //// GET: /Account/Register
//        //public IActionResult Register()
//        //{
//        //    return View();
//        //}

//        //// POST: /Account/Register
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Register(RegisterViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        // Here you would normally add code to save the user to the database.
//        //        // For example, using a user service or directly via Entity Framework.

//        //        // Redirect to the login page or another appropriate page
//        //        return RedirectToAction("Login");
//        //    }

//        //    // If we got this far, something failed, redisplay form
//        //    return View(model);
//        //}

//        //// GET: /Account/Login
//        //public IActionResult Login()
//        //{
//        //    return View();
//        //}

//        //// POST: /Account/Login
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Login(LoginViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        // Here you would normally add code to authenticate the user.
//        //        // For example, using a user service or directly via a database.

//        //        // Redirect to the homepage or another appropriate page upon successful login
//        //        return RedirectToAction("Index", "Home");
//        //    }

//        //    // If we got this far, something failed, redisplay form
//        //    return View(model);
//        //}
//    }
//}
