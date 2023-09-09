using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.UI.Enums;
using TorneSe.EstacionamentoApp.UI.Helpers;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para HomeView.xam
/// </summary>
public partial class HomeView : UserControl
{
    private readonly DispatcherTimer _timer;
    private readonly DispatcherTimer _timerBateria;
    private readonly DispatcherTimer _timerInternet;

    private readonly IReservaBusiness _reservaBusiness;

    public HomeView(IReservaBusiness reservaBusiness)
    {
        InitializeComponent();

        horaTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
        _timer = new()
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        _timer.Tick += Timer_Tick;
        _timer.Start();

        var bateriaInfo = SystemStatusHelper.ObterStatusBateria();
        bateriaTextBlock.Text = bateriaInfo.Porcentagem;
        statusBateria.Kind = Material.Icons.MaterialIconKind.Battery100;
        _timerBateria = new()
        {
            Interval = TimeSpan.FromMinutes(1),
        };
        _timerBateria.Tick += Bateria_Tick;
        _timerBateria.Start();


        _timerInternet = new()
        {
            Interval = TimeSpan.FromMinutes(1),
        };
        _timerInternet.Tick += Internet_Tick;
        _timerInternet.Start();

        _reservaBusiness = reservaBusiness;
        MontarComponente();
    }

    private void Internet_Tick(object? sender, EventArgs e)
    {
        var conectado = SystemStatusHelper.IsConnectedToInternet();

        if (conectado)
        {
            statusWifi.Kind = Material.Icons.MaterialIconKind.Wifi;
            statusWifi.Foreground = new SolidColorBrush(Colors.Green);
        }
        else
        {
            statusWifi.Kind = Material.Icons.MaterialIconKind.WifiOff;
            statusWifi.Foreground = new SolidColorBrush(Colors.Red);
        }
    }

    private void Bateria_Tick(object? sender, EventArgs e)
    {
        var bateriaInfo = SystemStatusHelper.ObterStatusBateria();
        bateriaTextBlock.Text = bateriaInfo.Porcentagem;

        statusBateria.Kind = bateriaInfo.BateriaStatus switch
        {
            BateriaStatus.SemBateria => Material.Icons.MaterialIconKind.Battery100,
            BateriaStatus.Carregando => Material.Icons.MaterialIconKind.BatteryCharging60,
            BateriaStatus.Baixa => Material.Icons.MaterialIconKind.Battery20,
            BateriaStatus.Media => Material.Icons.MaterialIconKind.Battery50,
            BateriaStatus.Cheia => Material.Icons.MaterialIconKind.BatteryFull,
            BateriaStatus.Critica => Material.Icons.MaterialIconKind.BatteryAlert,
            _ => Material.Icons.MaterialIconKind.BatteryAlert
        };
    }

    private async void MontarComponente()
    {
        var ocupacao = await _reservaBusiness.ObterPorcentagemOcupacao();
        vagasDisponiveisTextBlock.Text = ocupacao.QuantidadeLivres.ToString();
        vagasOcupadasTextBlock.Text = ocupacao.QuantidadeOcupadas.ToString();
        porcentagemOcupacaoTextBlock.Text = $"{ocupacao.Ocupadas}%";
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        horaTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
    }
}
