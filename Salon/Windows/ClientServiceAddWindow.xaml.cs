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
using System.Windows.Shapes;

namespace Salon.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientServiceAddWindow.xaml
    /// </summary>
    public partial class ClientServiceAddWindow : Window
    {
        SalonEntities context;
        public ClientServiceAddWindow(SalonEntities context, ClientService clientService)
        {
            InitializeComponent();
            this.context = context;
            CmbClients.ItemsSource = context.Clients.ToList();
            CmbServices.ItemsSource = context.Services.ToList();
            this.DataContext = clientService;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.Close();
        }

        private void BtnSaveData_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
