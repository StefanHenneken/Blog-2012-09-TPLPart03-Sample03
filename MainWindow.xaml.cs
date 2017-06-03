using System;
using System.Threading.Tasks;
using System.Windows;

namespace Sample03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Label01.Content = "rechne...";
            TaskScheduler ui = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew<double>(() =>
            {
                double x = 0;
                for (int a = 1; a < 100000000; a++)
                    x = Math.Log(a) / Math.Sqrt(a - Math.Sin(x));
                return x;
            }).ContinueWith((calc) =>
            {
                Label01.Content = string.Format("fertig: {0}", calc.Result);
            }, ui);
        }
    }
}
