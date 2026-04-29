using AccessEntitiesLibrary;
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

namespace AccessAdminPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var database = new MyDbContext();
            EmployesList.ItemsSource = database.Employee.ToList();
            CheckpointList.ItemsSource = database.Checkpoint.ToList();
            LogsList.ItemsSource = database.AccessLogEntry.ToList();
        }
    }
}