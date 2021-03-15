
using System;
using System.Data;
using System.Data.SqlClient;



namespace Manager
{
    public class DBConnection
    {
        /*
         * 
         * A classe DBConnection estabelece uma conexão com o banco de dados 
         * 
         * TODO:
         *   A classe DBConnection tem muitos metodos parecidos que podem ser unificados
         * 
         */

        private static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Users\\marco\\Desktop\\felipe\\Workspace\\Manager\\Manager\\Database1.mdf;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(ConnectionString);

        public bool connect()
            // connect to server if not connected
            // return true if connected successfuly or false if catch an error
        {
            if (connection.State != System.Data.ConnectionState.Open)   // if not connected...
            {
                try
                {
                    connection.Open();  // connect
                }
                catch
                {
                    return false;
                }
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

        public User GetUserById(int id)  // get user list from User table
        {
            string query = "SELECT * FROM [dbo].[User] WHERE UserId=@id";    // SQL query string

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            return new User(table.Rows[0]);
        }

        public bool AddUser(User user) // insert user to User table
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
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUserById(int id)  // delete user with specific id
        {
            try
            {
                string query = "DELETE FROM [User] WHERE UserId=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUser(User user)  // update information of user with specific id
        {
            try
            {
                string query = "UPDATE [User] SET Name=@name, Age=@age, Email=@email, Description=@description WHERE UserId=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@age", user.age);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@description", user.description);
                command.Parameters.AddWithValue("@id", user.id);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
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

        public bool AddAddress(Address address) // insert address to Address table
        {
            try
            {
                string query = "INSERT INTO [Address] (AddressInfo, IsCommercial) VALUES (@info, @com)";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@info", address.info);
                command.Parameters.AddWithValue("@com", address.isCommercial);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteAddressById(int id)  // delete address with specific id
        {
            try
            {
                string query = "DELETE FROM [Address] WHERE AddressId=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAddress(Address address)  // update address with specific id
        {
            try
            {
                string query = "UPDATE [Address] SET AddressInfo=@info, IsCommercial=@com WHERE AddressId=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@info", address.info);
                command.Parameters.AddWithValue("@com", address.isCommercial);
                command.Parameters.AddWithValue("@id", address.id);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }

        public Address[] GetAddressByUserId(int id)
        {
            string query = @"SELECT B.* FROM
                [UserAddress] AS A
                INNER JOIN[Address] AS B
                ON[A].[AddressId] = [B].[AddressId]
                WHERE A.UserId=@id
                ORDER BY B.AddressId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());


            Address[] list = new Address[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new Address(table.Rows[i]); }

            return list;
        }

        public bool AddUserAddress(int userId, int addressId)
        {
            try
            {
                string query = "INSERT INTO [UserAddress] (UserId, AddressId) VALUES (@user_id, @address_id)";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@address_id", addressId);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUserAddress(int userId, int addressId)
        {
            try
            {
                string query = "DELETE FROM [UserAddress] WHERE UserId=@user_id AND AddressId=@address_id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@address_id", addressId);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }

        public Department[] GetDepartmentList()
        {
            string query = @"SELECT A.*, B.Name AS UserName
                FROM [Department] AS A
                LEFT JOIN [User] AS B
                ON A.UserId = B.UserId";    // SQL query string

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);

            Department[] list = new Department[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new Department(table.Rows[i]); }

            return list;
        }

        public Department[] GetDepartmentListByUserId(int id)
        {
            string query = @"SELECT A.*, B.Name AS UserName
                FROM [Department] AS A
                LEFT JOIN [User] AS B
                ON A.UserId = B.UserId
                WHERE A.UserId=@id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            Department[] list = new Department[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++) { list[i] = new Department(table.Rows[i]); }

            return list;
        }

        public bool AddDepartment(Department department) // insert address to Address table
        {
            //try
            //{
                string query = "INSERT INTO [Department] (Name, Description, UserId) VALUES (@name, @desc, @id)";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", department.name);
                command.Parameters.AddWithValue("@desc", department.description);
                command.Parameters.AddWithValue("@id", (object) department.userId ?? DBNull.Value);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            //} catch {
            //    return false;
            //}
        }

        public bool DeleteDepartmentById(int id)  // delete address with specific id
        {
            try
            {
                string query = "DELETE FROM [Department] WHERE DepartmentId=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDepartment(Department department)// update address with specific id
        {
            try
            {
                string query = "UPDATE [Department] SET Name=@name, Description=@desc, UserId=@userId WHERE DepartmentId=@id";    // SQL query string

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", department.name);
                command.Parameters.AddWithValue("@desc", department.description);
                command.Parameters.AddWithValue("@userId", department.userId);
                command.Parameters.AddWithValue("@id", department.id);
                int n = command.ExecuteNonQuery();
                return n > 0;   // if more than 0 rows are affected, the query successeded
            }
            catch
            {
                return false;
            }
        }
    }
}
