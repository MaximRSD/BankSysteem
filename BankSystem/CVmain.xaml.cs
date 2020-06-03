using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
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
        rekeningen SelectedItem;
        
        
        public CVmain(BanksysteemDataContext db)
        {
            InitializeComponent();
            this.db = db;
            bc = new BankController(db);
            SetData();
        }

        private void SetData()
        { 
            dgBanksysteem.ItemsSource = bc.allRekening();
            cmbNaam.ItemsSource = bc.allKlanten();
            cmbNaam.DisplayMemberPath = "Voornaam";
            cmbBank.ItemsSource = bc.allBanken();
            cmbBank.DisplayMemberPath = "Naam";
        }

        private void dgBanksysteem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtNummer.Text.Equals("") || txtSaldo.Text.Equals("") || cmbBank.SelectedItem.Equals(null) || cmbNaam.SelectedItem.Equals(null) || dpSluitDatum.Text.Equals(""))
            {
                MessageBox.Show("Vul alle gegevens in");
            }
            else if(DateTime.TryParse(dpSluitDatum.Text, out DateTime dtSluitDatum))
           {
                Klanten klant = (Klanten)cmbNaam.SelectedItem;
                string Nummer = txtNummer.Text;
                typen Type = (typen)cmbBank.SelectedItem;
                string Saldo = txtSaldo.Text;
                DateTime SluitDatum = dtSluitDatum;

                bc.addRekening(Nummer,Saldo,Type,klant, SluitDatum);

                cmbNaam.SelectedItem = null;
                txtNummer.Text = "";
                txtSaldo.Text = "";
                cmbBank.SelectedItem = null;
                dpSluitDatum.Text = "";

                SetData();
            }
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            if (dgBanksysteem.Visibility == Visibility.Hidden)
            {
                dgBanksysteem.Visibility = Visibility.Visible;
            }
            else
            {
                dgBanksysteem.Visibility = Visibility.Hidden;
            }

            SetData();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cmbNaam.SelectedItem = null;
            txtNummer.Text = "";
            txtSaldo.Text = "";
            cmbBank.SelectedItem = null;
            dpSluitDatum.Text = "";
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<rekeningen> FilteredRekeningen = (from Rekeningen in db.rekeningens where Rekeningen.Klanten.Voornaam.Contains(txtFilter.Text) select Rekeningen).ToList();
            dgBanksysteem.ItemsSource = FilteredRekeningen;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(dpSluitDatum.Text, out DateTime dtSluitDatum))
                {
                Klanten klant = (Klanten)cmbNaam.SelectedItem;
                string Nummer = txtNummer.Text;
                typen Type = (typen)cmbBank.SelectedItem;
                string Saldo = txtSaldo.Text;
                DateTime SluitDatum = dtSluitDatum;

                bc.editRekening(Nummer, Saldo, Type, klant, SluitDatum);

                bc.save();

                if (dgBanksysteem.Visibility == Visibility.Hidden)
                {
                        dgBanksysteem.Visibility = Visibility.Visible;
                }
            } 
        }

        private void dgBanksysteem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            SelectedItem = (rekeningen)dgBanksysteem.SelectedItem;
            txtNummer.Text = SelectedItem.Nummer;
            txtSaldo.Text = SelectedItem.Saldo.ToString();
            cmbBank.SelectedItem = SelectedItem.typen;
            dpSluitDatum.Text = SelectedItem.SluitDatum.Value.ToString();
            cmbNaam.SelectedItem = ((rekeningen)dgBanksysteem.SelectedItem).Klanten;
           


            if (dgBanksysteem.Visibility == Visibility.Visible)
            {
                dgBanksysteem.Visibility = Visibility.Hidden;
            }
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(dpSluitDatum.Text, out DateTime dtSluitDatum))
            {
                Klanten klant = (Klanten)cmbNaam.SelectedItem;
                string Nummer = txtNummer.Text;
                typen Type = (typen)cmbBank.SelectedItem;
                string Saldo = txtSaldo.Text;
                DateTime SluitDatum = dtSluitDatum;

                bc.deleteMain(Nummer, Saldo, Type, klant, SluitDatum);

                cmbNaam.SelectedItem = null;
                txtNummer.Text = "";
                txtSaldo.Text = "";
                cmbBank.SelectedItem = null;
                dpSluitDatum.Text = "";

                SetData();

                if (dgBanksysteem.Visibility == Visibility.Visible)
                {
                    dgBanksysteem.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
