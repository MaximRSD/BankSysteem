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
    /// Interaction logic for CVklanten.xaml
    /// </summary>
    public partial class CVklanten : UserControl
    {
        BanksysteemDataContext db;
        BankController bc;
        public CVklanten(BanksysteemDataContext db)
        {
            InitializeComponent();
            this.db = db;
            bc = new BankController(db);
            SetData();
        }

        private void SetData()
        {
           dgKlanten.ItemsSource = bc.allKlanten();
        }

        private void btnKlanten_Click(object sender, RoutedEventArgs e)
        {
            string BSN = txtBSN.Text;
            string Voorletters = txtVoorletters.Text;
            string Voornaam = txtVoornaam.Text;
            string Achternaam = txtAchternaam.Text;
            string Telefoonnummer = txtTelefoonnummer.Text;
            string Woonplaats = txtWoonplaats.Text;
            string Email = txtEmail.Text;
            string Adres = txtAdres.Text;
            string PostCode = txtPostCode.Text;

            bc.addKlanten(BSN, Voorletters, Voornaam, Achternaam, Adres, Telefoonnummer, Woonplaats, Email, PostCode);

            txtAchternaam.Text = "";
            txtAdres.Text = "";
            txtVoornaam.Text = "";
            txtBSN.Text = "";
            txtEmail.Text = "";
            txtVoorletters.Text = "";
            txtAdres.Text = "";
            txtTelefoonnummer.Text = "";
            txtPostCode.Text = "";
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            if (dgKlanten.Visibility == Visibility.Collapsed)
            {
                dgKlanten.Visibility = Visibility.Visible;
            }
            else {
                dgKlanten.Visibility = Visibility.Collapsed;
            }

            SetData();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtAchternaam.Text = "";
            txtAdres.Text = "";
            txtVoornaam.Text = "";
            txtBSN.Text = "";
            txtEmail.Text = "";
            txtVoorletters.Text = "";
            txtAdres.Text = "";
            txtTelefoonnummer.Text = "";

        }
    }
}
