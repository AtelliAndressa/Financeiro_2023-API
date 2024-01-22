using Dominio.Interfaces.IServico;
using Dominio.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _iUsuarioSistemaFinanceiroServico;

        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroServico iUsuarioSistemaFinanceiroServico)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _iUsuarioSistemaFinanceiroServico = iUsuarioSistemaFinanceiroServico;
        }

        /// <summary>
        /// Método para listar os sistemas do usuário
        /// </summary>
        /// <param name="idSistema"></param>
        /// <returns></returns>
        [HttpGet("/api/ListarSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarSistemasUsuario(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        /// <summary>
        /// Método para cadastrar um usuario para o sistema.
        /// </summary>
        /// <param name="idSistema"></param>
        /// <param name="emailUsuario"></param>
        /// <returns></returns>
        [HttpPost("/api/CadastrarUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _iUsuarioSistemaFinanceiroServico.CadastrarUsuarioSistema(
                    new UsuarioSistemaFinanceiro
                    {
                        IdSistema = idSistema,
                        EmailUsuario = emailUsuario,
                        Administrador = false,
                        SistemaAtual = true
                    });
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        /// <summary>
        /// Método para deletar um usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/DeletarUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> DeletarUsuarioSistema(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);

                await _interfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch(Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
