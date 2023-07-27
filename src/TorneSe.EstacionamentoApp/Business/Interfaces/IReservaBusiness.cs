using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Comum;

namespace TorneSe.EstacionamentoApp.Business.Interfaces;

public interface IReservaBusiness
{
    Task<ResumoOcupacao> ObterPorcentagemOcupacao();
    Task<List<ResumoFaturamentoFormaPagamento>> ObterValorFaturamentoPorFormaPagamento();
    Task<List<ResumoFaturamentoMensal>> ObterValorFaturamentoUltimosMeses();
}
