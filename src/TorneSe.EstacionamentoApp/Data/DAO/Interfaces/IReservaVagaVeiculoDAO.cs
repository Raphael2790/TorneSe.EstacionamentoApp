using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

public interface IReservaVagaVeiculoDAO
{
    Task Atualizar(ReservaVagaVeiculo reservaVaga, ResumoSaida resumoSaida);
    Task Inserir(ReservaVagaVeiculo reservaVagaVeiculo);
    Task<ReservaVagaVeiculo?> ObterReservaVagaVeiculo(int idVeiculo, int idVaga);
}
