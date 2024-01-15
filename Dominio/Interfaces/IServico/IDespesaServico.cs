using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.IServico
{
    public interface IDespesaServico
    {
        Task AdicionarDespesa(Despesa despesa);

        Task AtualizarDespesa(Despesa despesa);
    }
}
