using System.Collections.ObjectModel;
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

namespace To_do_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_BTN_Click(object sender, RoutedEventArgs e)
        {
            smallwindow smallWindow = new smallwindow();
            smallWindow.ShowDialog();
        }
    }
}