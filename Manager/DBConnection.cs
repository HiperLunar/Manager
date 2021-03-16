
using System;
using System.Data;
using System.Data.SqlClient;
using Id = System.Guid;


namespace Manager
{
    public struct DBResult
    {
        public object result;
        public string reason;
    }

    public class DBConnection
    {
        /*
         * 
         * The class DBConnection establish a connection with the data base 
         * 
         */

        private static readonly string ConnectionString = String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0}\\Database1.mdf;Integrated Security=True", System.IO.Directory.GetCurrentDirectory());
        private SqlConnection connection = new SqlConnection(ConnectionString);

        public bool connect()
            // connect to server if not connected
            // return true if connected successfuly or false if catch an error
        {
            if (connection.State != System.Data.ConnectionState.Open)   // if not connected...
            {
                connection.Open();  // connect
            }
            return true;
        }

        public void disconnect()
            // disconnect if connected
        {
            if (connection.State != System.Data.ConnectionState.Closed) // if connected...
            {
                connection.Close(); // disconnect
            }
        }

        public User[] GetUserList()  // get user list from User table
        {
            string query = "SELECT * FROM [dbo].[User]";    // SQL query string

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);

            User[] list = new User[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new User(table.Rows[i]); }

            return list;
        }

        public User GetUserById(Id id)  // get user list from User table
        {
            string query = "SELECT * FROM [dbo].[User] WHERE Id=@id";    // SQL query string

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            return new User(table.Rows[0]);
        }

        public DBResult AddUser(User user) // insert user to User table
        {
            try
            {
                string query = "INSERT INTO [User] (Name, Age, Email, Description) VALUES (@name, @age, @email, @description)";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@age", user.age);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("description", user.description);
                int n = command.ExecuteNonQuery();
                return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    return new DBResult { result = false, reason = "User already exists" };
                }
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n"+e.Message };
            }
        }

        public DBResult DeleteUserById(Id id)  // delete user with specific id
        {
            try
            {
                string query = "DELETE FROM [User] WHERE Id=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
                } else
                {
                    return new DBResult { result = false, reason = "User does not exists" };

                }
            }
            catch (SqlException)
            {
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n" + e.Message };
            }
        }

        public DBResult UpdateUser(User user)  // update information of user with specific id
        {
            try
            {
                string query = "UPDATE [User] SET Name=@name, Age=@age, Email=@email, Description=@description WHERE Id=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@age", user.age);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@description", user.description);
                command.Parameters.AddWithValue("@id", user.id);
                int n = command.ExecuteNonQuery();
                return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    return new DBResult { result = false, reason = "User already exists" };
                }
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n" + e.Message };
            }
        }

        public Address[] GetAddressList()  // get address list from Address table
        {
            string query = "SELECT * FROM [dbo].[Address]";    // SQL query string

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);

            Address[] list = new Address[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new Address(table.Rows[i]); }

            return list;
        }

        public DBResult AddAddress(Address address) // insert address to Address table
        {
            try
            {
                string query = "INSERT INTO [Address] (AddressInfo, IsCommercial) VALUES (@info, @com)";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@info", address.info);
                command.Parameters.AddWithValue("@com", address.isCommercial);
                int n = command.ExecuteNonQuery();
                return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    return new DBResult { result = false, reason = "Address already exists" };
                }
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n" + e.Message };
            }
        }

        public DBResult DeleteAddressById(Id id)  // delete address with specific id
        {
            try
            {
                string query = "DELETE FROM [Address] WHERE Id=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
                }
                else
                {
                    return new DBResult { result = false, reason = "Address does not exists" };

                }
            }
            catch (SqlException)
            {
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n" + e.Message };
            }
        }

        public DBResult UpdateAddress(Address address)  // update address with specific id
        {
            try
            {
                string query = "UPDATE [Address] SET AddressInfo=@info, IsCommercial=@com WHERE Id=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@info", address.info);
                command.Parameters.AddWithValue("@com", address.isCommercial);
                command.Parameters.AddWithValue("@id", address.id);
                int n = command.ExecuteNonQuery();
                return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    return new DBResult { result = false, reason = "Address already exists" };
                }
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n" + e.Message };
            }
        }

        public Address[] GetAddressByUserId(Id id)
        {
            string query = @"SELECT B.* FROM
                [UserAddress] AS A
                INNER JOIN [Address] AS B
                ON [A].[AddressId] = [B].[Id]
                WHERE [A].[UserId]=@id
                ORDER BY B.[Id]";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());


            Address[] list = new Address[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new Address(table.Rows[i]); }

            return list;
        }

        public DBResult AddUserAddress(Id userId, Id addressId)
        {
            try
            {
                string query = "INSERT INTO [UserAddress] (UserId, AddressId) VALUES (@user_id, @address_id)";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@address_id", addressId);
                int n = command.ExecuteNonQuery();
                return new DBResult { result = (object) true };   // if more than 0 rows are affected, the query successeded
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    return new DBResult { result = (object) false, reason = "This address is already assigned to the user" };
                }
                return new DBResult { result = (object)false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = (object)false, reason = "Unknown error\n" + e.Message };
            }
        }

        public DBResult DeleteUserAddress(Id userId, Id addressId)
        {
            try
            {
                string query = "DELETE FROM [UserAddress] WHERE UserId=@user_id AND AddressId=@address_id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@address_id", addressId);
                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
                }
                else
                {
                    return new DBResult { result = false, reason = "Address does not exists" };

                }
            }
            catch (SqlException)
            {
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n" + e.Message };
            }
        }

        public Department[] GetDepartmentList()
        {
            string query = @"SELECT A.*, B.Name AS UserName
                FROM [Department] AS A
                LEFT JOIN [User] AS B
                ON A.UserId = B.Id";    // SQL query string

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);

            Department[] list = new Department[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new Department(table.Rows[i]); }

            return list;
        }

        public Department[] GetDepartmentListByUserId(Id id)
        {
            string query = @"SELECT A.*, B.Name AS UserName
                FROM [Department] AS A
                LEFT JOIN [User] AS B
                ON A.UserId = B.Id
                WHERE A.UserId=@id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            Department[] list = new Department[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new Department(table.Rows[i]); }

            return list;
        }

        public DBResult AddDepartment(Department department) // insert address to Address table
        {
            try
            {
                string query = "INSERT INTO [Department] (Name, Description, UserId) VALUES (@name, @desc, @id)";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", department.name);
                command.Parameters.AddWithValue("@desc", department.description);
                command.Parameters.AddWithValue("@id", (object) department.userId ?? DBNull.Value);
                int n = command.ExecuteNonQuery();
                return new DBResult { result = (object)true };   // if more than 0 rows are affected, the query successeded
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    return new DBResult { result = (object)false, reason = "Department already exists" };
                }
                return new DBResult { result = (object)false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = (object)false, reason = "Unknown error\n" + e.Message };
            }
        }

        public DBResult DeleteDepartmentById(Id id)  // delete address with specific id
        {
            try
            {
                string query = "DELETE FROM [Department] WHERE Id=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    return new DBResult { result = true };   // if more than 0 rows are affected, the query successeded
                }
                else
                {
                    return new DBResult { result = false, reason = "Address does not exists" };

                }
            }
            catch (SqlException)
            {
                return new DBResult { result = false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = false, reason = "Unknown error\n" + e.Message };
            }
        }

        public DBResult UpdateDepartment(Department department)// update address with specific id
        {
            try
            {
                string query = "UPDATE [Department] SET Name=@name, Description=@desc, UserId=@userId WHERE Id=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", department.name);
                command.Parameters.AddWithValue("@desc", department.description);
                command.Parameters.AddWithValue("@userId", department.userId);
                command.Parameters.AddWithValue("@id", department.id);
                int n = command.ExecuteNonQuery();
                return new DBResult { result = (object)true };   // if more than 0 rows are affected, the query successeded
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    return new DBResult { result = (object)false, reason = "This address is already assigned to the user" };
                }
                return new DBResult { result = (object)false, reason = "Unknown SQL error" };
            }
            catch (Exception e)
            {
                return new DBResult { result = (object)false, reason = "Unknown error\n" + e.Message };
            }
        }
    }
}
