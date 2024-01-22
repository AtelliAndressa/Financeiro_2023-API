using Dominio.Interfaces.IDespesa;
using Dominio.Interfaces.IServico;
using Entities.Entidades;

namespace Dominio.Servicos
{
    public class DespesaServico : IDespesaServico
    {
        private readonly InterfaceDespesa _interfaceDespesa;

        public DespesaServico(InterfaceDespesa interfaceDespesa)
        {
            _interfaceDespesa = interfaceDespesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");

            if (valido)
            {
                await _interfaceDespesa.Add(despesa);
            }
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");

            if (valido)
            {
                await _interfaceDespesa.Update(despesa);
            }
        }

        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            var despesasUsuario = await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
            var despesasAnteriores = await _interfaceDespesa.ListarDespesasUsuarioNaoPagasMesesAnterior(emailUsuario);

            var despesasNaoPagasMesesAnteriores = despesasAnteriores.Any() ? 
                despesasAnteriores.ToList().Sum(x => x.Valor) : 0;

            var despesasPagas = despesasUsuario.Where(x => x.Pago && x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
                .Sum(x => x.Valor);

            var despesasPendentes = despesasUsuario.Where(x => !x.Pago && x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
                .Sum(x => x.Valor);

            var investimentos = despesasUsuario.Where(x => x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Investimento)
                .Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                despesas_pagas = despesasPagas,
                despesas_pendentes = despesasPendentes,
                despesas_naoPagasMesesAnteriores = despesasNaoPagasMesesAnteriores,
                investimentos = investimentos
            };
        }
    }
}
