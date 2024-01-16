using Entities.Entidades;

namespace Dominio.Interfaces.IServico
{
    public interface IUsuarioSistemaFinanceiroServico
    {
        Task CadastrarUsuarioSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}
