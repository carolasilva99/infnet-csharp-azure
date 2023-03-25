using FriendsAPI.Models;
using System.Data;
using AT.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace FriendsAPI.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly ConnectionStrings _connectionStrings;

        public FriendsService(IOptions<ConnectionStrings> optionsConnectionStrings)
        {
            _connectionStrings = optionsConnectionStrings.Value;
        }

        public Friend Create(Friend friend)
        {
            using var connection = new SqlConnection(_connectionStrings.Database);

            var procedureName = "CreateFriend";
            var sqlCommand = new SqlCommand(procedureName, connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FirstName", friend.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", friend.LastName);
            sqlCommand.Parameters.AddWithValue("@BirthDate", friend.BirthDate);
            sqlCommand.Parameters.AddWithValue("@Cellphone", friend.CellPhone);
            sqlCommand.Parameters.AddWithValue("@Email", friend.Email);
            sqlCommand.Parameters.AddWithValue("@CountryId", friend.CountryId);
            sqlCommand.Parameters.AddWithValue("@StateId", friend.StateId);
            sqlCommand.Parameters.AddWithValue("@PhotoId", friend.PhotoId);

            var createdFriend = new Friend();

            try
            {
                connection.Open();

                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    createdFriend = new Friend
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString() ?? string.Empty,
                        LastName = reader["LastName"].ToString() ?? string.Empty,
                        BirthDate = (DateTime)reader["BirthDate"],
                        Email = reader["Email"].ToString() ?? string.Empty,
                        CellPhone = reader["Cellphone"].ToString() ?? string.Empty,
                        CountryId = (int)reader["CountryId"],
                        StateId = (int)reader["StateId"],
                        PhotoId = reader["PhotoId"].ToString() ?? string.Empty,
                    };
                }
            }
            finally
            {
                connection.Close();
            }

            return createdFriend;
        }
    }
}
