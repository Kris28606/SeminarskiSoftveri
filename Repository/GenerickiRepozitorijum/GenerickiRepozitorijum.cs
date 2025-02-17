﻿using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenerickiRepozitorijum
{
    public class GenerickiRepozitorijum : IRepozitorijum<IOpstiObjekat>
    {
        private Broker broker = new Broker();

        public void Commit()
        {
            broker.Commit();
        }
        public void OtvoriKonekciju()
        {
            broker.OpenConnection();
        }
        public void RollBack()
        {
            broker.Rollback();
        }
        public void ZapocniTransakciju()
        {
            broker.BeginTransakcion();
        }
        public void ZatvoriKonekciju()
        {
            broker.CloseConnection();
        }

        public int Sacuvaj(IOpstiObjekat objekat)
        {
            SqlCommand command = broker.KreirajKomandu();
            command.CommandText = $"insert into {objekat.NazivTabele} output inserted.{objekat.Output} values {objekat.Vrednosti}";
            return (int)command.ExecuteScalar();
        }

        public int Izmeni(IOpstiObjekat objekat)
        {
            SqlCommand command = broker.KreirajKomandu();
            command.CommandText = $"update {objekat.NazivTabele} set {objekat.UpdateUslov} where {objekat.Uslov}";
            return command.ExecuteNonQuery();
            
        }

        public int Izbrisi(IOpstiObjekat objekat)
        {
            SqlCommand command = broker.KreirajKomandu();
            command.CommandText = $"delete from {objekat.NazivTabele} where {objekat.Uslov}";
            return command.ExecuteNonQuery();
        }

        public List<IOpstiObjekat> VratiSve(IOpstiObjekat objekat)
        {
            List<IOpstiObjekat> lista = new List<IOpstiObjekat>();
            SqlCommand command = broker.KreirajKomandu();
            command.CommandText = $"select * from {objekat.NazivTabele} {objekat.JoinUslov}";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(objekat.ProcitajObjekat(reader));
                }
            }
            return lista;
        }

        public List<IOpstiObjekat> Pretraga(IOpstiObjekat objekat, string kriterijum)
        {
            List<IOpstiObjekat> lista = new List<IOpstiObjekat>();
            SqlCommand command = broker.KreirajKomandu();
            command.CommandText = $"select * from {objekat.NazivTabele} {objekat.JoinUslov} where ({objekat.Kriterijum} '%{kriterijum}%')";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(objekat.ProcitajObjekat(reader));
                }
            }
            return lista;
        }

        public IOpstiObjekat VratiJedan(IOpstiObjekat objekat)
        {
            SqlCommand command = broker.KreirajKomandu();
            command.CommandText = $"select * from {objekat.NazivTabele} {objekat.JoinUslov} where {objekat.Uslov}";
            IOpstiObjekat rezultat;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return null;
                }
                rezultat = objekat.ProcitajObjekat(reader);
            }
            return rezultat;
        }

        public List<IOpstiObjekat> VratiSveZaNekog(IOpstiObjekat objekat)
        {
            List<IOpstiObjekat> lista = new List<IOpstiObjekat>();
            SqlCommand command = broker.KreirajKomandu();
            command.CommandText = $"select * from {objekat.NazivTabele} {objekat.JoinUslov} where {objekat.Uslov}";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(objekat.ProcitajObjekat(reader));
                }
            }
            return lista;
        }
    }
}
