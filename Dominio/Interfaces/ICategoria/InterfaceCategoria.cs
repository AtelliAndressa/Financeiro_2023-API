using Dominio.Interfaces.Generics;
using Entities.Entidades;

namespace Dominio.Interfaces.ICategoria
{
    public interface InterfaceCategoria : InterfaceGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario);
    }
}
