using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper; 

namespace Repositories
{
    public class PessoaRepository : ConnectionUtil, Interfaces.IPessoaRepository
    {
        public PessoaRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Pessoa obj)
        {
            throw new NotImplementedException();
        }

        public Pessoa Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> GetAll()
        {
            using(var db = new MySql.Data.MySqlClient.MySqlConnection(base.GetConnection()))
            {
                return db.Query<Entities.Pessoa>("SELECT * FROM pessoa");
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pessoa obj)
        {
            throw new NotImplementedException();
        }
    }
}
