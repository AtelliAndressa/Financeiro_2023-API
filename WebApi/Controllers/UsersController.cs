using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        

        [AllowAnonymous]
        [Produces("apllication/json")]
        [HttpPost("/api/AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || 
                string.IsNullOrWhiteSpace(login.Password) || 
                string.IsNullOrWhiteSpace(login.cpf))
            {
                return Ok("Falta alguns dados");
            }


            var user = new ApplicationUser
            {
                Email = login.Email,
                UserName = login.Email,
                CPF = login.cpf
            };

            var result = await _userManager.CreateAsync(user, login.Password);  

            if (result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            //geração de confirmação caso precise
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //retorno do email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var response_retorn = await _userManager.ConfirmEmailAsync(user, code);

            if (response_retorn.Succeeded) 
            {
                return Ok("Usuário adicionado");
            } else
            {
                return Ok("Erro ao confirmar cadastro de usuário");
            }
        }
    }
}
