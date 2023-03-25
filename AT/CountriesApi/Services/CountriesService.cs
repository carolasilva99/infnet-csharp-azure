using AT.Domain;
using FriendsAPI.Models;
using Microsoft.Extensions.Options;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CountriesApi.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ConnectionStrings _connectionStrings;

        public CountriesService(IOptions<ConnectionStrings> optionsConnectionStrings)
        {
            _connectionStrings = optionsConnectionStrings.Value;
        }

        public Country Create(Country country)
        {
            using var connection = new SqlConnection(_connectionStrings.Database);

            var procedureName = "CreateCountry";
            var sqlCommand = new SqlCommand(procedureName, connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", country.Name);
            sqlCommand.Parameters.AddWithValue("@PhotoId", country.PhotoId);

            var createdCountry = new Country();

            try
            {
                connection.Open();

                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    createdCountry = new Country
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString() ?? string.Empty,
                        PhotoId = reader["PhotoId"].ToString() ?? string.Empty,
                    };
                }
            }
            finally
            {
                connection.Close();
            }

            return createdCountry;
        }
    }
}
