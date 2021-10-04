using Housing.Views;
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

namespace Housing
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddResidents r = new AddResidents();
            this.Hide();
            r.ShowDialog();
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LodgeTicket lt = new LodgeTicket();
            this.Hide();
            lt.ShowDialog();
            this.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CheckTicketStatus cs = new CheckTicketStatus();
            this.Hide();
            cs.ShowDialog();
            this.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            this.Hide();
            md.ShowDialog();
            this.Show();
        }
    }
}
