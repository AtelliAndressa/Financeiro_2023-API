using Dominio.Interfaces.IDespesa;
using Entities.Entidades;
using InfraEstrutura.Repositorio.Generics;

namespace InfraEstrutura.Repositorio
{

    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {
        public Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
