using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Sommus.CodingDojo.Data.ADO.Context;
using Sommus.CodingDojo.Domain.Entities;
using Sommus.CodingDojo.Domain.Interfaces.Repositories;

namespace Sommus.CodingDojo.Data.ADO.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public void Add(Pessoa pessoa)
        {
            var query = new StringBuilder();
            query.Append(" INSERT INTO pessoa       ");
            query.Append(" (                        ");
            query.Append("  nome,                   ");
            query.Append("  cpf                     ");
            query.Append(" )                        ");
            query.Append(" VALUES                   ");
            query.Append(" (                        ");
            query.Append("  ?nome,                  ");
            query.Append("  ?cpf                    ");
            query.Append(" );                       ");
            query.Append(" SELECT LAST_INSERT_ID(); ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?nome", pessoa.Nome);
            mySqlCommand.Parameters.AddWithValue("?cpf", pessoa.CPF);

            pessoa.PessoaId = Convert.ToInt32(mySqlCommand.ExecuteScalar());
        }

        public void Update(Pessoa pessoa)
        {
            var query = new StringBuilder();
            query.Append(" UPDATE pessoa                ");
            query.Append(" SET                          ");
            query.Append("  nome           = ?nome,     ");
            query.Append("  cpf            = ?cpf       ");
            query.Append(" WHERE pessoa_id = ?pessoa_id ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?nome", pessoa.Nome);
            mySqlCommand.Parameters.AddWithValue("?cpf", pessoa.CPF);
            mySqlCommand.Parameters.AddWithValue("?pessoa_id", pessoa.PessoaId);

            mySqlCommand.ExecuteNonQuery();
        }

        public void Delete(int pessoaId)
        {
            var query = new StringBuilder();
            query.Append(" DELETE FROM pessoa           ");
            query.Append(" WHERE pessoa_id = ?pessoa_id ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?pessoa_id", pessoaId);

            mySqlCommand.ExecuteNonQuery();
        }

        public List<Pessoa> Get()
        {
            var query = new StringBuilder();
            query.Append(" SELECT *    ");
            query.Append(" FROM pessoa ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            var pessoas = new List<Pessoa>();

            while (reader.Read())
            {
                pessoas.Add(new Pessoa()
                {
                    PessoaId = reader.GetInt32("pessoa_id"),
                    Nome = reader.GetString("nome"),
                    CPF = reader.GetString("cpf")
                });
            }
            reader.Close();

            return pessoas;
        }


        public Pessoa Get(int pessoaId)
        {
            var query = new StringBuilder();
            query.Append(" SELECT *                     ");
            query.Append(" FROM pessoa                  ");
            query.Append(" WHERE pessoa_id = ?pessoa_id ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?pessoa_id", pessoaId);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (reader.Read())
            {
                Pessoa produto = new Pessoa()
                {
                    PessoaId = reader.GetInt32("pessoa_id"),
                    Nome = reader.GetString("nome"),
                    CPF = reader.GetString("cpf")
                };
                reader.Close();

                return produto;
            }
            reader.Close();

            return new Pessoa();
        }
    }
}