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
    /// Interaction logic for LodgeTicket.xaml
    /// </summary>
    public partial class LodgeTicket : Window
    {
        public LodgeTicket()
        {
            InitializeComponent();
        }


        HousingDbContext db = new HousingDbContext();
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try {
                int unitID = Convert.ToInt32(txbUnitID.Text);
                string comp = new TextRange(tbComplaint.Document.ContentStart, tbComplaint.Document.ContentEnd).Text;


                ResidentTicket r = new ResidentTicket();
                Ticket t = new Ticket();

                t.Complaint = comp;
                db.Add(t);
                db.SaveChanges();

                r.TicketId = t.TicketId;
                r.UnitId = unitID;
                r.TicketStatus = "Pending";

                db.Add(r);
                db.SaveChanges();

                MessageBox.Show("Ticket has been successfully added. We will get back to you ASAP.");
                this.Close();
            }
            catch {
                MessageBox.Show("Something went wrong please try again");
            }
        }
    }
}
