using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Business.Interfaces;

public interface IVeiculoBusiness
{
    Task<List<Veiculo>> ObterPorPlaca(string placa);
    Task<ResumoSaida> ObterResumoSaida(int idVeiculo, int idVaga);
    Task RealizarEntradaVeiculo(Veiculo veiculo, int idVaga, string nomeCondutor, string documentoCondutor);
    Task RealizarSaidaVeiculo(ResumoSaida resumoSaida, int idVeiculo, int idVaga);
}
