using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace Repositories
{
    public class TodoRepository : ConnectionUtil, Interfaces.ITodoRepository
    {
        public TodoRepository(IConfiguration config) : base(config) { }

        public void Add(Todo obj)
        {
            string sql = "INSERT INTO todo (ID, Horario, Tarefa, ID_PESSOA) VALUES(null, @Horario, @Tarefa, @IdPessoa)";
            DynamicParameters pam = new DynamicParameters();
            pam.Add("@Horario", obj.Horario);
            pam.Add("@Tarefa", obj.Tarefa);
            pam.Add("@IdPessoa", obj.Pessoa.Id);

            using(var db = new MySqlConnection(base.GetConnection()))
            {
                db.Execute(sql, pam);
            }
        }

        public Todo Get(int id)
        {
            string sql = $@"SELECT * FROM todo 
            JOIN pessoa ON todo.ID_PESSOA = pessoa.ID
            WHERE todo.ID = {id}";

            using (var db = new MySqlConnection(base.GetConnection()))
            {
                return db.Query<Todo, Pessoa, Todo>(sql, map: (todo, pessoa) =>
                {
                    todo.Pessoa = pessoa;
                    return todo;
                }).FirstOrDefault();
            }
        }

        public IEnumerable<Todo> GetAll()
        {
            string sql = @"SELECT * FROM todo 
            JOIN pessoa ON todo.ID_PESSOA = pessoa.ID";

            using (var db = new MySqlConnection(base.GetConnection()))
            {
                return db.Query<Todo, Pessoa, Todo>(sql, map: (todo, pessoa) =>
                {
                    todo.Pessoa = pessoa;
                    return todo;
                });
            }
        }

        public void Remove(int id)
        {
            DynamicParameters pam = new DynamicParameters();
            pam.Add("@Id", id);

            using (var db = new MySqlConnection(base.GetConnection()))
            {
                var sql = "DELETE FROM todo WHERE todo.ID = @Id";
                db.Execute(sql, pam);
            }
        }

        public void Update(Todo obj)
        {
            using(var db = new MySqlConnection(base.GetConnection()))
            {
                var sql = $@"UPDATE todo
                        SET Horario = @Horario,
                        ID_PESSOA = @Pessoa,
                        Tarefa = @Tarefa
                        WHERE todo.ID = {obj.Id}";

                DynamicParameters pam = new DynamicParameters();
                pam.Add("@Pessoa", obj.Pessoa.Id);
                pam.Add("@Horario", obj.Horario);
                pam.Add("@Tarefa", obj.Tarefa);

                var count = db.Execute(sql, pam);
            }
        }
    }
}
