using Entities.Entidades;

namespace Dominio.Interfaces.IServico
{
    public interface ICategoriaServico
    {
        Task AdicionarCategoria(Categoria categoria);

        Task AtualizarCategoria(Categoria categoria);
    }
}
