using Dominio.Interfaces.ICategoria;
using Dominio.Interfaces.IDespesa;
using Dominio.Interfaces.IServico;
using Dominio.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly InterfaceDespesa _interfaceDespesa;
        private readonly IDespesaServico _iDespesaServico;

        public DespesasController(InterfaceDespesa interfaceDespesa, IDespesaServico iDespesaServico)
        {
            _interfaceDespesa = interfaceDespesa;
            _iDespesaServico = iDespesaServico;
        }

        /// <summary>
        /// Método para listar todas as despesas do usuário.
        /// </summary>
        /// <param name="emailUsuario"></param>
        /// <returns></returns>
        [HttpGet("/api/ListarDespesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDespesasUsuario(string emailUsuario)
        {
            return await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
        }

        /// <summary>
        /// Método para adicionar Despesa.
        /// </summary>
        /// <param name="despesa"></param>
        /// <returns></returns>
        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _iDespesaServico.AdicionarDespesa(despesa);

            return despesa;
        }

        /// <summary>
        /// Atualizar uma despesa.
        /// </summary>
        /// <param name="despesa"></param>
        /// <returns></returns>
        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesa(Despesa despesa)
        {
            await _iDespesaServico.AtualizarDespesa(despesa);

            return despesa;
        }

        /// <summary>
        /// Obter uma despesa pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<object> ObterDespesa(int id)
        {
            return await _interfaceDespesa.GetEntityById(id);
        }

        /// <summary>
        /// Método para deletar uma despesa.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/DeletarDespesa")]
        [Produces("application/json")]
        public async Task<object> DeletarDespesa(int id)
        {
            try
            {

                var categoria = await _interfaceDespesa.GetEntityById(id);

                await _interfaceDespesa.Delete(categoria);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        /// <summary>
        /// Metodo que é usado no dashboard.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/CarregarGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            return await _iDespesaServico.CarregarGraficos(emailUsuario);
        }
    }
}
