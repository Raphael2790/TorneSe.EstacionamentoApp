using System.Windows.Controls;
using TorneSe.EstacionamentoApp.UI.Enums;

namespace TorneSe.EstacionamentoApp.UI.Factories.Interfaces;

public interface IViewFactory
{
    UserControl CriarView(Paginas nomeView);
}
