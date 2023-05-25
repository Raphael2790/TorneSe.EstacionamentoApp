using System;
using System.Windows.Forms;
using TorneSe.EstacionamentoApp.Notifications.Interfaces;

namespace TorneSe.EstacionamentoApp.Notifications;

internal class WindowsNotificationService : INotificationService
{
    private readonly NotifyIcon _notifyIcon;

    public WindowsNotificationService(NotifyIcon notifyIcon) 
        => _notifyIcon = notifyIcon;

    public void Notificar(int intervalo, string titulo, string mensagem, string tipoIcone, EventHandler? handler = null)
    {
        _notifyIcon.ShowBalloonTip(1000, "Entrada Veiculo", "Entrada realizada com sucesso do veiculo UHUHA-1918"
        , ToolTipIcon.Info);
        _notifyIcon.BalloonTipClicked += (s, e) => MessageBox.Show("Clicou no balão");
    }
}
