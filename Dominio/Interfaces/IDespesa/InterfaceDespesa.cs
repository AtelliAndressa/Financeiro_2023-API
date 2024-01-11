using Dominio.Interfaces.Generics;
using Entities.Entidades;

namespace Dominio.Interfaces.IDespesa
{
    public interface InterfaceDespesa : InterfaceGeneric<Despesa>
    {
        Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario);

        Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
