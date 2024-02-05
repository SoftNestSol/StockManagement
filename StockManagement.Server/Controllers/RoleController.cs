using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);

        }
        public async Task<IActionResult> CreateRoleAsync([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }

        public void CreateRole([Required]string name) 
        { 
            if(ModelState.IsValid)
            {
                roleManager.CreateAsync(new IdentityRole(name));
            }
            else
            {
                Console.WriteLine("error creating role");
            }
        
        }

    }
}