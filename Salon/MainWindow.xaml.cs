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

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SalonEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new SalonEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridClientService.ItemsSource = context.ClientServices.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewZap = new ClientService();
            context.ClientServices.Add(NewZap);
            var EditWindow = new Windows.ClientServiceAddWindow(context, NewZap);
            EditWindow.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentZap = DataGridClientService.SelectedItem as ClientService;
            if (currentZap == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientServices.Remove(currentZap);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentZap = BtnEdit.DataContext as ClientService;
            var EditWindow = new Windows.ClientServiceAddWindow(context, currentZap);
            EditWindow.ShowDialog();
        }

        private void BtnSelectClients_Click(object sender, RoutedEventArgs e)
        {
            var ClientList = new Windows.ClientsWindow();
            ClientList.ShowDialog();
        }

        private void BtnSelectServices_Click(object sender, RoutedEventArgs e)
        {
            var ServiceList = new Windows.ServiceWindow();
            ServiceList.ShowDialog();
        }
    }
}
