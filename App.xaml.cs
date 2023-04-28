using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RDA.TaskSQLite._7.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RDA.TaskSQLite._7;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider serviceProvider;

    public App()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddDbContext<TourDbContext>(p =>
        {
            p.UseSqlite("Data Source= Task7.db");
        });
        services.AddSingleton<MainWindow>();
        serviceProvider = services.BuildServiceProvider();
    }
    private void OnStartUp(object sender, EventArgs e)
    {
        var mainWindow = serviceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }
}
