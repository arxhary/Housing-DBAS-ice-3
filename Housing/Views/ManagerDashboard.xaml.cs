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
    /// Interaction logic for ManagerDashboard.xaml
    /// </summary>
    public partial class ManagerDashboard : Window
    {
        public ManagerDashboard()
        {
            InitializeComponent();
            foreach (var i in db.Residents)
            {
                cmbUnitID.Items.Add(i.UnitId);
            }
            cmbStatus.Items.Add("Working on it");
            cmbStatus.Items.Add("Dealt with");

        }

        HousingDbContext db = new HousingDbContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int unitID = Convert.ToInt32(cmbUnitID.Text);

            List<Ticket> lstTickets = db.Tickets.ToList();
            List<ResidentTicket> lstTicketStatus = db.ResidentTickets.Where(x => x.UnitId == unitID).ToList();


            foreach (var t in lstTickets)
            {
                foreach(var i in lstTicketStatus)
                {
                    if(t.TicketId == i.TicketId && i.UnitId == unitID)
                    {
                        i.TicketStatus = cmbStatus.Text;
                        db.SaveChanges();
                        MessageBox.Show("Updated Application status.");
                        this.Close();
                    }
                }
            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            redComplaint.Document.Blocks.Clear();
            
            int unitID = Convert.ToInt32(cmbUnitID.Text);

            
            List<ResidentTicket> lstTicketStatus = db.ResidentTickets.Where(x => x.UnitId == unitID).ToList();

            foreach (var i in lstTicketStatus)
            {
                foreach (var t in db.Tickets)
                {
                    if (Convert.ToInt32(i.TicketId) == t.TicketId)
                    {

                        redComplaint.AppendText(t.Complaint.ToString()+ i.TicketStatus);
                        
                    }
                }
            }
        }
    }
}
