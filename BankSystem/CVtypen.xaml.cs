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
    /// Interaction logic for CVtypen.xaml
    /// </summary>
    public partial class CVtypen : UserControl
    {
        BanksysteemDataContext db;
        BankController bc;
        public CVtypen(BanksysteemDataContext db)
        {
            InitializeComponent();
            this.db = db;
            bc = new BankController(db);
            SetData();
        }

        private void SetData() 
        {
            dgBanksysteem.ItemsSource = db.typens.ToList();
        }

        private void dgBanksysteem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string Naam = txtNaam.Text;
            string Rente = txtRente.Text;
            string Boete = txtBoete.Text;
            string MaxOpname = txtMaxOpname.Text;
          
            bc.addTypen(Naam, Rente, MaxOpname, Boete);

            txtNaam.Text = "";
            txtRente.Text = "";
            txtBoete.Text = "";
            txtMaxOpname.Text = "";

            SetData();
        }

    }
}
