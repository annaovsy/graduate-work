using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestWithoutAutentification.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using TestWithoutAutentification.Models; // пространство имен UserContext и класса User
using System;

namespace TestWithoutAutentification.Controllers
{
    public class AccountController : Controller
    {
        private Models.AppDbContext db;
        public AccountController(Models.AppDbContext context)
        {
            db = context;
        }

        #region UserAccount
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user.Name, user.Role.Name);
                    //await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Name = model.Name, Email = model.Email, Password = model.Password };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    db.Users.Add(user);

                    await db.SaveChangesAsync();

                    await Authenticate(user.Name, user.Role.Name); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Данный Email зарегистрирован в системе");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region CompanyAccount

        [HttpGet]
        public IActionResult CompanyLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CompanyLogin(CompanyLoginModel model)
        {
            if (ModelState.IsValid)
            {
                Company company = await db.Companies
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (company != null)
                {
                    await Authenticate(company.Name, company.Role.Name);
                    
                    return RedirectToAction("Index", "CompanyHome");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult CompanyRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CompanyRegister(CompanyRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Company company = await db.Companies.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (company == null)
                {
                    company = new Company
                    {
                        Name = model.Name,
                        City = model.City,
                        FirstNameContactPerson = model.FirstNameContactPerson,
                        LastNameContactPerson = model.LastNameContactPerson,
                        Email = model.Email,
                        Password = model.Password,
                        Phone = model.Phone
                    };
                    Role companyRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "company");
                    if (companyRole != null)
                        company.Role = companyRole;

                    db.Companies.Add(company);

                    await db.SaveChangesAsync();

                    await Authenticate(company.Name, company.Role.Name);

                    return RedirectToAction("Index", "CompanyHome");
                }
                ModelState.AddModelError("", "Данный Email зарегистрирован в системе");
            }
            return View(model);
        }

        public async Task<IActionResult> CompanyLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("CompanyLogin", "Account");
        }

        #endregion

        private async Task Authenticate(string name, string role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
    
}
