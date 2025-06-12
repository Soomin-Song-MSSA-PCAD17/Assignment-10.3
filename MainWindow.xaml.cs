using Assignment_10._3.Data;
using Assignment_10._3.Models;
using Assignment_10._3.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_10._3
{
    /// <summary>
    /// Event handlers for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUD crud;
        public MainWindow()
        {
            InitializeComponent();
            Records.context = new DatabaseContext();
            Records.context.Database.EnsureDeleted();
            Records.context.Database.EnsureCreated();
            Records.context.CarSet.Load();

            crud = new CRUD();

            RefreshDataGridView();
            //datagridCars.ItemsSource = Records.context.CarSet.Local.ToObservableCollection();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var newCar = GetTextboxData();
            if (newCar == null) { return; }
            if (crud.FindCar(newCar.Vin) != null)
            {
                MessageBox.Show($"Item could not be created. Car with VIN '{newCar.Vin}' is already in the database.","caption",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            
            crud.CreateCar(newCar);
            RefreshDataGridView();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Car updatedCar = crud.FindCar(TextboxVIN.Text);
            if (updatedCar == null) { return; }
            crud.UpdateCar(GetTextboxData());
            RefreshDataGridView();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GetSelectedRow() == null) { return; }
            crud.DeleteCar(GetSelectedRow().Vin);
            RefreshDataGridView();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            FillTextbox(GetSelectedRow());
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            FillTextbox(null);
            Console.WriteLine("btnClear pressed");
        }



    }

    /// <summary>
    /// utility methods
    /// </summary>
    public partial class MainWindow
    {
        private Car GetTextboxData()
        {
            if (TextboxVIN.Text == string.Empty || TextboxMake.Text == string.Empty || TextboxModel.Text == string.Empty || TextboxYear.Text == string.Empty || TextboxPrice.Text == string.Empty)
            {
                return null;
            }
            string vin = TextboxVIN.Text;
            string make = TextboxMake.Text;
            string model = TextboxModel.Text;
            string year = TextboxYear.Text;
            double price = Convert.ToDouble(TextboxPrice.Text);
            return new Car(vin, make, model, year, price);
        }
        
        private void FillTextbox(Car car)
        {
            if (car == null)
            {
                TextboxVIN.Text = "";
                TextboxMake.Text = "";
                TextboxModel.Text = "";
                TextboxYear.Text = "";
                TextboxPrice.Text = "";
                return;
            }
            TextboxVIN.Text = car.Vin;
            TextboxMake.Text = car.Make;
            TextboxModel.Text = car.Model;
            TextboxYear.Text = car.Year;
            TextboxPrice.Text = car.Price.ToString();
        }

        private Car GetSelectedRow()
        {
            if(datagridCars.SelectedItem==null) { return null; }
            return (Car)datagridCars.SelectedItem;
        }

        private void RefreshDataGridView()
        {
            datagridCars.ItemsSource = null;
            datagridCars.ItemsSource = Records.context.CarSet.Local.ToObservableCollection();
        }
    }
}