using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestWithoutAutentification.ViewModels;
using TestWithoutAutentification.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TestWithoutAutentification.Models.AdditionalModels;
using System.Linq;

namespace TestWithoutAutentification.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment _appEnvironment;

        public AccountController(AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
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
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == HashPassword(model.Password));
                if (user != null)
                {
                    await Authenticate(user.Email, user.Role.Name, user.Name);                    

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
        public async Task<IActionResult> Register(User modelUser)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == modelUser.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Name = modelUser.Name, Email = modelUser.Email, Password = HashPassword(modelUser.Password)};
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    db.Users.Add(user);

                    await db.SaveChangesAsync();

                    await Authenticate(user.Email, user.Role.Name, user.Name); // аутентификация
                    
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Данный Email зарегистрирован в системе");
            }
            return View(modelUser);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;
                    user.Password = HashPassword(user.Password);
                    db.Update(user);
                    await db.SaveChangesAsync();
                    await Authenticate(user.Email, user.Role.Name, user.Name); // аутентификация

                    return RedirectToAction("PersonalArea", "Home");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }           
            return View(user);
        }

        // get: resumes/delete/5
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await db.Users.Include(u => u.Resume).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }                

            return View(user);
        }

        // post: resumes/delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedUser(int id)
        {
            var user = await db.Users.Include(u => u.Resume).FirstOrDefaultAsync(u => u.Id == id);
            
            if(user.Resume != null)
            {
                db.Resume.Remove(user.Resume);
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Logout", "Account");
        }

        private bool UserExists(int id)
        {
            return db.Users.Any(e => e.Id == id);
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
        public async Task<IActionResult> CompanyLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Company company = await db.Companies
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == HashPassword(model.Password));
                if (company != null)
                {                   
                    await Authenticate(company.Email, company.Role.Name, company.Name);

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
        public async Task<IActionResult> CompanyRegister(Company model, IFormFile uploadedFile)
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
                        Password = HashPassword(model.Password),
                        Phone = model.Phone,
                        Site = model.Site
                    };
                    if (uploadedFile != null)
                    {
                        string path = "/logo/" + uploadedFile.FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        Image file = new() { Name = uploadedFile.FileName, Path = path };
                        db.Images.Add(file);
                        company.Image = file;
                    }
                    Role companyRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "company");
                    if (companyRole != null)
                        company.Role = companyRole;

                    db.Companies.Add(company);

                    await db.SaveChangesAsync();

                    await Authenticate(company.Email, company.Role.Name, company.Name);

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

        private async Task Authenticate(string email, string role, string name)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
                new Claim("userName", name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public static string HashPassword(string password)
        { 
            MD5 mD5 = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = mD5.ComputeHash(b);

            StringBuilder stringBuilder = new StringBuilder();
            foreach(var symbol in hash)
            {
                stringBuilder.Append(symbol.ToString("X2"));
            }

            return Convert.ToString(stringBuilder);
        }
    }
    
}
