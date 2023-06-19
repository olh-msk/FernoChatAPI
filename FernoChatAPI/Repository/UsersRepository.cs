using FernoChatAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FernoChatAPI.Repository
{
    public class UserRepository
    {
        private DatabaseConnection dbConnection;

        public UserRepository(DatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                string query = "SELECT * FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                UserEmail = reader["UserEmail"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public Users GetUserById(int userId)
        {
            Users user = null;

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                string query = "SELECT * FROM Users WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Users
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                UserEmail = reader["UserEmail"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }

            return user;
        }

        public void CreateUser(Users user)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                string query = "INSERT INTO Users (UserId, UserName, UserEmail, CreatedAt) VALUES (@UserId, @UserName, @UserEmail, @CreatedAt)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(Users user)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                string query = "UPDATE Users SET UserName = @UserName, UserEmail = @UserEmail, CreatedAt = @CreatedAt WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                string query = "DELETE FROM Users WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
