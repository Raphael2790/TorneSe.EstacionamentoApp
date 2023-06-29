using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Forms = System.Windows.Forms;
using TorneSe.EstacionamentoApp.Extensions;
using System;
using TorneSe.EstacionamentoApp.UI.Extensions;
using TorneSe.EstacionamentoApp.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	private readonly IHost _host;
	private Forms.NotifyIcon _notifyIcon;

	public App()
	{
		_host = Host
			.CreateDefaultBuilder()
			.AddDatabase()
			.AddStores()
			.AddNotifications()
			.AddBusiness()
			.AddFactories()
			.AddViews()
			.Build();
	}

    protected override void OnStartup(StartupEventArgs e)
    {
		_host.Start();

		SeedDatabase();

		_notifyIcon = _host.Services.GetRequiredService<Forms.NotifyIcon>();

		//Menus
		_notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
		_notifyIcon.ContextMenuStrip.Items.Add("Sair", null, SairAplicacaoMenuStrip_Click);
		_notifyIcon.Click += NotifyIcon_Click;

		MainWindow = _host.Services.GetRequiredService<MainWindow>();
		MainWindow.Show();

        base.OnStartup(e);
    }

    private void SeedDatabase()
    {
        var contexto = _host.Services.GetRequiredService<EstacionamentoContexto>();

		if(contexto.Database.GetPendingMigrations().Any())
			contexto.Database.Migrate();

		contexto.Database.EnsureCreated();

        var vagasPrimeiroAndar = Enumerable.Range(1, 20)
           .Select(i => new Vaga() { Andar = 1, Codigo = "A", Numero = i, Ocupada = false })
           .ToList();

        var vagasSegundoAndar = Enumerable.Range(1, 15)
            .Select(i => new Vaga() { Andar = 2, Codigo = "B", Numero = i, Ocupada = false })
            .ToList();

		contexto.Vagas.AddRange(vagasPrimeiroAndar);
		contexto.Vagas.AddRange(vagasSegundoAndar);
		contexto.SaveChanges();
    }

    private void NotifyIcon_Click(object? sender, EventArgs e)
    {
        MainWindow.WindowState = WindowState.Normal;
		MainWindow.Activate();
    }

    private void SairAplicacaoMenuStrip_Click(object? sender, EventArgs e) => Shutdown();

    protected override void OnExit(ExitEventArgs e)
    {
		_host.Dispose();

		_notifyIcon.Dispose();

        base.OnExit(e);
    }
}
