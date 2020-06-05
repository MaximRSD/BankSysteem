using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public void addRekening(string Nummer, string Saldo, typen type,Klanten klant, DateTime SluitDatum)
        {
            if (decimal.TryParse(Saldo, out decimal dSaldo))
            {
                rekeningen R = new rekeningen();
                R.Nummer = Nummer;
                R.Saldo = dSaldo;
                R.TypeID = type.TypeID;
                R.OpenDatum = DateTime.Now;
                R.SluitDatum = SluitDatum;
                R.CustomerID = klant.CustomerID;

                db.rekeningens.InsertOnSubmit(R);
                db.SubmitChanges();
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
            K.Telefoonnummer = Telefoonnummer;
            K.Email = Email;
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

        public void editKlant(int CustomerID, String BSN, String Voorletters, String Voornaam, String Achternaam, String Adres, String Woonplaats, String Telefoonnummer, String Email, String PostCode)
        {
            Klanten P = (from Klanten in db.Klantens where Klanten.CustomerID == CustomerID select Klanten).Single();

            P.BSN = BSN;
            P.Voorletters = Voorletters;
            P.Voornaam = Voornaam;
            P.Achternaam = Achternaam;
            P.Adres = Adres;
            P.Woonplaats = Woonplaats;
            P.Telefoonnummer = Telefoonnummer;
            P.Email = Email;
            P.PostCode = PostCode;

            db.SubmitChanges();
        }

        public void editRekening(string Nummer, string Saldo, typen type, Klanten klant, DateTime SluitDatum)
        { 
            if (decimal.TryParse(Saldo, out decimal dSaldo))
            {
                rekeningen E = (from Rekeningen in db.rekeningens where Rekeningen.Nummer == Nummer select Rekeningen).Single();

                E.Nummer = Nummer;
                E.Saldo = dSaldo;
                E.TypeID = type.TypeID;
                E.SluitDatum = SluitDatum;
                E.CustomerID = klant.CustomerID;
            }
        }

        public void deleteKlant(int CustomerID, String BSN, String Voorletters, String Voornaam, String Achternaam, String Adres, String Woonplaats, String Telefoonnummer, String Email, String PostCode) 
        {
            Klanten D = (from Klanten in db.Klantens where Klanten.CustomerID == CustomerID select Klanten).Single();

            D.BSN = BSN;
            D.Voorletters = Voorletters;
            D.Voornaam = Voornaam;
            D.Achternaam = Achternaam;
            D.Adres = Adres;
            D.Woonplaats = Woonplaats;
            D.Telefoonnummer = Telefoonnummer;
            D.Email = Email;
            D.PostCode = PostCode;

            db.Klantens.DeleteOnSubmit(D);
            db.SubmitChanges();
        }

        public void deleteMain(string Nummer, string Saldo, typen type, Klanten klant, DateTime SluitDatum)
        {
            if (decimal.TryParse(Saldo, out decimal dSaldo))
            {
                rekeningen Y = (from Rekeningen in db.rekeningens where Rekeningen.Nummer == Nummer select Rekeningen).Single();

                Y.Nummer = Nummer;
                Y.Saldo = dSaldo;
                Y.TypeID = type.TypeID;
                Y.SluitDatum = SluitDatum;
                Y.CustomerID = klant.CustomerID;

                db.rekeningens.DeleteOnSubmit(Y);
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
