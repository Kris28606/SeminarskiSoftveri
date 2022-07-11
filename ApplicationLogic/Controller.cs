﻿using Domain;
using Repository;
using SistemskeOperacije;
using SistemskeOperacije.Faktura;
using SistemskeOperacije.Korisnik;
using SistemskeOperacije.Kurs;
using SistemskeOperacije.Predavac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic
{
    public class Controller
    {
        private static Controller instance;

        public List<Faktura> VratiSvefakture()
        {
            OpstaSO so = new UcitajListuFakturaSO();
            so.Izvrsi();
            return ((UcitajListuFakturaSO)so).Rezultat;
        }

        public User PrijavljeniKorisnik { get; private set; }

        public Array VratiSveNacinePlacanja()
        {
            return Enum.GetValues(typeof(Domain.NacinPlacanja));
        }

        public List<Kurs> VratiSveKurseve()
        {
            OpstaSO so = new UcitajListuKursevaSO();
            so.Izvrsi();
            return ((UcitajListuKursevaSO)so).Rezultat;
        }

        public Array VratiSvePolove()
        {
            return Enum.GetValues(typeof(Domain.Pol));
        }

        public List<Faktura> NadjiFakture(string kriterijum)
        {
            OpstaSO so = new NadjiFaktureSO(kriterijum);
            so.Izvrsi();
            return ((NadjiFaktureSO)so).Rezultat;
        }

        public List<Kurs> VratiSveKurseveZaPredavaca(Predavac p)
        {
            OpstaSO so = new NadjiKurseveZaPredavacaSO(p);
            so.Izvrsi();
            return ((NadjiKurseveZaPredavacaSO)so).Rezultat;
        }

        public List<Korisnik> VratiSveKorisnike()
        {
            OpstaSO so = new UcitajListuKorisnikaSO();
            so.Izvrsi();
            return ((UcitajListuKorisnikaSO)so).Rezultat;
        }

        public void ObrisiKorisnika(Korisnik korisnik)
        {
            OpstaSO so = new ObrisiKorisnikaSO(korisnik);
            so.Izvrsi();
        }

        public List<Korisnik> NadjiKorisnika(string kriterijum)
        {
            OpstaSO so = new NadjiKorisnikeSO(kriterijum);
            so.Izvrsi();
            return ((NadjiKorisnikeSO)so).Rezultat;
        }

        public List<Mesto> VratiSvaMesta()
        {
            OpstaSO so = new UcitajListuMestaSO();
            so.Izvrsi();
            return ((UcitajListuMestaSO)so).Rezultat;
        }

        public List<Kurs> VratiSveKurseveZaKorisnika(Korisnik korisnik)
        {
            OpstaSO so = new NadjiKurseveZaKorisnikaSO(korisnik);
            so.Izvrsi();
            return ((NadjiKurseveZaKorisnikaSO)so).Rezultat;
        }

        public void StornirajFakturu(Faktura faktura)
        {
            OpstaSO so = new StornirajFakturuSO(faktura);
            so.Izvrsi();
        }

        private Controller()
        {
            
        }

        public List<Predavac> NadjiPredavace(string kriterijum)
        {
            OpstaSO so = new NadjiPredavaceSO(kriterijum);
            so.Izvrsi();
            return ((NadjiPredavaceSO)so).Rezultat;
        }

        public void SacuvajKorisnika(Korisnik k)
        {
            OpstaSO so = new ZapamtiKorisnikaSO(k);
            so.Izvrsi();
        }

        public static Controller Instance { 

            get { 
                if(instance == null)
                {
                    instance = new Controller(); 
                }
                return instance; 
            } 
        }

        public List<Predavac> VratiSvePredavace()
        {
            OpstaSO so = new UcitajListuPredavacaSO();
            so.Izvrsi();
            return ((UcitajListuPredavacaSO)so).Rezultat;
        }

        public List<Kurs> NadjiKurseve(string kriterijum)
        {
            OpstaSO so = new NadjiKurseveSO(kriterijum);
            so.Izvrsi();
            return ((NadjiKurseveSO)so).Rezultat;
        }

        public User LogIn(User user)
        {
            OpstaSO so = new PrijavaSO(user);
            so.Izvrsi();
            return ((PrijavaSO)so).Rezultat;
        }

        public void DodajKurs(Kurs k)
        {
            OpstaSO so = new ZapamtiKursSO(k);
            so.Izvrsi();
        }

        public void IzmeniKurs(Kurs k)
        {
            OpstaSO so = new IzmeniKursSO(k);
            so.Izvrsi();
        }

        public void SacuvajFakturu(Faktura faktura)
        {
            OpstaSO so = new ZapamtiFakturuSO(faktura);
            so.Izvrsi();
        }

        public void SacuvajPredavaca(Predavac p)
        {
            OpstaSO so = new ZapamtiPredavacaSO(p);
            so.Izvrsi();
        }

        public void IzmeniPredavaca(Predavac p)
        {
            OpstaSO so = new IzmeniPredavacaSO(p);
            so.Izvrsi();
        }
    }
}
