using Dominio.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using InfraEstrutura.Repositorio.Generics;

namespace InfraEstrutura.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        public Task<IList<SistemaFinanceiro>> ListarSistemasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
