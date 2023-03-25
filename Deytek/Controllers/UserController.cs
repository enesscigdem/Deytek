using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Deytek.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deytek.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        UserManager bm = new UserManager(new EfUserRepository());

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult UserList()
        {
            var values = bm.GetList().ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserSignUpViewModel p, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                // Set the image path to a unique filename
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "writer", "Resimler", fileName);

                // Save the file to disk
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                // Set the profile photo URL to the new filename
                p.Image = fileName;
            }
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.nameSurname,
                    Password = p.Password,
                    ProfilePhotoUrl = p.Image
                };

                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserList", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }


        public IActionResult DeleteUser(string id)
        {
            var userid = bm.TGetByID(id);
            bm.TDelete(userid);
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var values = bm.TGetByID(id);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.password = values.Password;
            model.confirmpassword = values.Password;
            model.username = values.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserUpdateViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var values = await _userManager.FindByIdAsync(id);
                values.Email = model.mail;
                values.NameSurname = model.namesurname;
                values.Password = model.password;
                values.Password = model.confirmpassword;
                values.UserName = model.username;
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserList", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

    }
}