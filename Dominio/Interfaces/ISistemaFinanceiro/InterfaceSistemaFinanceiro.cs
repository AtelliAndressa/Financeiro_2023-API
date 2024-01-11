using Dominio.Interfaces.Generics;
using Entities.Entidades;

namespace Dominio.Interfaces.ISistemaFinanceiro
{
    public interface InterfaceSistemaFinanceiro : InterfaceGeneric<SistemaFinanceiro>
    {
        Task<IList<SistemaFinanceiro>> ListarSistemasUsuario(string emailUsuario);
    }
}
