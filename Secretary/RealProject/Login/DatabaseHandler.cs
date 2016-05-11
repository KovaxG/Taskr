using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Login
{
    class DatabaseHandler
    {

        /* ----------------------------------------> DATABASE SETTINGS <---------------------------------------- */
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Default values
        const string DEFAULT_TEXT = "-";
	    const int DEFAULT_ID   = 0;
        DateTime DEFAULT_DATE = new DateTime(1970,1,1,0,0,0);
        
       
        // Constructor
        public DatabaseHandler()
        {
            Initialize();
        }
        
        // Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "test";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        // Open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
       
        // Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /* ----------------------------------------> END DATABASE SETTINGS <---------------------------------------- */


        /* ----------------------------------------> SECRETARY ACTIONS <---------------------------------------- */

        // Create new secretary
        public void createSecretary(string firstname, string lastname, string email, string displayname, string phonenumber, string password,  DateTime date)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO secretary (FirstName, LastName, Email, DisplayName, PhoneNumber, PasswordHash, AvatarLink, JoinDate, Status, PersonalNotes, LeaveDate, ReasonForLeaving, RejoinDesirability, Observations) VALUES (@FirstName, @LastName, @Email, @DisplayName, @PhoneNumber, @PasswordHash, @AvatarLink, @JoinDate, @Status, @PersonalNotes, @LeaveDate, @ReasonForLeaving, @RejoinDesirability, @Observations);", connection);
            command.Parameters.Add("@FirstName", MySqlDbType.Text).Value = firstname;
            command.Parameters.Add("@LastName", MySqlDbType.Text).Value = lastname;
            command.Parameters.Add("@Email", MySqlDbType.Text).Value = email;
            command.Parameters.Add("@DisplayName", MySqlDbType.Text).Value = displayname;
            command.Parameters.Add("@PhoneNumber", MySqlDbType.Text).Value = phonenumber;
            command.Parameters.Add("@PasswordHash", MySqlDbType.Text).Value = password;
            command.Parameters.Add("@AvatarLink", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("@JoinDate", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@Status", MySqlDbType.Text).Value = "Available";
            command.Parameters.Add("@PersonalNotes", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("@LeaveDate", MySqlDbType.Date).Value = DEFAULT_DATE;
            command.Parameters.Add("ReasonForLeaving", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("RejoinDesirability", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("Observations", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.ExecuteNonQuery();
            CloseConnection();
        }

       // Check login of the secretary
        public bool CheckLogin(string username, string password)
        {
            OpenConnection();
            int id;
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT Id FROM secretary WHERE (Email=@username or DisplayName = @username) and LeaveDate=@DefaultDate";
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@DefaultDate", DEFAULT_DATE);
            command.Connection = connection;
            MySqlDataReader login = command.ExecuteReader();
            if (login.Read())
            {
                string line = login.GetString("Id");
                id = Int32.Parse(line);
                CloseConnection();
                string hashed_password = Hash.hash(password, id, 16);
                if (hashed_password.Equals(getPasswordSecretary(id)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                CloseConnection();
                return false;
            }
           
        }

        /* <====================================== GET FIELDS ======================================> */

        // Get the displayname of the secretary
        public String getDisplayNameSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT DisplayName FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("DisplayName");
            }
            CloseConnection();
            return line;
        }

        // Get the phonenumber of the secretary
        public string getPhoneNumberSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT PhoneNumber FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("PhoneNumber");
            }
            CloseConnection();
            return line;
        }

        // Get the password of the secretary
        public string getPasswordSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT PasswordHash FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("PasswordHash");
            }
            CloseConnection();
            return line;
        }

        // Get the email of the secrary
        public string getEmailSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT Email FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("Email");
            }
            CloseConnection();
            return line;
        }

        // Get the status of the secretary
        public string getStatusSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT Status FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                line = reader.GetString("Status");
            }
            CloseConnection();
            return line;
        }

        // Get the firstname of the secretary
        public string getFirstNameSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT FirstName FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                line = reader.GetString("FirstName");
            }
            CloseConnection();
            return line;
        }

        // Get the lastname of the secretary
        public string getLastNameSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT LastName FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                line = reader.GetString("LastName");
            }
            CloseConnection();
            return line;
        }

        // Get the avatarlink of the secretary
        public string getAvatarLinkSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT AvatarLink FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                line = reader.GetString("AvatarLink");
            }
            CloseConnection();
            return line;
        }

        // Get the personal notes of the secretary
        public string getPersonalNotesSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT PersonalNotes FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                line = reader.GetString("PersonalNotes");
            }
            CloseConnection();
            return line;
        }

        // Get the id of the secretary
        public int getIdSecretary(string username)
        {
            OpenConnection();
            int id = 0;
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT Id FROM secretary WHERE Email='" + username + "';", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string line = reader.GetString("Id");
                id = Int32.Parse(line);
            }
            CloseConnection();
            return id;
        }

        // Get the joindate of the secretary 
        public DateTime getJoinDateSecretary(int user)
        {
            OpenConnection();
            string line = "";
            DateTime date = new DateTime();
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT JoinDate FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("JoinDate");
                date = Convert.ToDateTime(line);

            }
            CloseConnection();
            return date;
        }

        // Get the reason for leaving of the secretary
        public string getReasonForLeavingSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT ReasonForLeaving FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("ReasonForLeaving");
            }
            CloseConnection();
            return line;
        }

        // Get the rejoin desirability of the secretary
        public string getRejoinDesirabilitySecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT RejoinDesirability FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("RejoinDesirability");
            }
            CloseConnection();
            return line;
        }

        // Get the observations of the user
        public string getObservationsSecretary(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT Observations FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("Observations");
            }
            CloseConnection();
            return line;
        }

        public DateTime getLeaveDateSecretary(int user)
        {
            OpenConnection();
            string line = "";
            DateTime date = new DateTime();
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT LeaveDate FROM secretary WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("LeaveDate");
                date = Convert.ToDateTime(line);

            }
            CloseConnection();
            return date;
        }

        /* <====================================== UPDATE FIELDS ======================================> */

        // Update the phonenumber of the secretary
        public void updatePhoneNumberSecretary(int user, string phonenumber)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET PhoneNumber='" + phonenumber + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the displayname of the secretary
        public void updateDisplayNameSecretary(int user, string displayname)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET DisplayName='" + displayname + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the email of the secretary
        public void updateEmailSecretary(int user, string email)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET Email='" + email + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the firstname of the secretary
        public void updateFirstNameSecretary(int user, string firstname)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET FirstName='" + firstname + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the last name of the secretary
        public void updateLastNameSecretary(int user, string lastname)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET LastName='" + lastname + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the password of the secretary
        public void updatePasswordSecretary(int user, string password)
        {
            OpenConnection();
            string hashed_password = Hash.hash(password, user, 16);
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET PasswordHash='" + hashed_password + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the status of the secretary
        public void updateStatusSecretary(int user, string status)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET Status='" + status + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the joindate of the secretary
        public void updateJoinDateSecretary(int user, DateTime joindate)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET JoinDate=@JoinDate" + " WHERE Id=" + user + ";", connection);
            command.Parameters.Add("@JoinDate", MySqlDbType.Date).Value = joindate;
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the personal notes of the secretary
        public void updatePersonalNotesSecretary(int user, string personalnotes)
        {
            if(personalnotes.Equals(""))
            {
                personalnotes = DEFAULT_TEXT;
            }
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET PersonalNotes='" + personalnotes + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the avatrlink of the secretary
        public void updateAvatarLinkSecretary (int user, string avatarlink)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET AvatarLink='" + avatarlink + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the reason for leaing of the secretary
        public void updateReasonForLeavingSecretary(int user, string reasonforleaving)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET ReasonForLeaving='" + reasonforleaving + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the rejoin desirability of the secretary
        public void updateRejoinDesirabilitySecretary(int user, string rejoindesirability)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET RejoinDesirability='" + rejoindesirability + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the observations of the secretary
        public void updateObservationsSecretary(int user, string observations)
        {
            if(observations.Equals(""))
            {
                observations = DEFAULT_TEXT;
            }
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET Observations='" + observations + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the leavedate of the secretary
        public void updateLeaveDateSecretary(int user, DateTime leavedate)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE secretary SET LeaveDate=@LeaveDate" + " WHERE Id=" + user + ";", connection);
            command.Parameters.Add("@LeaveDate", MySqlDbType.Date).Value = leavedate;
            command.ExecuteNonQuery();
            CloseConnection();
        }
        /* ----------------------------------------> END OF SECRETARY ACTIONS <---------------------------------------- */


        /* ----------------------------------------> USER ACTIONS <---------------------------------------- */

        // Create new user
        public void createFreelancer(string firstname,string lastname, string email, string displayname, string phonenumber, string password,  DateTime date, int user)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO users (FirstName, LastName, Email, DisplayName, PhoneNumber, PasswordHash, AvatarLink, JoinDate, AddedBy,WorkStatus,ActiveProject,ActiveTask, PersonalNotes, LeaveDate, ReasonForLeaving, RejoinDesirability, Observations) VALUES (@FirstName, @LastName, @Email, @DisplayName, @PhoneNumber, @PasswordHash, @AvatarLink, @JoinDate, @AddedBy, @Status, @ActiveProject, @ActiveTask, @PersonalNotes, @LeaveDate, @ReasonForLeaving, @RejoinDesirability, @Observations);", connection);
            command.Parameters.Add("@FirstName", MySqlDbType.Text).Value = firstname;
            command.Parameters.Add("@LastName", MySqlDbType.Text).Value = lastname;
            command.Parameters.Add("@Email", MySqlDbType.Text).Value = email;
            command.Parameters.Add("@DisplayName", MySqlDbType.Text).Value = displayname;
            command.Parameters.Add("@PhoneNumber", MySqlDbType.Text).Value = phonenumber;
            command.Parameters.Add("@PasswordHash", MySqlDbType.Text).Value = password;
            command.Parameters.Add("@AvatarLink", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("@JoinDate", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@AddedBy", MySqlDbType.Text).Value = user;
            command.Parameters.Add("@Status", MySqlDbType.Text).Value = "Available";
            command.Parameters.Add("@PersonalNotes", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("@LeaveDate", MySqlDbType.Date).Value = DEFAULT_DATE;
            command.Parameters.Add("ReasonForLeaving", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("RejoinDesirability", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.Add("Observations", MySqlDbType.Text).Value = DEFAULT_TEXT;
            command.Parameters.AddWithValue("ActiveProject", DEFAULT_ID);
            command.Parameters.AddWithValue("ActiveTask", DEFAULT_ID);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        /* <====================================== GET FIELDS ======================================> */

        // Get id user
        public int getIdUser(string username)
        {
            OpenConnection();
            int id = 0;
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT Id FROM users WHERE Email='" + username + "';", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string line = reader.GetString("Id");
                id = Int32.Parse(line);
            }
            CloseConnection();
            return id;
        }

        // Get the firstname of the user
        public string getFirstNameUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT FirstName FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("FirstName");
            }
            CloseConnection();
            return line;
        }

        // Get the lastname of the user
        public string getLastNameUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT LastName FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("LastName");
            }
            CloseConnection();
            return line;
        }

        // Get the displayname of the user
        public string getDisplayNameUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT DisplayName FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("DisplayName");
            }
            CloseConnection();
            return line;
        }

        // Get the avatarlink of the user
        public string getAvatarLinkUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT AvatarLink FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("AvatarLink");
            }
            CloseConnection();
            return line;
        }

        // Get the email of the user
        public string getEmailUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT Email FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("Email");
            }
            CloseConnection();
            return line;
        }

        // Get the password of the user
        public string getPasswordHashUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT PasswordHash FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("PasswordHash");
            }
            CloseConnection();
            return line;
        }

        // Get the phonenumber of the user
        public string getPhoneNumberUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT PhoneNumber FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("PhoneNumber");
            }
            CloseConnection();
            return line;
        }

        // Get the joindate of the user
        public DateTime getJoinDateUser(int user)
        {
            OpenConnection();
            string line = "";
            DateTime date = new DateTime();
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT JoinDate FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("JoinDate");
                date = Convert.ToDateTime(line);

            }
            CloseConnection();
            return date;
        }

        // Get the leave date of the user
        public DateTime getLeaveDateUser(int user)
        {
            OpenConnection();
            string line = "";
            DateTime date = new DateTime();
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT LeaveDate FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("LeaveDate");
                date = Convert.ToDateTime(line);

            }
            CloseConnection();
            return date;
        }

        // Get the secretary whoch added the user
        public string getAddedByUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT AddedBy FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("AddedBy");
            }
            CloseConnection();
            return line;
        }

        // Get the active project of the user
        public string getActiveProjectUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT ActiveProject FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("ActiveProject");
            }
            CloseConnection();
            return line;
        }

        // Get the status of the user
        public string getStatusUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT WorkStatus FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("WorkStatus");
            }
            CloseConnection();
            return line;
        }

        // Get the personal notes of the user
        public string getPersonalNotesUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT PersonalNotes FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                line = reader["PersonalNotes"].ToString();
            }
            CloseConnection();
            return line;
        }

        // Get the reason for leaving of the user
        public string getReasonForLeavingUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT ReasonForLeaving FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("ReasonForLeaving");
            }
            CloseConnection();
            return line;
        }

        // Get the rejoin desirability of the user
        public string getRejoinDesirabilityUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT RejoinDesirability FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("RejoinDesirability");
            }
            CloseConnection();
            return line;
        }

        // Get the observations of the user
        public string getObservationsUser(int user)
        {
            OpenConnection();
            string line = "";
            MySqlDataReader reader;
            MySqlCommand command = new MySqlCommand("SELECT Observations FROM users WHERE Id=" + user + ";", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                line = reader.GetString("Observations");
            }
            CloseConnection();
            return line;
        }

        /* <====================================== UPDATE FIELDS ======================================> */

        // Update the displayname of the user
        public void updateDisplayNameUser(int user, string displayname)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET DisplayName='" + displayname + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the firstname of the user
        public void updateFirstNameUser(int user, string firstname)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET FirstName='" + firstname + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the lastname of the user
        public void updateLastNameUser(int user, string lastname)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET LastName='" + lastname + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the avatarlink of the user
        public void updateAvatarLinkUser(int user, string avatarlink)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET AvatarLink='" + avatarlink + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the email of the user
        public void updateEmailUser(int user, string email)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET Email='" + email + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the password of the user
        public void updatePasswordUser(int user, string password)
        {
            OpenConnection();
            string hashed_password = Hash.hash(password, user, 16);
            MySqlCommand command = new MySqlCommand("UPDATE users SET PasswordHash='" + hashed_password + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the phonenumber of the user
        public void updatePhoneNumberUser(int user, string phonenumber)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET PhoneNumber='" + phonenumber + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the joindate of the user
        public void updateJoinDateUser(int user, DateTime joindate)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET JoinDate=@JoinDate" + " WHERE Id=" + user + ";", connection);
            command.Parameters.Add("@JoinDate", MySqlDbType.Date).Value = joindate;
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the leavedate of the user
        public void updateLeaveDateUser(int user, DateTime leavedate)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET LeaveDate=@LeaveDate" + " WHERE Id=" + user + ";", connection);
            command.Parameters.Add("@LeaveDate", MySqlDbType.Date).Value = leavedate;
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the addedby field of the user
        public void updateAddedByUser(int user, int addedby)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET AddedBy=" + addedby + " WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the active project of the user
        public void updateActiveProjectUser(int user, int activeproject)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET ActiveProject=" + activeproject + " WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the status of the user
        public void updateStatusUser(int user, string workstatus)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET WorkStatus='" + workstatus + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the personal notes of the user
        public void updatePersonalNotesUser(int user, string personalnotes)
        {
            if(personalnotes.Equals(""))
            {
                personalnotes = DEFAULT_TEXT;
            }
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET PersonalNotes='" + personalnotes + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the reason for leaving of the user
        public void updateReasonForLeavingUser(int user, string reasonforleaving)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET ReasonForLeaving='" + reasonforleaving + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the rejoin desirability of the user
        public void updateRejoinDesirabilityUser(int user, string rejoindesirability)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET RejoinDesirability='" + rejoindesirability + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Update the observations of the user
        public void updateObservationsUser(int user, string observations)
        {
            if(observations.Equals(""))
            {
                observations = DEFAULT_TEXT;
            }
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET Observations='" + observations + "'WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        /* <====================================== END UPDATE FIELDS ======================================> */

        /* <====================================== MAKE AN EMPLOYEE A FORMER EMPLOYEE STATEMENTS ======================================> */
        
        // Delete task requests for a employee which will be made former employee
        public void deleteTaskRequestUser(int user)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("DELETE FROM taskrequests WHERE user_id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Delete task requests for a employee which will be made former employee
        public void deleteProjectRequestUser(int user)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("DELETE FROM projectrequests WHERE user_id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Set ActiveProject = 0
        public void deleteFromActiveProject(int user)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET ActiveProject="+DEFAULT_ID+" WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Set ActiveTask = 0
        public void deleteFromActiveTask(int user)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE users SET ActiveTask=" + DEFAULT_ID + " WHERE Id=" + user + ";", connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        // Check if the user is a ProjectLeader
        public bool checkIfProjectLeader (int user)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM  projects WHERE ProjectLead=" + user + ";", connection);
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                CloseConnection();
                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }
        /* ----------------------------------------> END OF USER ACTIONS <---------------------------------------- */

        /* ----------------------------------------> LOAD TABLES <---------------------------------------- */
        // Load employees from users table
        public DataSet loadEmployees()
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT Id,FirstName,LastName FROM users WHERE LeaveDate=@DefaultDate;", connection);
            command.Parameters.Add("@DefaultDate", MySqlDbType.Date).Value = DEFAULT_DATE;
            command.ExecuteNonQuery();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "users");
            CloseConnection();
            return ds;

        }

        // Load former employees from users table
        public DataSet loadFormerEmployees()
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT Id,FirstName,LastName FROM users WHERE LeaveDate <>@DefaultDate;", connection);
            command.Parameters.Add("@DefaultDate", MySqlDbType.Date).Value = DEFAULT_DATE;
            command.ExecuteNonQuery();
            
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "users");
            CloseConnection();
            return ds;
        }

        // Load secretaries from secretary table
        public DataSet loadSecretary()
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT Id,FirstName,LastName FROM secretary WHERE LeaveDate=@DefaultDate;", connection);
            command.Parameters.Add("@DefaultDate", MySqlDbType.Date).Value = DEFAULT_DATE;
            command.ExecuteNonQuery();
            
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "secretary");
            CloseConnection();
            return ds;
        }

        // Load former secretaries from secretary table
        public DataSet loadFormerSecretary()
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT Id,FirstName,LastName FROM secretary  WHERE LeaveDate <>@DefaultDate;", connection);
            command.Parameters.Add("@DefaultDate", MySqlDbType.Date).Value = DEFAULT_DATE;
            command.ExecuteNonQuery();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "secretary");
            CloseConnection();
            return ds;
        }

        /* ----------------------------------------> END OF LOAD TABLES <---------------------------------------- */

        public bool checkUniqueEmailSecretary (string email, int id)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM secretary WHERE Email=@email AND Id<>@id";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            MySqlDataReader check = command.ExecuteReader();
            if (check.Read())
            {
                CloseConnection();
                return false;
            }
            else
            {
                CloseConnection();
                return true;
            }
        }

        public bool checkUniqueDisplayNameSecretary(string displayname, int id)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM secretary WHERE DisplayName=@displayname AND Id<>@id";
            command.Parameters.AddWithValue("@displayname", displayname);
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            MySqlDataReader check = command.ExecuteReader();
            if (check.Read())
            {
                CloseConnection();
                return false;
            }
            else
            {
                CloseConnection();
                return true;
            }
        }

        public bool checkUniqueEmailUser(string email, int id)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM users WHERE Email=@email AND Id<>@id";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            MySqlDataReader check = command.ExecuteReader();
            if (check.Read())
            {
                CloseConnection();
                return false;
            }
            else
            {
                CloseConnection();
                return true;
            }
        }

        public bool checkUniqueDisplayNameUser(string displayname, int id)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM users WHERE DisplayName=@displayname AND Id<>@id";
            command.Parameters.AddWithValue("@displayname", displayname);
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            MySqlDataReader check = command.ExecuteReader();
            if (check.Read())
            {
                CloseConnection();
                return false;
            }
            else
            {
                CloseConnection();
                return true;
            }
        }

    }
}
