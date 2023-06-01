using System.Collections.Generic;
using System.Linq;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.Store;

public class VeiculosStore
{
    private readonly List<ResumoVaga> _vagasOcupadas;
    private readonly List<ResumoVaga> _vagasLivres;

    public VeiculosStore()
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
            .Select(i => new ResumoVaga($"A-{i}"))
            .ToList();

        var vagasSegundoAndar = Enumerable.Range(1, 15)
            .Select(i => new ResumoVaga($"B-{i}"))
            .ToList();

        _vagasLivres.AddRange(vagasPrimeiroAndar);
        _vagasLivres.AddRange(vagasSegundoAndar);
    }

    public void CriarVagasOcupadas()
    {
        var vagasOcupadasPrimeiroAndar = Enumerable.Range(1, 20)
            .Select(i => new ResumoVaga($"A-{i}", "HGT-9878", "Golf/Volkswagen"))
            .ToList();

        var vagasOcupadasSegundoAndar = Enumerable.Range(1, 15)
            .Select(i => new ResumoVaga($"B-{i}", "NAH-0987", "Corsa/Chevrolet"))
            .ToList();

        _vagasOcupadas.AddRange(vagasOcupadasPrimeiroAndar);
        _vagasOcupadas.AddRange(vagasOcupadasSegundoAndar);
    }
}
