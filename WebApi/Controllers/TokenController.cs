using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Método para gerar o token que será utilizado para autorizar o acesso ao sistema.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecuritykey.Create("Secret_Key-fedaf7d8863b48e197b9287d492b708e"))
                    .AddSubject("Canal Dev Net Core")
                    .AddIssuer("Teste.Securiry.Bearer")
                    .AddAudience("Teste.Securiry.Bearer")
                    .AddClaim("UsuarioAPINumero", "1")
                    .AddExpiry(5)
                    .Builder();

                return Ok(new { token = token.value });

            }
            else
            {
               
                return Unauthorized();
            }
        }
    }
}
