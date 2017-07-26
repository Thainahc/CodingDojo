using System;
using MySql.Data.MySqlClient;
using Sommus.CodingDojo.Domain.Interfaces.Repositories;

namespace Sommus.CodingDojo.Data.ADO.Context
{
    public class DataContext : IDataContext
    {
        public static MySqlConnection MySqlConnection { get; set; }
        public static MySqlTransaction MySqlTransaction { get; set; }

        public void BeginTransaction()
        {
            MySqlConnection = new MySqlConnection
            {
                ConnectionString = "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=sommuscodingdojo"
            };
            MySqlConnection.Open();
            MySqlTransaction = MySqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            MySqlTransaction.Commit();
        }

        public void Rollback()
        {
            MySqlTransaction.Rollback();
        }

        public void Finally()
        {
            if (MySqlConnection != null)
            {
                MySqlTransaction.Dispose();
                MySqlConnection.Dispose();
                MySqlConnection.Close();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}