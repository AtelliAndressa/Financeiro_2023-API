using Entities.Entidades;

namespace Dominio.Interfaces.IServico
{
    public interface IDespesaServico
    {
        Task AdicionarDespesa(Despesa despesa);

        Task AtualizarDespesa(Despesa despesa);

        Task<object> CarregarGraficos(string emailUsuario);
    }
}
