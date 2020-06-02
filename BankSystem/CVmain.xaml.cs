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

namespace BankSystem
{
    /// <summary>
    /// Interaction logic for CVmain.xaml
    /// </summary>
    public partial class CVmain : UserControl
    {
        BanksysteemDataContext db;
        BankController bc;
        public CVmain(BanksysteemDataContext db)
        {
            InitializeComponent();
            this.db = db;
            bc = new BankController(db);
            SetData();

        }

        private void SetData() 
        {
            dgBanksysteem.DisplayMemberPath = "typen";
            dgBanksysteem.ItemsSource = bc.allRekening();
            cmbTypen.ItemsSource = bc.allKlanten();
            cmbTypen.DisplayMemberPath = "Voornaam";
        }

        private void dgBanksysteem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
       
        }
    }
}
