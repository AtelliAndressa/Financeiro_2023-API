using Dominio.Interfaces.ICategoria;
using Dominio.Interfaces.IServico;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        private readonly ICategoriaServico _iCategoriaServico;

        public CategoriaController(InterfaceCategoria interfaceCategoria, ICategoriaServico iCategoriaServico)
        {
            _interfaceCategoria = interfaceCategoria;
            _iCategoriaServico = iCategoriaServico;
        }

        /// <summary>
        /// Método para listar todas as categorias do usuário.
        /// </summary>
        /// <param name="emailUsuario"></param>
        /// <returns></returns>
        [HttpGet("/api/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasUsuario(string emailUsuario)
        {
            return _interfaceCategoria.ListarCategoriasUsuario(emailUsuario);
        }

        /// <summary>
        /// Método para adicionar Categoria.
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
           await _iCategoriaServico.AdicionarCategoria(categoria);

            return categoria;
        }
    }
}
