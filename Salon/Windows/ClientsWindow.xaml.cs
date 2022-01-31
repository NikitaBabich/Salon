﻿using System;
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
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        SalonEntities context;
        public ClientsWindow()
        {
            InitializeComponent();
            context = new SalonEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridClients.ItemsSource = context.Clients.ToList();
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
    }
}
