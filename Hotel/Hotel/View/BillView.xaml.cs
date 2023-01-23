using System.Collections.Generic;
using System.Windows.Controls;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for BillView.xaml
    /// </summary>
    public partial class BillView : UserControl
    {
        public BillView()
        {
            InitializeComponent();
            invoices=new List<Invoice>();
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            invoices.Add(new Invoice() { ID="12", RoomID="P101", StaffName="Nguyen Khoi", Total="10000022"});
            this.DataContext = invoices;
        }
        public List<Invoice> invoices;

        private void OpenBillDetail(object sender, System.Windows.RoutedEventArgs e)
        {
            BillDetail newbillDetail = new BillDetail();
            newbillDetail.ShowDialog();
        }
    }
    public class Invoice
    {
        public string  ID { get; set; }
        public string RoomID { get; set; }
        public string StaffName { get; set; }
        public string Total { get; set; }
        public Invoice() { }
    }
}
