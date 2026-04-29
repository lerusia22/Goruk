using AccessEntitiesLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserAccessClient
{
    /// <summary>
    /// Логика взаимодействия для WindowInfo.xaml
    /// </summary>
    public partial class WindowInfo : Window
    {
        public WindowInfo()
        {
            InitializeComponent();
            GetInfo();
        }

        public void GetInfo()
        {
            var database = new MyDbContext();
            FIO.Text = MainWindow.savedFIO;
            Podr.Text = MainWindow.savedDepartment;
            PropPunkt.Text = MainWindow.savedCheckpoint;
            TimeEnter.Text = MainWindow.savedEntryTime;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
