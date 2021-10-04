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
    /// Interaction logic for CheckTicketStatus.xaml
    /// </summary>
    public partial class CheckTicketStatus : Window
    {
        public CheckTicketStatus()
        {
            InitializeComponent();
            foreach (var i in db.Residents)
            {
                cmbUnitID.Items.Add(i.UnitId);
            }
        }

        HousingDbContext db = new HousingDbContext();

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstbxStatus.Items.Clear();
                int unitID = Convert.ToInt32(cmbUnitID.Text);

                List<ResidentTicket> lstTicketStatus = db.ResidentTickets.Where(x => x.UnitId == unitID).ToList();
                

                foreach (var i in lstTicketStatus)
                {
                    foreach(var t in db.Tickets)
                    {
                        if(Convert.ToInt32(i.TicketId) == t.TicketId)
                        {

                            lstbxStatus.Items.Add("Complaint: "+t.Complaint+"Status: "+i.TicketStatus);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unit ID not found or no complaint found.");
            }
        }
    }
}
