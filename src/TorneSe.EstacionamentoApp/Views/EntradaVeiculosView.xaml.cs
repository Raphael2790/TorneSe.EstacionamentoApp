using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Store;

namespace TorneSe.EstacionamentoApp.Views
{
    /// <summary>
    /// Interação lógica para EntradaVeiculosView.xam
    /// </summary>
    public partial class EntradaVeiculosView : UserControl
    {
        public EntradaVeiculosView(VeiculosStore veiculosStore)
        {
            InitializeComponent();
        }
    }
}
