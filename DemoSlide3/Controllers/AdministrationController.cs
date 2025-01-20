using DemoSlide3.Models.ViewModels;
using DemoSlide3.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoSlide3.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> ListRoles()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }



        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool roleExist = await _roleManager.RoleExistsAsync(model?.RoleName);
                if (roleExist)
                {
                    ModelState.AddModelError("RoleName", "Role đã tồn tại");
                    return View(model);
                }
                else
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = model.RoleName
                    };
                    IdentityResult result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
