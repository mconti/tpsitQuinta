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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace conti.maurizio._3G.Countdown
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            dpDataUtente.SelectedDate = new DateTime(DateTime.Now.Year, 12, 25, 0, 0, 0);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // <DatePicker Grid.Column="5" Grid.Row="0" Name="dpDataUtente"></DatePicker>
            if (dpDataUtente.SelectedDate != null)
            {
                DateTime dataTarget = dpDataUtente.SelectedDate.Value;
                TimeSpan differenza = dataTarget.Subtract(DateTime.Now);

                displaySecondi.Text = differenza.Seconds.ToString();
                displayMinuti.Text = differenza.Minutes.ToString();
                displayOre.Text = differenza.Hours.ToString();
                displayGiorni.Text = differenza.Days.ToString();
            }
        }
    }
}
