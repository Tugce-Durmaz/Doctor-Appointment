﻿


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doctor_Appointment.Models;
using Doctor_Appointment.Data;

namespace Doctor_Appointment.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı adı ve şifreyi veritabanında kontrol et
                var user = await _context.Login
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // Giriş başarılı, kullanıcıyı Menu sayfasına yönlendir
                    return RedirectToAction("Menu", "Menu"); // Burayı güncelledik
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                }
            }
            return View(model);
        }
    }
}
