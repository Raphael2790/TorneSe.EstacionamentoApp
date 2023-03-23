﻿using System.Windows;

namespace TorneSe.EstacionamentoApp.Dialogs;

/// <summary>
/// Lógica interna para VagaVeiculoDialog.xaml
/// </summary>
public partial class VagaVeiculoDialog : Window
{
    public VagaVeiculoDialog()
    {
        InitializeComponent();
        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
    }

    private void Cancelar_Click(object sender, RoutedEventArgs e) 
        => Close();

    private void Confirmar_Click(object sender, RoutedEventArgs e)
    {

    }
}
