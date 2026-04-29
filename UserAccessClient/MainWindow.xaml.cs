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

namespace UserAccessClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var database = new MyDbContext();
            InitializeComponent();
            ComboBoxPunkt.ItemsSource = database.Checkpoint.ToList();
        }

        public Employee? found_employee; 

        public void Search()
        {
            var database = new MyDbContext();
            var Employees = database.Employee.ToList(); 
            foreach (var emp in Employees)
            {
                if (emp.FullName == TextBoxFIO.Text && TextBoxDepartment.Text != "" && emp.Departament == Int32.Parse(TextBoxDepartment.Text))
                {
                    found_employee = emp;
                }
            }
        }

        public static string? savedFIO;
        public static string? savedDepartment;
        public static string? savedCheckpoint;
        public static string? savedEntryTime;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search();
            var database = new MyDbContext();
            var selectedCheckpoint = (Checkpoint)ComboBoxPunkt.SelectedItem;

            if (found_employee != null && found_employee.IsActive == true && selectedCheckpoint != null && selectedCheckpoint.IsActive == true && ComboBoxPunkt.SelectedItem != null)
            {
                var AddLog = new AccessLogEntry();
                AddLog.EmployeeId = found_employee.Id;
                AddLog.CheckpointId = selectedCheckpoint.Id;
                AddLog.EntryTime = DateTime.Now;
                AddLog.Direction = selectedCheckpoint.Location;
                database.AccessLogEntry.Add(AddLog);
                database.SaveChanges();

                savedFIO = found_employee.FullName;
                savedDepartment = found_employee.Departament.ToString();
                savedCheckpoint = selectedCheckpoint.Name;
                savedEntryTime = AddLog.EntryTime.ToString();

                var window = Application.Current.MainWindow;
                Application.Current.MainWindow = new WindowInfo();
                window.Close();
                Application.Current.MainWindow.Show();
            }
            else
            {
                errortext.Text = "Ошибка, неверные данные";
            }
        }
    }
}