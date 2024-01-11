using Dominio.Interfaces.ICategoria;
using Entities.Entidades;
using InfraEstrutura.Repositorio.Generics;

namespace InfraEstrutura.Repositorio
{
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, InterfaceCategoria
    {
        public Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
