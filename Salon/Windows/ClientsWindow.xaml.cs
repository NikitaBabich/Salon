using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Salon.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        SalonEntities context;
        public ClientsWindow()
        {
            InitializeComponent();
            context = new SalonEntities();
            CmbFiltr.SelectedIndex = 0;
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridClients.ItemsSource = context.Clients.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewZap = new Client();
            context.Clients.Add(NewZap);
            var EditWindow = new Windows.ClientAddWindow(context, NewZap);
            EditWindow.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentZap = DataGridClients.SelectedItem as Client;
            if (currentZap == null)
            {
                System.Windows.MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Clients.Remove(currentZap);
                context.SaveChanges();
                System.Windows.MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button BtnEdit = sender as System.Windows.Controls.Button;
            var currentZap = BtnEdit.DataContext as Client;
            var EditWindow = new Windows.ClientAddWindow(context, currentZap);
            EditWindow.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridClients.ItemsSource = context.Clients.Where(x => x.FirstName.Contains(TxtSearch.Text)) .ToList();
        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbFiltr.SelectedIndex==0)
            {
                ShowTable();
            }
            if (CmbFiltr.SelectedIndex == 1)
            {
                DataGridClients.ItemsSource = context.Clients.Where(x => x.GenderCode.Contains("1")).ToList();
            }
            if (CmbFiltr.SelectedIndex == 2)
            {
                DataGridClients.ItemsSource = context.Clients.Where(x => x.GenderCode.Contains("2")).ToList();
            }
        }
    }
}
