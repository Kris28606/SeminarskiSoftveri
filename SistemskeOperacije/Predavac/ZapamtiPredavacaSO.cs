﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.Predavac
{
    public class ZapamtiPredavacaSO : OpstaSO
    {
        public Domain.Predavac predavac;
        public ZapamtiPredavacaSO(Domain.Predavac p)
        {
            predavac = p;
        }
        protected override void IzvrsiKonkretnuOperaciju()
        {
            int idPredavac = repozitorijum.Sacuvaj(predavac);
            predavac.PredavacId = idPredavac;
            foreach (Domain.Kurs k in predavac.ListaKurseva)
            {
                Domain.KursPredavac kp = new Domain.KursPredavac
                {
                    Kurs= k,
                    Predavac=predavac
                };
                repozitorijum.Sacuvaj(kp);
            }
        }
    }
}
