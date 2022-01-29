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

        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSelectClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSelectServices_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
