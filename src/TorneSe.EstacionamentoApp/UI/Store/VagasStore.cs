using System.Collections.Generic;
using System.Linq;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.Store;

public class VagasStore
{
    private readonly List<ResumoVaga> _vagasOcupadas;
    private readonly List<ResumoVaga> _vagasLivres;

    public VagasStore()
    {
        _vagasOcupadas = new();
        _vagasLivres = new();
        CriarVagasLivres();
        CriarVagasOcupadas();
    }

    public IReadOnlyList<ResumoVaga> VagasOcupadas => _vagasOcupadas;
    public IReadOnlyList<ResumoVaga> VagasLivres => _vagasLivres;

    private void CriarVagasLivres()
    {
        var vagasPrimeiroAndar = Enumerable.Range(1, 20)
            .Select(i => new ResumoVaga(i, $"A-{i}"))
            .ToList();

        var vagasSegundoAndar = Enumerable.Range(1, 15)
            .Select(i => new ResumoVaga(i, $"B-{i}"))
            .ToList();

        _vagasLivres.AddRange(vagasPrimeiroAndar);
        _vagasLivres.AddRange(vagasSegundoAndar);
    }

    public void CriarVagasOcupadas()
    {
        var vagasOcupadasPrimeiroAndar = Enumerable.Range(1, 20)
            .Select(i => new ResumoVaga(i,$"A-{i}", "HGT-9878", "Golf/Volkswagen"))
            .ToList();

        var vagasOcupadasSegundoAndar = Enumerable.Range(1, 15)
            .Select(i => new ResumoVaga(i, $"B-{i}", "NAH-0987", "Corsa/Chevrolet"))
            .ToList();

        _vagasOcupadas.AddRange(vagasOcupadasPrimeiroAndar);
        _vagasOcupadas.AddRange(vagasOcupadasSegundoAndar);
    }

    public void OcuparVaga(int idVaga)
    {
        var vaga = _vagasLivres.FirstOrDefault(v => v.IdVaga == idVaga);

        if (vaga is not null)
        {
            _vagasLivres.Remove(vaga);
            _vagasOcupadas.Add(vaga);
        }
    }

    public void LiberarVaga(int idVaga)
    {
        var vaga = _vagasOcupadas.FirstOrDefault(v => v.IdVaga == idVaga);

        if (vaga is not null)
        {
            _vagasOcupadas.Remove(vaga);
            _vagasLivres.Add(vaga);
        }
    }
}
