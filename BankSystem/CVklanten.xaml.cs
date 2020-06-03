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
        Klanten SelectedItem;
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
            if (txtVoornaam.Text.Equals("") || txtAchternaam.Text.Equals("") || txtAdres.Text.Equals("") || txtBSN.Text.Equals("") || txtVoorletters.Text.Equals("") || txtTelefoonnummer.Text.Equals("")
                || txtWoonplaats.Text.Equals("") || txtEmail.Text.Equals("") || txtPostCode.Text.Equals(""))
            {
                MessageBox.Show("Vul alle gegevens in");
            }
            else {
                string BSN = txtBSN.Text;
                string Voorletters = txtVoorletters.Text;
                string Voornaam = txtVoornaam.Text;
                string Achternaam = txtAchternaam.Text;
                string Woonplaats = txtWoonplaats.Text;
                string Telefoonnummer = txtTelefoonnummer.Text;
                string Email = txtEmail.Text;
                string Adres = txtAdres.Text;
                string PostCode = txtPostCode.Text;

                bc.addKlanten(BSN, Voorletters, Voornaam, Achternaam, Adres, Woonplaats, Telefoonnummer, Email, PostCode);

                txtAchternaam.Text = "";
                txtAdres.Text = "";
                txtVoornaam.Text = "";
                txtBSN.Text = "";
                txtEmail.Text = "";
                txtVoorletters.Text = "";
                txtWoonplaats.Text = "";
                txtAdres.Text = "";
                txtTelefoonnummer.Text = "";
                txtPostCode.Text = "";
            }
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            if (dgKlanten.Visibility == Visibility.Hidden)
            {
                dgKlanten.Visibility = Visibility.Visible;
            }
            else {
                dgKlanten.Visibility = Visibility.Hidden;
            }

            if (txtFilter.Visibility == Visibility.Hidden)
            {
                txtFilter.Visibility = Visibility.Visible;
            }
            else
            {
                txtFilter.Visibility = Visibility.Hidden;
            }

            if (txtfil.Visibility == Visibility.Hidden)
            {
                txtfil.Visibility = Visibility.Visible;
            }
            else
            {
                txtfil.Visibility = Visibility.Hidden;
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
            txtTelefoonnummer.Text = "";
            txtWoonplaats.Text = "";
            txtPostCode.Text = "";
        }
        private void dgKlanten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedItem = (Klanten)dgKlanten.SelectedItem;
            txtBSN.Text = SelectedItem.BSN;
            txtVoorletters.Text = SelectedItem.Voorletters;
            txtVoornaam.Text = SelectedItem.Voornaam;
            txtAchternaam.Text = SelectedItem.Achternaam;
            txtWoonplaats.Text = SelectedItem.Woonplaats;
            txtTelefoonnummer.Text = SelectedItem.Telefoonnummer;
            txtEmail.Text = SelectedItem.Email;
            txtAdres.Text = SelectedItem.Adres;
            txtPostCode.Text = SelectedItem.PostCode;
            
            if (dgKlanten.Visibility == Visibility.Visible)
            {
                dgKlanten.Visibility = Visibility.Hidden;
            }
        }
private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string BSN = txtBSN.Text;
            string Voorletters = txtVoorletters.Text;
            string Voornaam = txtVoornaam.Text;
            string Achternaam = txtAchternaam.Text;
            string Woonplaats = txtWoonplaats.Text;
            string Telefoonnummer = txtTelefoonnummer.Text;
            string Email = txtEmail.Text;
            string Adres = txtAdres.Text;
            string PostCode = txtPostCode.Text;

            bc.editKlant(SelectedItem.CustomerID, BSN, Voorletters, Voornaam, Achternaam, Woonplaats ,Telefoonnummer, Email, Adres, PostCode);

            if (dgKlanten.Visibility == Visibility.Hidden) 
            {
                dgKlanten.Visibility = Visibility.Visible;
            }

        }
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Klanten> FilteredRekeningen = (from Klanten in db.Klantens where Klanten.Voornaam.Contains(txtFilter.Text) select Klanten).ToList();
            dgKlanten.ItemsSource = FilteredRekeningen;
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            string BSN = txtBSN.Text;
            string Voorletters = txtVoorletters.Text;
            string Voornaam = txtVoornaam.Text;
            string Achternaam = txtAchternaam.Text;
            string Woonplaats = txtWoonplaats.Text;
            string Telefoonnummer = txtTelefoonnummer.Text;
            string Email = txtEmail.Text;
            string Adres = txtAdres.Text;
            string PostCode = txtPostCode.Text;

            bc.deleteKlant(SelectedItem.CustomerID, BSN, Voorletters, Voornaam, Achternaam, Woonplaats, Telefoonnummer, Email, Adres, PostCode);

            txtAchternaam.Text = "";
            txtAdres.Text = "";
            txtVoornaam.Text = "";
            txtBSN.Text = "";
            txtEmail.Text = "";
            txtVoorletters.Text = "";
            txtTelefoonnummer.Text = "";
            txtWoonplaats.Text = "";
            txtPostCode.Text = "";

            SetData();

            if (dgKlanten.Visibility == Visibility.Hidden)
            {
                dgKlanten.Visibility = Visibility.Visible;
            }
        }
    }
}
