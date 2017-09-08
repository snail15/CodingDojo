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
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Ninja item, Dojo dojo)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO ninjas (name, description,level) VALUES (@Name, @Description, @Level)";
                item.Dojo = dojo;
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }

        public void Delete(Ninja item) {

            using (IDbConnection dbConnection = Connection) {
                string query =  "DELETE FROM ninjas WHERE id= @Id";
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
        public Ninja FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}