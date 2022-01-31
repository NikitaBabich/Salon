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
    /// Логика взаимодействия для ServiceAddWindow.xaml
    /// </summary>
    public partial class ServiceAddWindow : Window
    {
        SalonEntities context;
        public ServiceAddWindow(SalonEntities context,Service service)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = service;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.Close();
        }
    }
}
