using Dominio.Interfaces.IServico;
using Dominio.Interfaces.ISistemaFinanceiro;

namespace Dominio.Servicos
{
    public class SistemaFinanceiro : ISistemaFinanceiroServico
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;

        public SistemaFinanceiro(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }

        public async Task AdicionarSistemaFinanceiro(Entities.Entidades.SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                var data = DateTime.Now;

                sistemaFinanceiro.DiaFechamento = 1;
                sistemaFinanceiro.Ano = data.Year;
                sistemaFinanceiro.Mes = data.Month;
                sistemaFinanceiro.AnoCopia = data.Year;
                sistemaFinanceiro.MesCopia = data.Month;
                sistemaFinanceiro.GerarCopiaDespesa = true;

                await _interfaceSistemaFinanceiro.Add(sistemaFinanceiro);
            }
        }

        public async Task AtualizarSistemaFinanceiro(Entities.Entidades.SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                sistemaFinanceiro.DiaFechamento = 1;
                await _interfaceSistemaFinanceiro.Update(sistemaFinanceiro);
            }
    }
}
