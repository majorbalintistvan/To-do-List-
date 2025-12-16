using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;


namespace To_do_list
{
    public class Piecahrt
    {
        public PlotModel Model { get; private set; }

        private PieSeries pieSeries;
        private ObservableCollection<Task> cahrt_tasks;

        public Piecahrt(ObservableCollection<Task> tasks)
        {
            cahrt_tasks = tasks;
            Model = new PlotModel {Title = "Progress"};
            pieSeries = new PieSeries{InnerDiameter = 0.6,StrokeThickness=3, FontSize=15};
            Model.Series.Add(pieSeries);
            cahrt_tasks.CollectionChanged += ModifyCollection;
            AddTasks();
            UpdateChart();
        }
        private void AddTasks()
        {
            foreach (var task in cahrt_tasks)
            {
                task.PropertyChanged -= PropertyChanging;
                task.PropertyChanged += PropertyChanging;
            }
        }
        private void ModifyCollection(object sender, NotifyCollectionChangedEventArgs e)
        {
            AddTasks();
            UpdateChart();
        }
        private void PropertyChanging(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsDone") UpdateChart();
        }
        private void UpdateChart()
        {
            int doneCount = cahrt_tasks.Count(t => t.IsDone);
            int notdoneCount = cahrt_tasks.Count - doneCount;
            pieSeries.Slices.Clear();
            pieSeries.Slices.Add(new PieSlice("Done", doneCount));
            pieSeries.Slices.Add(new PieSlice("Not Done", notdoneCount));
            Model.InvalidatePlot(true);
        }
    }
}
