using RDA.TaskSQLite._7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RDA.TaskSQLite._7;

public partial class MainWindow : Window
{
    TourDbContext context;
    Tour NewTour = new Tour();
    Tour selectedTour = new Tour();
    public MainWindow(TourDbContext context)
    {
        InitializeComponent();
        this.context = context;
        InitializeComponent();
        GetTours();
        NewTourGrid.DataContext = NewTour;
    }

    private void GetTours() 
    { 
        TourDG.ItemsSource = context.Tours.ToList(); 
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        selectedTour = (sender as FrameworkElement).DataContext as Tour;
        UpdateTourGrid.DataContext = selectedTour;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var tourToDelete = (sender as FrameworkElement).DataContext as Tour;
        context.Tours.Remove(tourToDelete);
        context.SaveChanges();
        GetTours();
    }

    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }

    private void BtnAddItem_Click(object sender, RoutedEventArgs e)
    {
        context.Tours.Add(NewTour);
        context.SaveChanges();
        GetTours();
        NewTour = new Tour();
        NewTourGrid.DataContext = NewTour;
    }

    private void BtnEditItem_Click(object sender, RoutedEventArgs e)
    {
        context.Update(selectedTour);
        context.SaveChanges();
        GetTours();
    }
}
