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
    }
}
}
