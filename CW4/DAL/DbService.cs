using CW4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CW4.DAL
{
    public class DbService : IDbService
    {
        private const string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19317;Integrated Security=True";

        public IEnumerable<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();

            using (var connection =
                new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19317;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select * from Animal ";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var animal = new Animal();
                    animal.Name = reader["Name"].ToString();
                    animal.Description = reader["Description"].ToString();
                    animal.IdAnimal = reader["IdAnimal"].ToString();
                    animal.Category = reader["Category"].ToString();
                    animal.Area = reader["Area"].ToString();
                    animals.Add(animal);
                }
            }

            return animals;
        }

        public Animal GetAnimal(int index)
        {
            using (var connection =
                new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19317;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select * from Animal where IdAnimal=@index";
                command.Parameters.AddWithValue("index", index);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var animal = new Animal();
                    animal.Name = reader["Name"].ToString();
                    animal.Description = reader["Description"].ToString();
                    animal.IdAnimal = reader["IdAnimal"].ToString();
                    animal.Category = reader["Category"].ToString();
                    animal.Area = reader["Area"].ToString();
                    return animal;
                }
                return null;

            }
        }
    }
}