using Dominio.Interfaces.IServico;
using Dominio.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaFinanceiroController : ControllerBase
    { 
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiroServico _iSistemaFinanceiroServico;

        public SistemaFinanceiroController(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro, ISistemaFinanceiroServico iSistemaFinanceiroServico) 
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _iSistemaFinanceiroServico = iSistemaFinanceiroServico;
        }

        /// <summary>
        /// Método para listar os sistemas do usuário.
        /// </summary>
        /// <param name="emailUsuario"></param>
        /// <returns></returns>
        [HttpGet("/api/ListarSistemaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarSistemaUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListarSistemasUsuario(emailUsuario);
        }

        /// <summary>
        /// Método para adicionar um sistema para o usuário.
        /// </summary>
        /// <param name="sistemaFinanceiro"></param>
        /// <returns></returns>
        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        /// <summary>
        /// Método para atualizar o sistema do usuário.
        /// </summary>
        /// <param name="sistemaFinanceiro"></param>
        /// <returns></returns>
        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        /// <summary>
        /// Método para obter um sistema.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
            return await _interfaceSistemaFinanceiro.GetEntityById(id);
        }

        /// <summary>
        /// Método para deletar um sistema.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/DeletarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeletarSistemaFinanceiro(int id)
        {
            try
            {
                var sistemaFinanceiro = await _interfaceSistemaFinanceiro.GetEntityById(id);

                await _interfaceSistemaFinanceiro.Delete(sistemaFinanceiro);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;

        }
    }
}
