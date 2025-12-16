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

namespace To_do_list
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class smallwindow: Window
    {
        public Task tasks { get; set; } = new Task() { Date=DateTime.Now};
        public smallwindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void cancel_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nodate_CB_Checked(object sender, RoutedEventArgs e)
        {

            if (nodate_CB.IsChecked == true)
            {
                tasks.Date = null;
                duedate_DP.IsEnabled = false;
            }
        }
        private void nodate_CB_Unchecked(object sender, RoutedEventArgs e)
        {
            duedate_DP.IsEnabled = true;
        }

        private void smalladd_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (Inputcheck())
            {
                Task newtask = new Task(tasks.Task_text, tasks.Date,false);

                MainWindow? main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                main.Task_list.Add(newtask);
                tasks.Task_text = "";
                tasks.Date = DateTime.Now;

                this.Close();

            }
        }
        private bool Inputcheck()
        {
            if (String.IsNullOrEmpty(tasks.Task_text))
            {
                MessageBox.Show("Task description cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (nodate_CB.IsChecked == false && tasks.Date==null)
            {
                MessageBox.Show("Please select a due date or check 'No due date'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
