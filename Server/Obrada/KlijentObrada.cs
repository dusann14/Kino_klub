 using Common.Domen;
using Common.Transfer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Obrada
{
    public class KlijentObrada
    {
        private Sender sender;
        private Receiver receiver;
        private Socket soket;

        public KlijentObrada(Socket soket, Sender sender, Receiver receiver)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.soket = soket;
        }

        internal void Obradi()
        {
            try
            {
                while (true)
                {
                    Zahtev zahtev = (Zahtev)receiver.Primi();
                    Odgovor odgovor;

                    if (zahtev.Operacija == Operacije.Odjava)
                    {
                        Stop();
                        break;
                    }

                    try
                    {
                        odgovor = Odgovori(zahtev);
                    }
                    catch (Exception e)
                    {
                        odgovor = new Odgovor();
                        odgovor.Uspesno = false;
                        odgovor.Greska = e.Message;
                    }

                    sender.Posalji(odgovor);
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }

           
        }

        private Odgovor Odgovori(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Uspesno = true;

            switch (zahtev.Operacija)
            {
                case Operacije.Prijava:
                    odgovor.Rezultat = Kontroler.Instance.Prijava((Korisnik)zahtev.Objekat);
                    break;
                case Operacije.VratiUloge:
                    odgovor.Rezultat = Kontroler.Instance.VratiUloge();
                    break;
                case Operacije.VratiZanrove:
                    odgovor.Rezultat = Kontroler.Instance.VratiZanrove();
                    break;
                case Operacije.VratiReditelje:
                    odgovor.Rezultat = Kontroler.Instance.VratiReditelje();
                    break;
                case Operacije.ZapamtiFilm:
                    Kontroler.Instance.ZapamtiFilm((Film)zahtev.Objekat);
                    break;
                case Operacije.VratiFilmove:
                    odgovor.Rezultat = Kontroler.Instance.VratiFilmove();
                    break;
                case Operacije.VratiFilmovePoNazivu:
                    odgovor.Rezultat = Kontroler.Instance.VratiFilmovePoNazivu((Film)zahtev.Objekat);
                    break;
                case Operacije.ZapamtiIznajmljivanje:
                    Kontroler.Instance.ZapamtiIznajmljivanje((Iznajmljivanje)zahtev.Objekat);
                    break;
                case Operacije.VratiIznajmlijvanja:
                    odgovor.Rezultat = Kontroler.Instance.VratiIznajmlijvanja();
                    break;
                case Operacije.VratiIznajmlijvanjaPoImenuKorisnika:
                    odgovor.Rezultat = Kontroler.Instance.VratiIznajmlijvanjaPoImenuKorisnika((Iznajmljivanje)zahtev.Objekat);
                    break;
                case Operacije.ZapamtiRacun:
                    Kontroler.Instance.ZapamtiRacun((Racun)zahtev.Objekat);
                    break;
                case Operacije.VratiOcene:
                    odgovor.Rezultat = Kontroler.Instance.VratiOcene();
                    break;
                case Operacije.OceniFilm:
                    Kontroler.Instance.OceniFilm((Ocena)zahtev.Objekat);
                    break;
                case Operacije.ZapamtiKorisnika:
                    Kontroler.Instance.ZapamtiKorisnika((Korisnik)zahtev.Objekat);
                    break;
            }

            return odgovor;
        }

        internal void Stop()
        {
            soket.Close();
        }
    }
}
