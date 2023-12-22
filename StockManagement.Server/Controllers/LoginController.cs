using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Server.Entities;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> signInManager;

    public LoginController(SignInManager<ApplicationUser> signInManager)
    {
        this.signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("sunt un prostule");
        }
        var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

        if (result.Succeeded)
        {
            return Ok("asdd");
        }
        else
        {
            return BadRequest("Invalid login attempt");
        }
    }

    // Define LoginModel for model binding
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // Add other actions like Logout, Register, etc.
}