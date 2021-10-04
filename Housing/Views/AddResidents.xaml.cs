using Housing.Data;
using Housing.Models;
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

namespace Housing.Views
{
    /// <summary>
    /// Interaction logic for AddResidents.xaml
    /// </summary>
    public partial class AddResidents : Window
    {
        public AddResidents()
        {
            InitializeComponent();
        }
        HousingDbContext db = new HousingDbContext();
        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int unitID = Convert.ToInt32(txbUnitID.Text);
                string name = txbName.Text;
                string surname = txbSurname.Text;
                string email = txbEmailAddress.Text;
                string cell = txbCellNumber.Text;

                Resident r = new Resident();

                r.UnitId = unitID;
                r.Name = name;
                r.Surname = surname;
                r.EmailAddress = email;
                r.CellNumber = cell;
                db.Add(r);
                db.SaveChanges();

                MessageBox.Show("Details saved.");
                this.Close();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ensure all fields are entered");
            }
        }
    }
}
