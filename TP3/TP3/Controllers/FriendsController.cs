using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TP3.Models;

namespace TP3.Controllers
{
    public class FriendsController : Controller
    {
        // GET: FriendsController
        public ActionResult Index()
        {
            var friends = new List<FriendModel>();

            var connectionString =
                $"Server=tcp:tp3-csharp.database.windows.net,1433;Initial Catalog=TP3;Persist Security Info=False;User ID=CloudSA4160fcb2;Password=vmc6txd1vcu5hvt*AMW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "ReadFriends";
                var sqlCommand = new SqlCommand(procedureName, connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var friend = new FriendModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]
                            };

                            friends.Add(friend);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return View(friends);
        }

        // GET: FriendsController/Details/5
        public ActionResult Details(int id)
        {
            var friend = default(FriendModel);

            var connectionString =
                $"Server=tcp:tp3-csharp.database.windows.net,1433;Initial Catalog=TP3;Persist Security Info=False;User ID=CloudSA4160fcb2;Password=vmc6txd1vcu5hvt*AMW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "ReadFriend";
                var sqlCommand = new SqlCommand(procedureName, connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            friend = new FriendModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]
                            };
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return View(friend);
        }

        // GET: FriendsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName,LastName,BirthDate")] FriendModel friend)
        {
            var connectionString =
                $"Server=tcp:tp3-csharp.database.windows.net,1433;Initial Catalog=TP3;Persist Security Info=False;User ID=CloudSA4160fcb2;Password=vmc6txd1vcu5hvt*AMW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "CreateFriend";
                var sqlCommand = new SqlCommand(procedureName, connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@FirstName", friend.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", friend.LastName);
                sqlCommand.Parameters.AddWithValue("@BirthDate", friend.BirthDate);

                try
                {
                    connection.Open();

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            friend = new FriendModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]
                            };
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return RedirectToAction("Index");
        }

        // GET: FriendsController/Edit/5
        public ActionResult Edit(int id)
        {
            var friend = default(FriendModel);

            var connectionString =
                $"Server=tcp:tp3-csharp.database.windows.net,1433;Initial Catalog=TP3;Persist Security Info=False;User ID=CloudSA4160fcb2;Password=vmc6txd1vcu5hvt*AMW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "ReadFriend";
                var sqlCommand = new SqlCommand(procedureName, connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            friend = new FriendModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]
                            };
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return View(friend);
        }

        // POST: FriendsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,BirthDate")] FriendModel friend)
        {
            var connectionString =
                $"Server=tcp:tp3-csharp.database.windows.net,1433;Initial Catalog=TP3;Persist Security Info=False;User ID=CloudSA4160fcb2;Password=vmc6txd1vcu5hvt*AMW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "UpdateFriend";
                var sqlCommand = new SqlCommand(procedureName, connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@FirstName", friend.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", friend.LastName);
                sqlCommand.Parameters.AddWithValue("@BirthDate", friend.BirthDate);

                try
                {
                    connection.Open();

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            friend = new FriendModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]
                            };
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return View(friend);
        }

        // GET: FriendsController/Delete/5
        public ActionResult Delete(int id)
        {
            var friend = default(FriendModel);

            var connectionString =
                $"Server=tcp:tp3-csharp.database.windows.net,1433;Initial Catalog=TP3;Persist Security Info=False;User ID=CloudSA4160fcb2;Password=vmc6txd1vcu5hvt*AMW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "ReadFriend";
                var sqlCommand = new SqlCommand(procedureName, connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            friend = new FriendModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]
                            };
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return RedirectToAction("Index");
        }

        // POST: FriendsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var connectionString =
                $"Server=tcp:tp3-csharp.database.windows.net,1433;Initial Catalog=TP3;Persist Security Info=False;User ID=CloudSA4160fcb2;Password=vmc6txd1vcu5hvt*AMW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var friend = default(FriendModel);

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "DeleteFriend";
                var sqlCommand = new SqlCommand(procedureName, connection);
                
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            friend = new FriendModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]
                            };
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
