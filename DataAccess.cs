using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TicketingSystem
{
    public static class DataAccess
    {
        // Read connection string from App.config (named "TicketingDB")
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["TicketingDB"].ConnectionString;

        // Helper: Build a connection string to the "master" database for DB creation.
        private static string GetMasterConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = "master";
            return builder.ConnectionString;
        }

        /// <summary>
        /// Ensures the TICKETTEST database and all required tables exist.
        /// Also adds the ResolutionTimestamp column if missing and inserts a default admin user.
        /// </summary>
        public static void EnsureDatabaseSetup()
        {
            // 1. Create the database if it doesn't exist.
            using (SqlConnection conn = new SqlConnection(GetMasterConnectionString()))
            {
                conn.Open();
                string checkDbQuery = @"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'TICKETTEST')
                    BEGIN
                        CREATE DATABASE TICKETTEST;
                    END;";
                using (SqlCommand cmd = new SqlCommand(checkDbQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // 2. In the TICKETTEST database, create required tables.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Roles table
                string createRolesTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Roles')
                    BEGIN
                        CREATE TABLE Roles (
                            RoleID INT IDENTITY(1,1) PRIMARY KEY,
                            RoleName VARCHAR(50) NOT NULL
                        );
                        INSERT INTO Roles (RoleName) VALUES ('Admin'), ('SupportAgent'), ('Client');
                    END;";
                using (SqlCommand cmd = new SqlCommand(createRolesTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Users table
                string createUsersTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
                    BEGIN
                        CREATE TABLE Users (
                            UserID INT IDENTITY(1,1) PRIMARY KEY,
                            Username VARCHAR(50) NOT NULL UNIQUE,
                            PasswordHash VARCHAR(255) NOT NULL,
                            RoleID INT NOT NULL,
                            ClientID INT NULL,
                            FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
                        );
                    END;";
                using (SqlCommand cmd = new SqlCommand(createUsersTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Clients table
                string createClientsTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clients')
                    BEGIN
                        CREATE TABLE Clients (
                            ClientID INT IDENTITY(1,1) PRIMARY KEY,
                            Name VARCHAR(100) NOT NULL,
                            Email VARCHAR(100) NOT NULL,
                            Phone VARCHAR(20) NULL,
                            Address VARCHAR(255) NULL,
                            Notes TEXT NULL
                        );
                    END;";
                using (SqlCommand cmd = new SqlCommand(createClientsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Tickets table with extra fields.
                string createTicketsTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tickets')
                    BEGIN
                        CREATE TABLE Tickets (
                            TicketID INT IDENTITY(1,1) PRIMARY KEY,
                            ClientID INT NOT NULL,
                            Title VARCHAR(200) NOT NULL,
                            Description TEXT NOT NULL,
                            TicketComment TEXT NULL,
                            CommentTimestamp DATETIME NULL,
                            Status VARCHAR(50) NOT NULL,
                            Priority VARCHAR(20) NOT NULL,
                            CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
                            ResolvedDate DATETIME NULL,
                            AssignedTo INT NULL,
                            ResolutionNote TEXT NULL,
                            ResolutionTimestamp DATETIME NULL,
                            FOREIGN KEY (ClientID) REFERENCES Clients(ClientID)
                        );
                    END;";
                using (SqlCommand cmd = new SqlCommand(createTicketsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Conditionally add the ResolutionTimestamp column if missing.
                string addResolutionTimestampColumn = @"
                    IF NOT EXISTS (
                        SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_NAME = 'Tickets'
                          AND COLUMN_NAME = 'ResolutionTimestamp'
                    )
                    BEGIN
                        ALTER TABLE Tickets
                        ADD ResolutionTimestamp DATETIME NULL;
                    END;";
                using (SqlCommand cmd = new SqlCommand(addResolutionTimestampColumn, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Insert default admin user if not present.
                string createDefaultAdmin = @"
                    IF NOT EXISTS (SELECT * FROM Users WHERE Username='admin')
                    BEGIN
                        INSERT INTO Users (Username, PasswordHash, RoleID, ClientID)
                        SELECT 'admin', 'admin123', RoleID, NULL
                        FROM Roles
                        WHERE RoleName = 'Admin';
                    END;";
                using (SqlCommand cmd = new SqlCommand(createDefaultAdmin, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Inserts a new client into the Clients table.
        /// </summary>
        public static bool InsertClient(Client client)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Clients (Name, Email, Phone, Address, Notes) VALUES (@Name, @Email, @Phone, @Address, @Notes)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.Parameters.AddWithValue("@Address", client.Address);
                    cmd.Parameters.AddWithValue("@Notes", client.Notes);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Updates an existing client record.
        /// </summary>
        public static bool UpdateClient(Client client)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    UPDATE Clients
                    SET Name = @Name,
                        Email = @Email,
                        Phone = @Phone,
                        Address = @Address,
                        Notes = @Notes
                    WHERE ClientID = @ClientID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.Parameters.AddWithValue("@Address", client.Address);
                    cmd.Parameters.AddWithValue("@Notes", client.Notes);
                    cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Inserts a new user into the Users table.
        /// </summary>
        public static bool InsertUser(string username, string password, string role, int? clientID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    INSERT INTO Users (Username, PasswordHash, RoleID, ClientID)
                    VALUES (@username, @password,
                            (SELECT RoleID FROM Roles WHERE RoleName = @role), @clientID)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    if (clientID.HasValue)
                        cmd.Parameters.AddWithValue("@clientID", clientID.Value);
                    else
                        cmd.Parameters.AddWithValue("@clientID", DBNull.Value);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Updates an existing user record.
        /// </summary>
        public static bool UpdateUser(User user, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    UPDATE Users
                    SET Username = @username,
                        PasswordHash = @password,
                        ClientID = @clientID
                    WHERE UserID = @userId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    if (user.ClientID.HasValue)
                        cmd.Parameters.AddWithValue("@clientID", user.ClientID.Value);
                    else
                        cmd.Parameters.AddWithValue("@clientID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@userId", user.UserID);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Inserts a new ticket into the Tickets table.
        /// </summary>
        public static bool InsertTicket(int clientID, string title, string description, string status, string priority)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    INSERT INTO Tickets (ClientID, Title, Description, Status, Priority)
                    VALUES (@clientID, @title, @description, @status, @priority)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@clientID", clientID);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@priority", priority);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Updates an existing ticket record.
        /// </summary>
        public static bool UpdateTicket(int ticketId, int clientID, string title, string description, string status, string priority)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    UPDATE Tickets
                    SET ClientID = @clientID,
                        Title = @title,
                        Description = @description,
                        Status = @status,
                        Priority = @priority
                    WHERE TicketID = @ticketId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@clientID", clientID);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@priority", priority);
                    cmd.Parameters.AddWithValue("@ticketId", ticketId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Closes a ticket by setting its status to 'Resolved' and updating resolution details.
        /// </summary>
        public static bool UpdateTicketClose(int ticketId, string resolutionComment)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    UPDATE Tickets
                    SET Status = 'Resolved',
                        ResolvedDate = GETDATE(),
                        ResolutionNote = @resolutionComment,
                        ResolutionTimestamp = GETDATE()
                    WHERE TicketID = @ticketId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@resolutionComment", resolutionComment);
                    cmd.Parameters.AddWithValue("@ticketId", ticketId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Reopens a ticket by resetting resolution-related fields.
        /// </summary>
        public static bool UpdateTicketReopen(int ticketId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    UPDATE Tickets
                    SET Status = 'Open',
                        ResolvedDate = NULL,
                        ResolutionNote = NULL,
                        ResolutionTimestamp = NULL
                    WHERE TicketID = @ticketId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ticketId", ticketId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Retrieves ticket details by TicketID.
        /// </summary>
        public static DataRow GetTicketById(int ticketId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Tickets WHERE TicketID = @ticketId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ticketId", ticketId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        /// <summary>
        /// Validates a user's credentials.
        /// </summary>
        public static User ValidateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT U.UserID, U.Username, R.RoleName, U.ClientID
                    FROM Users U
                    INNER JOIN Roles R ON U.RoleID = R.RoleID
                    WHERE U.Username = @username
                      AND U.PasswordHash = @password;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            Role = reader["RoleName"].ToString(),
                            ClientID = reader["ClientID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ClientID"]) : null
                        };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves tickets. If the user is a Client, only that client's tickets are returned; otherwise, returns all tickets.
        /// </summary>
        public static DataTable GetTickets(User user)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = user.Role == "Client"
                    ? "SELECT TicketID, Title, Status, Priority, CreatedDate, ResolvedDate FROM Tickets WHERE ClientID = @clientID"
                    : "SELECT TicketID, Title, Status, Priority, CreatedDate, ResolvedDate FROM Tickets";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (user.Role == "Client")
                        cmd.Parameters.AddWithValue("@clientID", user.ClientID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Retrieves all clients.
        /// </summary>
        public static DataTable GetClients()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT ClientID, Name, Email, Phone, Address, Notes FROM Clients";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Retrieves all users along with their role and associated client.
        /// </summary>
        public static DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT U.UserID, U.Username, R.RoleName, U.ClientID, C.Name AS ClientName
                    FROM Users U
                    INNER JOIN Roles R ON U.RoleID = R.RoleID
                    LEFT JOIN Clients C ON U.ClientID = C.ClientID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
