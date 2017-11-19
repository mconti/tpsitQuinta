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

namespace WpfApp1
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persone persone;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                persone = new Persone("Persone.csv");
                dgDati.ItemsSource = persone;

                // LINQ
                var anni = (from p in persone
                            orderby p.Data.Year descending
                            select p.Data.Year).Distinct();

                cboxAnni.ItemsSource = anni;
                cboxAnni.SelectedIndex = 0;
            }
            catch { }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int anno = (int)cboxAnni.SelectedValue;

            var filtrate = (from p in persone
                           where p.Data.Year == anno
                           select p).OrderBy( p=>p.Data );

            dgDati.ItemsSource = filtrate;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            persone = new Persone("Persone.csv");
            dgDati.ItemsSource = persone;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            persone.SalvaCSV("Persone.csv");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            persone = new Persone(30);
            dgDati.ItemsSource = persone;

            var anni = (from p in persone
                        select p.Data.Year).Distinct();

            cboxAnni.ItemsSource = anni;
            cboxAnni.SelectedIndex = 0;

        }
    }
}
