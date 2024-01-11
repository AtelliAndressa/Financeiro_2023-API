using Dominio.Interfaces.Generics;
using Entities.Entidades;

namespace Dominio.Interfaces.IUsuarioSistemaFinanceiro
{
    public interface InterfaceUsuarioSistemaFinanceiro : InterfaceGeneric<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema);

        Task RemoverUsuarios(List<UsuarioSistemaFinanceiro> usuarios);

        Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario);
    }
}
