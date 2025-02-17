﻿using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBroker
{
    public class Broker
    {
        SqlConnection connection;
        SqlTransaction transaction;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SeminarskiPS;Integrated Security=True;");
        }
        public SqlCommand KreirajKomandu()
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            return command;
        }
        
        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            if(connection != null & connection.State!=System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        
        public void BeginTransakcion()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            if(transaction!=null)
            {
                transaction.Commit();
            }
        }
        public void Rollback()
        {
            if(transaction!=null )
            {
                transaction.Rollback();
            }
        }
    
        
    
    }
}
