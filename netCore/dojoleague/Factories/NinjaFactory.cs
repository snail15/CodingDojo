using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojoleague.Models;

namespace dojoleague.Factories
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;
        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojoDb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Ninja item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO ninjas (name, description,level, dojoId) VALUES (@Name, @Description, @Level, @DojoId)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }

        public void Delete(Ninja item)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string query = "DELETE FROM ninjas WHERE id= @Id";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Ninja> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas");
            }
        }
        public Ninja FindByID(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Ninja> NinjasForDojoById(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojoId WHERE dojos.id = ninjas.dojoId AND dojos.id = {id}";
                dbConnection.Open();

                var myNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.Dojo = dojo; return ninja; });
                return myNinjas;
            }
        }
    }
}