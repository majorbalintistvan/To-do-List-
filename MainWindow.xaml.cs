using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace To_do_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> Task_list { get; set; } = new ObservableCollection<Task>();
        public Piecahrt Chart { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadTasks();
            Chart = new Piecahrt(Task_list);
        }

        private void Add_BTN_Click(object sender, RoutedEventArgs e)
        {
            smallwindow smallWindow = new smallwindow();
            smallWindow.ShowDialog();
        }

        private void Save_BTN_Click(object sender, RoutedEventArgs e)
        {
            try {
                string json = JsonSerializer.Serialize(Task_list);
                File.WriteAllText("savedtasks.json", json);
                MessageBox.Show("Successfull saving", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Saving failed","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Clear_BTN_Click(object sender, RoutedEventArgs e)
        {
            Task_list.Clear();
        }

        private void LoadTasks()
        {
            if (File.Exists("savedtasks.json"))
            {
                string json = File.ReadAllText("savedtasks.json");
                var loadedTasks = JsonSerializer.Deserialize<ObservableCollection<Task>>(json);
                Task_list.Clear(); 
                foreach (var task in loadedTasks)
                {
                    Task_list.Add(task); 
                }
            }
        }
    }
}