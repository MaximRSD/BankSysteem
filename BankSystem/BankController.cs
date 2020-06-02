using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankSystem
{
    class BankController
    {
        BanksysteemDataContext db;

        public BankController(BanksysteemDataContext db)
        {
            this.db = db;
        }

        public void addRekening(string Nummer, string Saldo, typen type, DateTime SluitDatum)
        {
            if (decimal.TryParse(Saldo, out decimal dSaldo))
            {
                rekeningen R = new rekeningen();
                R.Nummer = Nummer;
                R.Saldo = dSaldo;
                R.TypeID = type.TypeID;
                R.OpenDatum = DateTime.Now;
                R.SluitDatum = SluitDatum;

                db.rekeningens.InsertOnSubmit(R);
            }
        }

        public void addKlanten(String BSN, String Voorletters, String Voornaam, String Achternaam, String Adres, String Woonplaats, String Telefoonnummer, String Email, String PostCode)
        {
            Klanten K = new Klanten();
            K.BSN = BSN;
            K.Voorletters = Voorletters;
            K.Voornaam = Voornaam;
            K.Achternaam = Achternaam;
            K.Adres = Adres;
            K.Woonplaats = Woonplaats;
            K.Email = Email;
            K.Telefoonnummer = Telefoonnummer;
            K.PostCode = PostCode;

            db.Klantens.InsertOnSubmit(K);
            db.SubmitChanges();
        }

        public void addTypen(String Naam, String Rente, String MaxOpname, String Boete)
        {
            if (decimal.TryParse(Rente, out decimal dRente) && decimal.TryParse(MaxOpname, out decimal dMaxOpname) && decimal.TryParse(Boete, out decimal dBoete))
            {
                typen T = new typen();
                T.Naam = Naam;
                T.Rente = dRente;
                T.MaxOpname = dMaxOpname;
                T.Boete = dBoete;

                db.typens.InsertOnSubmit(T);
                db.SubmitChanges();
            }
        }

        public void save()
        {
            db.SubmitChanges();
        }

        public List<rekeningen> allRekening()
        {
            return db.rekeningens.ToList();
        }

        public List<Klanten> allKlanten()
        {
            return db.Klantens.ToList();
        }

        public List<typen> allBanken()
        {
            return db.typens.ToList();
        }
    }
}
