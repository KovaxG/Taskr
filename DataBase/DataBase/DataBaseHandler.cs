/*
 * Name: DataBaseHandler
 * By: Kovacs Gyorgy
 * Date: 2016.04.10 ->
 * 
 * Now with embedded user... (-_-)
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.AccessControl;
using System.Windows;
using System.Xml;

namespace DataBase
{
    public partial class DatabaseHandler
    {
        /*	@param userName - from login
		 *  @param password - from login
		 *  @return bool - the data of the user with succesful login or null
		 * 
		 */
		private UserData VerifyLogin(string userName, string password)
        {
			try {
            	OpenConnection();
            	string query = "SELECT * FROM users WHERE DisplayName LIKE '@user_name' AND PasswordHash LIKE '@password';";
				query.Replace ("@user_name", userName);
				query.Replace ("@password", password);

            	MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
            	DataSet ds = new DataSet();
            	dataAdapter.Fill(ds, "users");
            	CloseConnection();
					
            	if (ds.Tables["users"].Rows.Count == 0)
            	{
            	    return null;
            	}
					
            	UserData user = new UserData();
            	// foreach is not really necessary, because the querry can only return 1 row
            	// but I decided to keep it anyway, might make it a bit readable.
            	foreach (DataRow row in ds.Tables["users"].Rows)
            	{
            	    user.FillFromDataRow(row);
            	}
            	
				return user;
			}
			catch (Exception e) 
			{
				return null;
			}
        } // End of VerifyLogin()

		/* 
		 * Call VerifyUser on the DataBase User
		 */ 
		public bool Login (string userName, string password) {
			try {
				User = this.VerifyLogin (userName, password);
				if (User == null) return false;
				else return true;
			}
			catch (Exception e) 
			{
				Console.WriteLine (e.ToString ());
				return false;
			}
		}


        /*	@return List<ProjectData> - returns all the availiable projects
		 */
        public List<ProjectData> GetActiveProjectsList()
        {
            try
            {
                List<ProjectData> returnList = new List<ProjectData>();

                OpenConnection();
				string query = "SELECT * FROM projects WHERE TerminatedBy = '@emptyId';";
				query.Replace ("@emptyId", DBDefaults.DefaultId.ToString ());
                
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "projects");
                CloseConnection();

                if (ds.Tables["projects"].Rows.Count == 0)
                {
                    return null;
                }

                foreach (DataRow row in ds.Tables["projects"].Rows)
                {
                    ProjectData project = new ProjectData();
                    project.FillFromDataRow(row);
                    returnList.Add(project);
                }

                return returnList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        } // End of GetActiveProjectsList()

		/*	@return List<TaskData> - returns all the availiable projects
		 */
		public List<TaskData> GetTasksForProject(ProjectData project)
		{
			try
			{
				List<TaskData> returnList = new List<TaskData>();

				OpenConnection();
				string query = "SELECT * FROM tasks WHERE ParentProject = '@project_id';";
				query.Replace ("@project_id", project.ID.ToString ());

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
				DataSet ds = new DataSet();
				dataAdapter.Fill(ds, "tasks");
				CloseConnection();

				if (ds.Tables["tasks"].Rows.Count == 0)
				{
					return null;
				}

				foreach (DataRow row in ds.Tables["tasks"].Rows)
				{
					TaskData task = new TaskData();
					task.FillFromDataRow(row);
					returnList.Add(task);
				}

				return returnList;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return null;
			}
		} // End of GetTasksForProject()

        /*
         * @return List<ProjectData> - returns all the availiable projects
         */ 
        public List<ProjectSuggestionData> GetProjectSuggestionsList()
        {
            try
            {
                List<ProjectSuggestionData> returnList = new List<ProjectSuggestionData>();

                OpenConnection();
                string query = "SELECT * FROM projectsuggestions";//" WHERE TerminatedBy = " + DBDefaults.DefaultId + ";";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "projectsuggestions");
                CloseConnection();

                if (ds.Tables["projectsuggestions"].Rows.Count == 0)
                {
                    return null;
                }

                foreach (DataRow row in ds.Tables["projectsuggestions"].Rows)
                {
                    ProjectSuggestionData projectSuggestionData = new ProjectSuggestionData();
                    projectSuggestionData.FillFromDataRow(row);
                    returnList.Add(projectSuggestionData);
                }

                return returnList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
		}// End of GetProjectSuggestionsList()


        //TODO Maybie I should check if there already exists a project with the same name?
        /*
		 * @param newProject - inserts into the database all the properties from newProject
		 * @return bool - true if succes, false if failure
		 */
        public bool InsertNewProject(ProjectData newProject)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO projects (Title, ShortDescription, DetailedDescription, "
                    + "CreatedBy, ProjectLead, DateCreated, ModificationLogLink, Notes, AvailableFunds, "
                    + "CurrentYield, DateTerminated, TerminationReason, TerminatedBy, CollectedFunds, "
                    + "ConsumedFunds) VALUES " + newProject.ToQueryString() + ";";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        } // End of InsertNewProject()

        //TODO Maybie I should check if there already exists a project with the same name?
        /*
		 * @param newTask - inserts into the database all the properties from newTask
		 * @return bool - true if succes, false if failure
		 */
        public bool InsertNewTask(TaskData newTask)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO tasks (ParentId, Title, ShortDescription, "
                    + "DetailedDescription, ParentProject, DateCreated, CreatedBy, "
                    + "DateCompleted, CompletedBy, DeadLine, Status) "
                    + "VALUES " + newTask.ToQueryString() + ";";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        } // End of InsertNewTask()

        /*
		 * @param project - the project that is being requested
		 * @return bool - true if succes, false if failure
		 */
		public bool ProjectJoinRequest(ProjectData project)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO projectrequests (user_id, project_id) VALUES ('@user_id', '@project_id');";
				query.Replace ("@user_id", User.ID.ToString ());
				query.Replace ("@project_id", project.ID.ToString ());

                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //MessageBox.Show(e.Message);
                return false;
            }
        } // End of ProjectJoinRequests()

        /*
		 * @param project - the project that is being requested
		 * @return bool - true if succes, false if failure
		 */
        public bool TaskRequest(TaskData task)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO taskrequests (user_id, task_id) VALUES  ('@user_id', '@task_id');";
				query.Replace ("@user_id", User.ID.ToString ());
				query.Replace ("@project_id", task.ID.ToString ());

                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        } // End of TaskRequest()

        /* Can Update only:
		 * Title, ShortDescription, DetailedDescription, Notes, AvailableFunds
		 * @param project - update project from table
		 * @return bool - true if succes, false if failure
		 */
        public bool UpdateProject(ProjectData project)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE projects SET Title = @Title, ShortDescription = @ShortDescription, "
                    + "DetailedDescription = @DetailedDescription, Notes = @Notes, AvailableFunds = @AvailableFunds, "
                    + "CurrentYield = @CurrentYield, "
                    + " WHERE Id = @project_id;";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Title", project.Title);
                command.Parameters.AddWithValue("@ShortDescription", project.ShortDescription);
                command.Parameters.AddWithValue("@DetailedDescription", project.DetailedDescription);
                command.Parameters.AddWithValue("@Notes", project.Notes);
                command.Parameters.AddWithValue("@AvailableFunds", project.AvailibleFunds);
                command.Parameters.AddWithValue("@CurrentYield", project.CurrentYield);
                command.Parameters.AddWithValue("@user_id", project.ID);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        } // End of UpdateProject()
			
        /* Can Update only:
		 * DisplayName, AvatarLink, Email, PasswordHash, PhoneNumber, WorkStatus, PersonalNotes, ActiveProject, ActiveTask
		 * @param user - update user from table
		 * @return bool - true if succes, false if failure
		 */
        private bool UpdateUser(UserData user)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE users SET DisplayName = @DisplayName, AvatarLink = @AvatarLink, "
                    + "Email = @Email, PasswordHash = @PasswordHash, PhoneNumber = @PhoneNumber, "
                    + "ActiveProject = @ActiveProject, ActiveTask = @ActiveTask,"
                    + "WorkStatus = @WorkStatus, PersonalNotes = @PersonalNotes WHERE Id = @user_id;";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@DisplayName", user.DisplayName);
                command.Parameters.AddWithValue("@AvatarLink", user.AvatarURL);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PasswordHash", user.Password);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@ActiveProject", user.ActiveProject);
                command.Parameters.AddWithValue("@ActiveTask", user.ActiveTask);
                command.Parameters.AddWithValue("@WorkStatus", user.WorkStatus);
                command.Parameters.AddWithValue("@PersonalNotes", user.PersonalNotes);
                command.Parameters.AddWithValue("@user_id", user.ID);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
		} // End of UpdateUser ()

		/* Can Update only:
		 * DisplayName, AvatarLink, Email, PasswordHash, PhoneNumber, WorkStatus, PersonalNotes, ActiveProject, ActiveTask
		 * @return bool - true if succes, false if failure
		 */
		public bool UpdateThisUser()
		{
			try
			{
				this.UpdateUser (User);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		} // End of UpdateThisUser ()

        /*
		 * @param project - get all the users requesting for project
		 * @return List<UserData> - all the users
		 */
        public List<UserData> GetAllUsersRequestingForProject(ProjectData project)
        {
            try
            {
                OpenConnection();
                string query = "SELECT * FROM users, projectrequests WHERE users.Id = projectrequests.user_id AND projectrequests.project_Id = '@project_id';";
				query.Replace ("@project_id", project.ID.ToString ());

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "users");
                CloseConnection();

                if (ds.Tables["users"].Rows.Count == 0)
                {
                    return null;
                }

                List<UserData> userList = new List<UserData>();
                foreach (DataRow row in ds.Tables["users"].Rows)
                {
                    UserData user = new UserData();
                    user.FillFromDataRow(row);
                    userList.Add(user);
                }

                return userList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        } // End of GetAllUserRequestingForProject()

        /*
		 * @param user - the user that will be refreshed
		 * @return bool - succes
		 * Also! the user data is changed
		 */
        public bool RefreshUser(UserData user)
        {
            try
            {
                OpenConnection();
				string query = "SELECT * FROM users WHERE Id = '@user_id';";
				query.Replace ("@user_id", user.ID.ToString ());

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "users");
                CloseConnection();

                if (ds.Tables["users"].Rows.Count == 0)
                {
                    return false;
                }

                foreach (DataRow row in ds.Tables["users"].Rows)
                {
                    user.FillFromDataRow(row);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        } // End of RefreshUser()

		/*
		 * @return bool - succes
		 * Also! the user data is changed
		 */
		public bool RefreshThisUser()
		{
			try
			{
				this.RefreshUser (User);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return false;
			}
		} // End of RefresThishUser()

        /*
		 * @param project - the project that will be refreshed
		 * @return bool - succes
		 * Also! the project data is changed
		 */
        public bool RefreshProject(ProjectData project)
        {
            try
            {
                OpenConnection();
                string query = "SELECT * FROM projects WHERE Id = '@project_id';";
				query.Replace ("@project_id", project.ID.ToString ());

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "projects");
                CloseConnection();

                if (ds.Tables["projects"].Rows.Count == 0)
                {
                    return false;
                }

                foreach (DataRow row in ds.Tables["projects"].Rows)
                {
                    project.FillFromDataRow(row);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        } // End of RefreshProject()

        /*
		 * @param user - user that is to be modified
		 * You could aslo do this manually, but eh. Database can handle it
		 * Nice and short
		 */
        public bool DropTask()
        {
            try
            {
                User.ActiveTask = DBDefaults.DefaultId;
                return this.UpdateUser(User); // TODO check if this thing works
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        } // End of DropTask

        /*
		 * @param projectSuggestion - the one that will be adopted? adoptend? ...
		 * @return ProjecData - after creating the project and database and whatevs
		 */
		private ProjectData AdoptProjectSuggestion(ProjectSuggestionData projectSuggestion)
        {
            try
            {
                // Check if user has active task
                this.RefreshUser(User);
                if (User.ActiveProject != DBDefaults.DefaultId)
                {
                    return null;
                }

                // Fetch the data from the projectSuggestion and put it into the new project
                ProjectData newProject = new ProjectData(User.ID);
                newProject.Title = projectSuggestion.Title;
                newProject.ShortDescription = projectSuggestion.ShortDescription;
                newProject.DetailedDescription = projectSuggestion.DetailedDescription;
                newProject.CreatedBy = projectSuggestion.CreatedBy;
                newProject.ProjectLead = User.ID;
                newProject.DateCreated = DateTime.Now;
                newProject.Notes = projectSuggestion.Notes;
                this.InsertNewProject(newProject);

                // HACK I know, I know, It was the deadline's fault!
                List<ProjectData> listOfAllProjects = this.GetActiveProjectsList();
                foreach (ProjectData p in listOfAllProjects)
                {
                    if (p.ProjectLead == newProject.ProjectLead)
                    {
                        newProject = new ProjectData(p); // Rebuild with variables from p (for ID reasons)
                        break;
                    }
                }

                // Add active task to user
                User.ActiveProject = newProject.ID;
                this.UpdateUser(User);

                // Delete SuggestedProject
                this.RemoveProjectSuggestion(projectSuggestion);
                projectSuggestion = null;

                return newProject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        } // End of AdoptProjectSuggestions ()


        /*
		 * This function may be unnecessary. Who will even check this code?
		 * @param task - that task that will be deleted
		 */
        public bool RemoveTask(TaskData task)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM task WHERE  Id = " + task.ID + ";";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        } // End of RemoveTask

        /*
		 * @param pj - that projectSuggestion that will be deleted
		 */
        public bool RemoveProjectSuggestion(ProjectSuggestionData pj)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM projectSuggestions WHERE  Id = " + pj.ID + ";";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        } // End of RemoveTask

        /* 
		 * @param user - 
		 */
        public bool AcceptUserProjectRequest(UserData user, ProjectData project)
        {
            try
            {
                {
                    OpenConnection();
                    string query = "SELECT * FROM projectrequests WHERE user_id = "
                        + user.ID + " AND project_id = " + project.ID + ";";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds, "projectrequests");
                    CloseConnection();

                    if (ds.Tables["projectrequests"].Rows.Count == 0)
                    {
                        return false;
                    }
                };
                // Delete join request
                {
                    OpenConnection();
                    string query = "DELETE FROM projectrequests WHERE user_id = "
                        + user.ID + " AND project_id = " + project.ID + ";";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.ExecuteNonQuery();
                    command.Dispose();
                    CloseConnection();
                };
                // Change activeproject
                user.ActiveProject = project.ID;
                this.UpdateUser(user);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        } // End of AcceptUserProjectRequest ()

        /*
		 * @param task - the task that is to be assigned
		 * @param uesr - the user, the task that is to be assigned, is assigned to
		 * @return bool - succes
		 */
        public bool GrantTask(TaskData task, UserData user)
        {
            try
            {
                OpenConnection();
                string query = "SELECT * FROM users WHERE ActiveTask = " + task.ID + ";";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "users");
                CloseConnection();

                if (ds.Tables["users"].Rows.Count != 0)
                {
                    return false;
                }

                if (user.ActiveTask != DBDefaults.DefaultId) return false;
                else {
                    user.ActiveTask = task.ID;
                    this.UpdateUser(user);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        } // End of GrantTask ()

		// TODO getMode
		public string getMode(UserData user)
		{
			if (user.ActiveProject == 0)
				return "freelancer";
			else
			{
				return "teamleader";
			}
		}

    } // End of Partial Class

    public partial class DatabaseHandler
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


		// Let it be known that Gyuri objected to this on 2016.04.25!
        private UserData _user;
        public UserData User
        {
            get {return _user;}
            set {_user = value;}
        }

        // Create connectionstring and connection
        public DatabaseHandler()
        {
            server = "localhost";
            database = "test";
            uid = "root";
            password = "";

            string connectionString =
                "SERVER=" + server + ";"
                + "DATABASE= " + database + ";"
                + "UID=" + uid + ";"
                + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        } // End of Constructor

        // TODO should change console messages to MessageBox
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
        } // End of OpenConnection()

        // TODO should change console messages to MessageBox
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
        } // End of CloseConnection
    } // End of Partial Class
}