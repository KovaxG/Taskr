/*
 * Name: DataBaseHandler
 * By: Kovacs Gyorgy
 * Date: 2016.04.10 ->
 * 
 * Now with embedded user... (-_-)
 * 
 * When I made the tests, I included a TESTED yyyy.mm.dd in the description
 * If there is no such text in the description, the function might not work!
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Security.AccessControl;
using System.Windows;
using System.Xml;
using DataBase;

namespace DataBase
{
    public partial class DatabaseHandler
    {
		/// <summary>
		/// TESTED 2016.05.06 
		/// This is used to log on with user credentials. (UserName, Password)
		/// - Uses hash on password!
		/// </summary>
		/// <param name="userName">login username</param>
		/// <param name="password">login password</param>
		/// <returns>the data of the user if succes, the defaultUser if failed</returns>
		public UserData VerifyLogin(string userName, string password)
        {
			// Null Check
			// TODO throw One of the parameters are null
			if (userName == null) return new UserData();
			if (password == null) return new UserData();

			try {
				
				int userID = 0; // This will store the ID of the user

				{ // Check if user exists in database, if so get the ID for the hash
					OpenConnection();
					// TODO Should change in the future to:
					// string query = "SELECT Id FROM users WHERE DisplayName = '@user_name';";
					string query = "SELECT * FROM users WHERE DisplayName = '@user_name';";
					query = query.Replace ("@user_name", userName);

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "users");
					CloseConnection();

					// If there are no mathes, the login has failed
					// TODO throw No such userName
					if (ds.Tables["users"].Rows.Count == 0) return new UserData();

					// If there is a user get the user.ID
					UserData user = new UserData();
					foreach (DataRow row in ds.Tables["users"].Rows)
					{
						user.FillFromDataRow(row);
					}
					userID = user.ID;

				} // End of check
				{ // Select all the data from the user
            		OpenConnection();
            		string query = "SELECT * FROM users WHERE DisplayName = '@user_name' AND PasswordHash = '@password';";
					query = query.Replace ("@user_name", userName);
					query = query.Replace ("@password", Hash(password, userID));
						
            		MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
            		DataSet ds = new DataSet();
            		dataAdapter.Fill(ds, "users");
            		CloseConnection();
					if (ds.Tables["users"].Rows.Count == 0) return new UserData();

						
					UserData user = new UserData();
            		// foreach is not really necessary, because the querry can only return 1 row
            		// but I decided to keep it anyway, might make it a bit readable.
            		foreach (DataRow row in ds.Tables["users"].Rows)
            		{
            		    user.FillFromDataRow(row);
            		}
            		
					return user;
				} // End of the selection of the userData
			}
			catch (Exception e) 
			{
				string errorMessage = "Exception in DataBaseHandler -> VerifyLogin \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return new UserData();
			}
        } // End of VerifyLogin
			
		/// <summary>
		/// TESTED 2016.05.07 
		/// Gets all users.
		/// </summary>
		/// <returns>The all users.</returns>
		public List<UserData> GetAllUsers()
		{
			List<UserData> returnList = new List<UserData>();

			try
			{
				OpenConnection();
				string query = "SELECT * FROM users WHERE LeaveDate = '@emptyDate';";
				query = query.Replace ("@emptyDate", DBDefaults.DefaultDate.ToShortDateString ());

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
				DataSet ds = new DataSet();
				dataAdapter.Fill(ds, "users");
				CloseConnection();

				if (ds.Tables["users"].Rows.Count == 0) return returnList;

				foreach (DataRow row in ds.Tables["users"].Rows)
				{
					UserData user = new UserData();
					user.FillFromDataRow(row);
					returnList.Add(user);
				}

				return returnList;
			}
			catch (Exception e)
			{
				string errorMessage = "Exception in DataBaseHandler -> GetAllUsers \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return returnList;
			}
		} // End of GetAllUsers
			
        /// <summary>
		/// TESTED 2016.05.06 
        /// Gets the active projects list.
        /// </summary>
        /// <returns>The active projects list.</returns>
        public List<ProjectData> GetActiveProjectsList()
        {
			List<ProjectData> returnList = new List<ProjectData>();

            try
            {
                OpenConnection();
				string query = "SELECT * FROM projects WHERE TerminatedBy = @emptyId;";
				query = query.Replace ("@emptyId", DBDefaults.DefaultId.ToString ());
                
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "projects");
                CloseConnection();

                if (ds.Tables["projects"].Rows.Count == 0) return returnList;

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
				string errorMessage = "Exception in DataBaseHandler -> GetActiveProjectsList \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return returnList;
            }
        } // End of GetActiveProjectsList

		/// <summary>
		/// TESTED 2016.05.06
		/// Gets the tasks for project.
		/// </summary>
		/// <returns>The tasks for project.</returns>
		/// <param name="project">Project.</param>
		public List<TaskData> GetTasksForProject(ProjectData project)
		{	
			List<TaskData> returnList = new List<TaskData>();

			if (project == null) return returnList;

			try
			{
				OpenConnection();
				string query = "SELECT * FROM tasks WHERE ParentProject = @project_id;";
				query = query.Replace ("@project_id", project.ID.ToString ());

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
				DataSet ds = new DataSet();
				dataAdapter.Fill(ds, "tasks");
				CloseConnection();

				if (ds.Tables["tasks"].Rows.Count == 0) return returnList;

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
				string errorMessage = "Exception in DataBaseHandler -> GetTasksForProject \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return returnList;
			}
		} // End of GetTasksForProject

		public List<TaskData> GetTasksForProjects (List<ProjectData> projects) {
			List<TaskData> list = new List<TaskData> ();

			if (projects == null)
				return list;

			foreach (var project in projects) { 
				foreach (TaskData task in GetTasksForProject (project)) {
					list.Add (task);
				}
			}

			return list;
		}

        /// <summary>
		/// TESTED 2016.05.06
        /// Gets the project suggestions list.
        /// </summary>
        /// <returns>The project suggestions list.</returns>
        public List<ProjectSuggestionData> GetProjectSuggestionsList()
        {
			List<ProjectSuggestionData> returnList = new List<ProjectSuggestionData>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM projectsuggestions";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "projectsuggestions");
                CloseConnection();

                if (ds.Tables["projectsuggestions"].Rows.Count == 0) return returnList;

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
				string errorMessage = "Exception in DataBaseHandler -> GetProjectSuggestionsList \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return returnList;
            }
		}// End of GetProjectSuggestionsList

		/// <summary>
		/// TESTED 2016.05.08
		/// Gets the users for project.
		/// </summary>
		/// <returns>The users for project.</returns>
		/// <param name="project">Project.</param>
		public List<UserData> GetUsersForProject (ProjectData project) {
			Console.WriteLine ("Pushing function");

			List<UserData> list = new List<UserData> ();

			if (project == null) return list;

			list = (List<UserData>)GetAllUsers ().FindAll (u => u.ActiveProject == project.ID);
			if (list == null) return new List<UserData> (); // This should never happen

			return list;
		} // End of GetUsersForProject

        /// <summary>
		/// TESTED 2016.05.06
        /// Inserts the new project.
        /// </summary>
        /// <returns><c>true</c>, if new project was inserted, <c>false</c> otherwise.</returns>
        /// <param name="newProject">New project.</param>
        public bool InsertNewProject(ProjectData newProject)
        {
			if (newProject == null) return false;

            try
            {
                
				{ // Check if there is another project with the same title
					OpenConnection();
					string query = "SELECT * FROM projects WHERE Title = '@project_title';";
					query = query.Replace ("@project_title", newProject.Title);

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "projects");
					CloseConnection();
					if (ds.Tables["projects"].Rows.Count != 0) return false;

				} // End of check
				{ // Insert project
					OpenConnection();
                	string query = "INSERT INTO projects (Title, ShortDescription, DetailedDescription, "
                	    + "CreatedBy, ProjectLead, DateCreated, ModificationLogLink, Notes, AvailableFunds, "
                	    + "CurrentYield, DateTerminated, TerminationReason, TerminatedBy, CollectedFunds, "
                	    + "ConsumedFunds, ImageURL) VALUES " + newProject.ToQueryString() + ";";
                	MySqlCommand command = new MySqlCommand(query, connection);

	                command.ExecuteNonQuery();
    	            command.Dispose();
        	        CloseConnection();

					// Update User
					User.ActiveProject = GetActiveProjectsList ().Find (p => p.Title == newProject.Title).ID;
					UpdateThisUser ();

            	    return true;
				} // End of insert
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> InsertNewProject \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of InsertNewProject

        /// <summary>
		/// TESTED 2016.05.07
        /// Inserts the new task.
        /// </summary>
        /// <returns><c>true</c>, if new task was inserted, <c>false</c> otherwise.</returns>
        /// <param name="newTask">New task.</param>
        public bool InsertNewTask(TaskData newTask)
        {
			if (newTask == null) return false;

            try
            {
				{ // Check if there is another task with the same title within the same project
					OpenConnection();
					string query = "SELECT * FROM tasks WHERE Title = '@project_title' AND ParentProject = @ParentProject;";
					query = query.Replace ("@project_title", newTask.Title);
					query = query.Replace ("@ParentProject", newTask.ParentProject.ToString ());

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "tasks");
					CloseConnection();

					if (ds.Tables["tasks"].Rows.Count != 0) return false;

				} // End of check
				{ // Insert new task
                	OpenConnection();
                	string query = "INSERT INTO tasks (ParentId, Title, ShortDescription, "
                	    + "DetailedDescription, ParentProject, DateCreated, CreatedBy, "
                	    + "DateCompleted, CompletedBy, DeadLine, Status, Notes, ImageURL) "
                	    + "VALUES " + newTask.ToQueryString() + ";";
                	MySqlCommand command = new MySqlCommand(query, connection);

	                command.ExecuteNonQuery();
    	            command.Dispose();
        	        CloseConnection();
            	    return true;
				} // End of Insert
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> InsertNewTask \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of InsertNewTask
		
        /// <summary>
		/// TESTED 2016.05.06
        /// Projects the join request.
        /// </summary>
        /// <returns><c>true</c>, if join request was projected, <c>false</c> otherwise.</returns>
        /// <param name="project">Project.</param>
        public bool ProjectJoinRequest(ProjectData project)
        {
			if (project == null) return false;

            try
            {
				{ // Check if there is already a request
					OpenConnection();
					string query = "SELECT * FROM projectrequests WHERE user_id = @user_id AND project_id = @project_id;";
					query = query.Replace ("@user_id", User.ID.ToString ());
					query = query.Replace ("@project_id", project.ID.ToString ());

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "projectrequests");
					CloseConnection();

					if (ds.Tables["projectrequests"].Rows.Count != 0) return false;
				}
				{ // Insert Join Request
                	OpenConnection();
                	string query = "INSERT INTO projectrequests (user_id, project_id) VALUES (@user_id, @project_id);";
					query = query.Replace ("@user_id", User.ID.ToString ());
					query = query.Replace ("@project_id", project.ID.ToString ());
						
                	MySqlCommand command = new MySqlCommand(query, connection);
						
                	command.ExecuteNonQuery();
                	command.Dispose();
                	CloseConnection();
                	return true;
				}
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> ProjectJoinRequest \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of ProjectJoinRequests

		/// <summary>
		/// TESTED 2016.05.06
		/// Tasks the request.
		/// </summary>
		/// <returns><c>true</c>, if request was tasked, <c>false</c> otherwise.</returns>
		/// <param name="task">Task.</param>
		public bool TaskRequest(TaskData task)
		{
			if (task == null) return false;

			try
			{
				{ // Check if there is already a request
					OpenConnection();
					string query = "SELECT * FROM taskrequests WHERE user_id = @user_id AND task_id = @task_id;";
					query = query.Replace ("@user_id", User.ID.ToString ());
					query = query.Replace ("@task_id", task.ID.ToString ());

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "taskrequests");
					CloseConnection();

					if (ds.Tables["taskrequests"].Rows.Count != 0) return false;
				}
				{
					OpenConnection();
					string query = "INSERT INTO taskrequests (user_id, task_id) VALUES (@user_id, @task_id);";
					query = query.Replace ("@user_id", User.ID.ToString ());
					query = query.Replace ("@task_id", task.ID.ToString ());

					MySqlCommand command = new MySqlCommand(query, connection);

					command.ExecuteNonQuery();
					command.Dispose();
					CloseConnection();
					return true;
				}
			}
			catch (Exception e)
			{
				string errorMessage = "Exception in DataBaseHandler -> TaskRequest \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
			}
		} // End of ProjectJoinRequests

        /// <summary>
		/// TESTED 2016.05.06
        /// Updates the project.
        /// </summary>
        /// <returns><c>true</c>, if project was updated, <c>false</c> otherwise.</returns>
        /// <param name="project">Project.</param>
        public bool UpdateProject(ProjectData project)
        {
			if (project == null) return false;

            try
            {
                OpenConnection();
                string query = "UPDATE projects SET Title = @Title, ShortDescription = @ShortDescription, "
                    + "DetailedDescription = @DetailedDescription, Notes = @Notes, AvailableFunds = @AvailableFunds, "
                    + "CurrentYield = @CurrentYield, DateTerminated = @DateTerminated, TerminationReason = @TerminationReason, "
					+ "TerminatedBy = @TerminatedBy, ProjectLead = @ProjectLead, ModificationLogLink = @ModificationLogLink, "
					+ "CollectedFunds = @CollectedFunds, ConsumedFunds = @ConsumedFunds, ImageURL = @ImageURL"
					+ " WHERE Id = @project_id;";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Title", project.Title);
                command.Parameters.AddWithValue("@ShortDescription", project.ShortDescription);
                command.Parameters.AddWithValue("@DetailedDescription", project.DetailedDescription);
				command.Parameters.AddWithValue("@ProjectLead", project.ProjectLead);
				command.Parameters.AddWithValue("@ModificationLogLink", project.LogURL);
				command.Parameters.AddWithValue("@CollectedFunds", project.CollectedFunds);
				command.Parameters.AddWithValue("@ConsumedFunds", project.ConsumedFunds);
				command.Parameters.AddWithValue("@ImageURL", project.ImageURL);
                command.Parameters.AddWithValue("@Notes", project.Notes);
                command.Parameters.AddWithValue("@AvailableFunds", project.AvailibleFunds);
                command.Parameters.AddWithValue("@CurrentYield", project.CurrentYield);
                command.Parameters.AddWithValue("@DateTerminated", project.DateTerminated.ToShortDateString());
                command.Parameters.AddWithValue("@TerminatedBy", project.TerminatedBy);
                command.Parameters.AddWithValue("@TerminationReason", project.TerminationReason);
                command.Parameters.AddWithValue("@project_id", project.ID);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> UpdateProject \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of UpdateProject
		
		/// <summary>
		/// TESTED 2016.05.07
		/// Updates the task.
		/// </summary>
		/// <returns><c>true</c>, if task was updated, <c>false</c> otherwise.</returns>
		/// <param name="task">Task.</param>
		public bool UpdateTask(TaskData task)
		{
			if (task == null) return false;

			try
			{
				OpenConnection();
				string query = "UPDATE tasks SET ParentId = @ParentId, Title = @Title, "
					+ "ShortDescription = @ShortDescription, DetailedDescription = @DetailedDescription, ParentProject = @ParentProject, "
					+ "DateCreated = @DateCreated, CreatedBy = @CreatedBy, DateCompleted = @DateCompleted, "
					+ "CompletedBy = @CompletedBy, DeadLine = @DeadLine, Status = @Status, "
					+ "Notes = @Notes, ImageURL = @ImageURL"
					+ " WHERE Id = @task_id;";
				MySqlCommand command = new MySqlCommand(query, connection);

				command.Parameters.AddWithValue("@ParentId", task.ParentId);
				command.Parameters.AddWithValue("@Title", task.Title);
				command.Parameters.AddWithValue("@ShortDescription", task.ShortDescription);
				command.Parameters.AddWithValue("@DetailedDescription", task.DetailedDescription);
				command.Parameters.AddWithValue("@ParentProject", task.ParentProject);
				command.Parameters.AddWithValue("@DateCreated", task.DateCreated.ToShortDateString ());
				command.Parameters.AddWithValue("@CreatedBy", task.CreatedBy);
				command.Parameters.AddWithValue("@DateCompleted", task.DateCompleted.ToShortDateString ());
				command.Parameters.AddWithValue("@CompletedBy", task.CompletedBy);
				command.Parameters.AddWithValue("@DeadLine", task.DeadLine.ToShortDateString ());
				command.Parameters.AddWithValue("@Status", task.Status);
				command.Parameters.AddWithValue("@Notes", task.Notes);
				command.Parameters.AddWithValue("@ImageURL", task.ImageURL);
				command.Parameters.AddWithValue("@task_id", task.ID);

				command.ExecuteNonQuery();
				command.Dispose();
				CloseConnection();
				return true;
			}
			catch (Exception e)
			{
				string errorMessage = "Exception in DataBaseHandler -> UpdateTask \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
			}
		} // End of UpdateTask

        /// <summary>
		/// TESTED 2016.05.06
        /// Updates the user.
        /// </summary>
        /// <returns><c>true</c>, if user was updated, <c>false</c> otherwise.</returns>
        /// <param name="user">User.</param>
        private bool UpdateUser(UserData user)
        {
			if (user == null) return false;

            try
            {
                OpenConnection();
                string query = "UPDATE users SET DisplayName = @DisplayName, AvatarLink = @AvatarLink, "
                    + "Email = @Email, PhoneNumber = @PhoneNumber, "
                    + "ActiveProject = @ActiveProject, ActiveTask = @ActiveTask,"
                    + "WorkStatus = @WorkStatus, PersonalNotes = @PersonalNotes WHERE Id = @user_id;";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@DisplayName", user.DisplayName);
                command.Parameters.AddWithValue("@AvatarLink", user.AvatarURL);
                command.Parameters.AddWithValue("@Email", user.Email);
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
				string errorMessage = "Exception in DataBaseHandler -> UpdateUser \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
		} // End of UpdateUser 

        /// <summary>
		/// TESTED 2016.05.09
        /// Updates the this user password.
        /// </summary>
        /// <returns><c>true</c>, if this user password was updated, <c>false</c> otherwise.</returns>
        /// <param name="newPassword">New password.</param>
        public bool UpdateThisUserPassword(string newPassword)
        {
            if (newPassword == null) return false;
            if (newPassword.Equals("")) return false;

            try
            {
                OpenConnection();
                string query = "UPDATE users SET Password = @Password WHERE Id = @user_id;";
                MySqlCommand command = new MySqlCommand(query, connection);

				command.Parameters.AddWithValue("@Password", Hash(password, User.ID));
                command.Parameters.AddWithValue("@user_id", User.ID);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                string errorMessage = "Exception in DataBaseHandler -> UpdateThisUserPassword \n\n" + e.ToString();
                DisplayMessage(errorMessage);
                return false;
            }
        } // End of UpdateUser 

        /// <summary>
		/// TESTED 2016.05.06
        /// Gets all users requesting for project.
        /// </summary>
        /// <returns>The all users requesting for project.</returns>
        /// <param name="project">Project.</param>
        public List<UserData> GetAllUsersRequestingForProject(ProjectData project)
        {
			List<UserData> userList = new List<UserData>();

			if (project == null) return userList;

            try
            {
                OpenConnection();
                string query = "SELECT * FROM users, projectrequests WHERE users.Id = projectrequests.user_id AND projectrequests.project_Id = @project_id;";
				query = query.Replace ("@project_id", project.ID.ToString ());

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "users");
                CloseConnection();

                if (ds.Tables["users"].Rows.Count == 0) return userList;

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
				string errorMessage = "Exception in DataBaseHandler -> GetAllUsersRequestingForProject \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return userList;
            }
        } // End of GetAllUserRequestingForProject

        /// <summary>
		/// TESTED 2016.05.06
        /// Refreshs the user.
        /// </summary>
        /// <returns><c>true</c>, if user was refreshed, <c>false</c> otherwise.</returns>
        /// <param name="user">User.</param>
        public bool RefreshUser(UserData user)
        {
			if (user == null) return false;

            try
            {
                OpenConnection();
				string query = "SELECT * FROM users WHERE Id = @user_id;";
				query = query.Replace ("@user_id", user.ID.ToString ());

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "users");
                CloseConnection();

                if (ds.Tables["users"].Rows.Count == 0) return false;

                foreach (DataRow row in ds.Tables["users"].Rows)
                {
                    user.FillFromDataRow(row);
                }

                return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> RefreshUser \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of RefreshUser

        /// <summary>
		/// TESTED 2016.05.06
        /// Refreshs the project.
        /// </summary>
        /// <returns><c>true</c>, if project was refreshed, <c>false</c> otherwise.</returns>
        /// <param name="project">Project.</param>
        public bool RefreshProject(ProjectData project)
        {
			if (project == null) return false;

            try
            {
                OpenConnection();
                string query = "SELECT * FROM projects WHERE Id = @project_id;";
				query = query.Replace ("@project_id", project.ID.ToString ());

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "projects");
                CloseConnection();

                if (ds.Tables["projects"].Rows.Count == 0) return false;

                foreach (DataRow row in ds.Tables["projects"].Rows)
                {
                    project.FillFromDataRow(row);
                }

                return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> RefreshProject \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of RefreshProject

        /// <summary>
		/// TESTED 2016.05.07
        /// Abolishs the project.
        /// </summary>
        /// <returns><c>true</c>, if project was abolished, <c>false</c> otherwise.</returns>
        /// <param name="reason">Reason.</param>
        public bool AbolishProject(string reason)
        {
			if (reason == null) return false;
            if (reason.Equals("")) reason = DBDefaults.DefaultText;
			if (User.ActiveProject == DBDefaults.DefaultId) return false;

            try
            {
				// Add leavedata to project
				ProjectData myProject = GetCurrentProject();
				myProject.ProjectLead = DBDefaults.DefaultId;
				myProject.DateTerminated = DateTime.Now;
				myProject.TerminatedBy = User.ID;
				myProject.TerminationReason = reason;

				// Make everyone drop that project
				foreach (var user in GetAllUsers().Where(u => u.ActiveProject == myProject.ID)) {
					user.ActiveProject = DBDefaults.DefaultId;
					UpdateUser(user);
				}

                // Drop every request to that project
                //TODO not really doable, need to implement CancelProjectRequest

				// Captain leaves last.
				User.ActiveProject = DBDefaults.DefaultId;
				if (!UpdateProject(myProject)) return false;
				
                return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> AbolishProject \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }

        } // End of AbolishProject

        /// <summary>
		/// TESTED 2016.05.07
        /// Adopts the project suggestion.
        /// </summary>
        /// <returns>The project suggestion.</returns>
        /// <param name="projectSuggestion">Project suggestion.</param>
        public ProjectData AdoptProjectSuggestion(ProjectSuggestionData projectSuggestion)
        {
			if (projectSuggestion == null) return new ProjectData ();
			if (User.ActiveProject != DBDefaults.DefaultId) return new ProjectData ();

            try
            {
                // Fetch the data from the projectSuggestion and put it into the new project
                ProjectData newProject = new ProjectData(User.ID); // ProjectLead, and CreatedBy
                newProject.Title = projectSuggestion.Title;
                newProject.ShortDescription = projectSuggestion.ShortDescription;
                newProject.DetailedDescription = projectSuggestion.DetailedDescription;
                newProject.CreatedBy = projectSuggestion.CreatedBy;
                newProject.DateCreated = DateTime.Now;
                newProject.Notes = projectSuggestion.Notes;
				if (!InsertNewProject(newProject)) return new ProjectData();

                // Add active project to user
				ProjectData project = GetActiveProjectsList().Find (p => p.Title == projectSuggestion.Title);
				if (project == null) return new ProjectData(); // This should never happen.
				User.ActiveProject = project.ID;
                UpdateUser(User);

                // Delete SuggestedProject
                RemoveProjectSuggestion(projectSuggestion);
				projectSuggestion = new ProjectSuggestionData();

                return project;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> AdoptProjectSuggestion \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return new ProjectData();
            }
        } // End of AdoptProjectSuggestions 
		
        /// <summary>
		/// TESTED 2016.05.07
        /// Removes the task.
        /// </summary>
        /// <returns><c>true</c>, if task was removed, <c>false</c> otherwise.</returns>
        /// <param name="task">Task.</param>
        public bool RemoveTask(TaskData task)
        {
			if (task == null) return false;

            try
            {
                OpenConnection();
                string query = "DELETE FROM tasks WHERE  Id = @task_id;";
				query = query.Replace ("@task_id", task.ID.ToString ());

                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> RemoveTask \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of RemoveTask

        /// <summary>
		/// TESTED 2016.05.07
        /// Removes the project suggestion.
        /// </summary>
        /// <returns><c>true</c>, if project suggestion was removed, <c>false</c> otherwise.</returns>
        /// <param name="pj">Pj.</param>
        public bool RemoveProjectSuggestion(ProjectSuggestionData pj)
        {
			if (pj == null) return false;

            try
            {
                OpenConnection();
				string query = "DELETE FROM projectSuggestions WHERE  Id = @projSug_id;";
				query = query.Replace ("@projSug_id", pj.ID.ToString ());

                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                command.Dispose();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> RemoveProjectSuggestion \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
		} // End of RemoveProjectSuggestion

        /// <summary>
		/// TESTED 2016.05.07
        /// Accepts the user project request.
        /// </summary>
        /// <returns><c>true</c>, if user project request was accepted, <c>false</c> otherwise.</returns>
        /// <param name="user">User.</param>
        public bool AcceptUserProjectRequest(UserData user)
        {
			if (user == null) return false;
			if (User.ActiveProject == DBDefaults.DefaultId) return false; // If freelancer

			ProjectData myProject = GetCurrentProject ();
			if (myProject.ProjectLead != User.ID) return false; // If not teamleader

            try
            {	
                { // Check if the user has requests
                    OpenConnection();
                    string query = "SELECT * FROM projectrequests WHERE user_id = @user_id AND project_id = @project_id;";
					query = query.Replace ("@user_id", user.ID.ToString ());
					query = query.Replace ("@project_id", myProject.ID.ToString ());

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds, "projectrequests");
                    CloseConnection();

                    if (ds.Tables["projectrequests"].Rows.Count == 0) return false;
     
                } // End of check
                
				{ // Delete join request
                    OpenConnection();
					string query = "DELETE FROM projectrequests WHERE user_id = @user_id AND project_id = @project_id;";
					query = query.Replace ("@user_id", user.ID.ToString ());
					query = query.Replace ("@project_id", myProject.ID.ToString ());
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.ExecuteNonQuery();
                    command.Dispose();
                    CloseConnection();
                } // End of delete

                // Change activeproject
                user.ActiveProject = myProject.ID;
                UpdateUser(user);

                return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> AcceptUserProjectRequest \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of AcceptUserProjectRequest 

        /// <summary>
		/// TESTED 2016.05.11
        /// Grants the task.
        /// </summary>
        /// <returns><c>true</c>, if task was granted, <c>false</c> otherwise.</returns>
        /// <param name="task">Task.</param>
        /// <param name="user">User.</param>
        public bool GrantTask(TaskData task, UserData user)
        {
			if (task == null) return false;
			if (user == null) return false;
			if (task.ID == DBDefaults.DefaultId) return false;

			bool hasRequest = true;

            try
            {
				// Check if task is free
				UserData tempUser = GetAllUsers ().Find (u => u.ActiveTask == task.ID);
                if (tempUser != null)
                {
                    //MessageBox.Show("Temp User was not null. Task is worked on by: " + tempUser.DisplayName);
                    return false;
                }

				{ // Check if the user has requests
					OpenConnection();
					string query = "SELECT * FROM taskrequests WHERE user_id = @user_id AND task_id = @task_id;";
					query = query.Replace ("@user_id", user.ID.ToString ());
					query = query.Replace ("@task_id", task.ID.ToString ());

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "taskrequests");
					CloseConnection();

					if (ds.Tables["taskrequests"].Rows.Count == 0) hasRequest = false;

				} // End of check


				// If so delete request
				if (hasRequest) {
					OpenConnection();
					string query = "DELETE FROM taskrequests WHERE user_id = @user_id AND task_id = @task_id;";
					query = query.Replace ("@user_id", user.ID.ToString ());
					query = query.Replace ("@task_id", task.ID.ToString ());
					MySqlCommand command = new MySqlCommand(query, connection);

					command.ExecuteNonQuery();
					command.Dispose();
					CloseConnection();
				}

				// Grant task to user
				user.ActiveTask = task.ID;
				UpdateUser(user);
				return true;
            }
            catch (Exception e)
            {
				string errorMessage = "Exception in DataBaseHandler -> GrantTask \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
        } // End of GrantTask 

		/// <summary>
		/// TESTED 2016.05.07
		/// Gets the mode for user.
		///  "error - <message>", 
		///  "freelancer", 
		///  "teammember", 
		///  "teamleader";
		/// </summary>
		/// <returns>The mode for user.</returns>
		/// <param name="user">User.</param>
        public string GetModeForUser(UserData user)
        {
			
			if (user == null) return "error -> user is null!";
			RefreshUser (user);

            if (user.ActiveProject == 0) return "freelancer";
            else {
				ProjectData project = GetActiveProjectsList ().Find (p => p.ProjectLead == user.ID);
				if (project == null)
					return "teammember";
				else {
					Console.WriteLine (project.ID + ") Title: " + project.Title + " ProjectLead: " + project.ProjectLead);
					return "teamleader";
				}
            }
        }// End of GetMode
			
		/// <summary>
		/// TESTED 2016.05.11
		/// Kicks the user from project.
		/// </summary>
		/// <returns><c>true</c>, if user from project was kicked, <c>false</c> otherwise.</returns>
		/// <param name="user">User.</param>
        public bool KickUserFromProject(UserData user)
        {
            if (user == null) return false;
            if (user.Equals(UserData.Default)) return false;
            if (!GetMode().Equals( "teamleader")) return false;
            if (user.ActiveProject == GetCurrentProject().ID) return false;

            // You cannot kick yourself
            if (!GetModeForUser(user).Equals("teamleader")) return false;
            
            // If user has a task, drop task first
            if (user.ActiveTask != DBDefaults.DefaultId) user.ActiveTask = DBDefaults.DefaultId;

            // Kick the user finally
            user.ActiveTask = DBDefaults.DefaultId;
            return true;
        } // End of KickUserFromProject

		/// <summary>
		/// TESTED 2016.05.11
		/// Gets the user working on the task. Returns null if task is free.
		/// </summary>
		/// <returns>The user working on the task.</returns>
		/// <param name="Task">Task.</param>
		public UserData GetUserWorkingOnTask(TaskData task) {

			// Sanity check
			// TODO throws new Exception("Got null as input parameter!");
			if (task == null) return null;

			// Warning! May return null!
			return GetAllUsers ().Find (u => u.ActiveTask == task.ID);
		} // GetUserWorkingOnTask

        /// <summary>
		/// TESTED 2016.05.11
		/// The status of the task:
		/// 1 - Completed (CompletedBy != 0) 
		/// 2 - Overdue (Deadline-current time LT 0 && CompletedBy==0)
		/// 3 - Tackling (Completed by==0 && (COUNT Users.ActiveTask==Task.ID)==1)
		/// 4 - Requested (Completed by==0 && (COUNT taskrequests.Task_ID==Task.ID)>0)
		/// 5 - Idle (Completed by==0 && (COUNT Users.ActiveTask==Task.ID)==0)
		/// - Error (Someting unexpected happened)
		/// </summary>
		/// <returns>The status.</returns>
		/// <param name="task">Task.</param>
		public string TaskStatus(TaskData task) 
		{
			// Sanity check
			if (task == null) return "Error";

			// Completed
			if (task.CompletedBy != DBDefaults.DefaultId) return "Completed";

			// Overdue
			if (task.DeadLine.Subtract(DateTime.Now).TotalHours < 0) return "Overdue";

			// Tackling else Idle or Requested
			if (GetAllUsers ().Find (u => u.ActiveTask == task.ID) != null) return "Tackled";
			else {
				// Has at least 1 user requesting it.
				foreach (UserData user in GetAllUsers()) {
					List<TaskData> allRequestedTasks = GetRequestedTasksForUser (user);
				    if (allRequestedTasks.Count >= 1) {
				        if (allRequestedTasks.Find(t => t.ID == task.ID) != null) return "Requested";
				    }
				}
				return "Idle";
			}
		} // End of TaskStatus

		/// <summary>
		/// TESTED 2016.05.11
		/// Gets the requested tasks for user.
		/// </summary>
		/// <returns>The requested tasks for user.</returns>
		/// <param name="user">User.</param>
		public List<TaskData> GetRequestedTasksForUser(UserData user) {

			List<TaskData> list = new List<TaskData> ();

			// Sanity check
			// TODO throws new Exception("The user has no active project!");
			if (user == null) return list;
			if (user.ActiveProject == DBDefaults.DefaultId) return list;

			try
			{
				OpenConnection();
				string query = "SELECT task_id FROM taskrequests WHERE user_id = @user_id;";
				query = query.Replace ("@user_id", user.ID.ToString ());

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
				DataSet ds = new DataSet();
				dataAdapter.Fill(ds, "taskrequests");
				CloseConnection();

				//TODO throw new Exception("There are no task requests.");
				if (ds.Tables["taskrequests"].Rows.Count == 0) return list;

				foreach (DataRow row in ds.Tables["taskrequests"].Rows)
				{
					int task_id = int.Parse(row.ItemArray.GetValue(0).ToString ());
					TaskData task = GetTasksForProjects(GetActiveProjectsList ()).Find (t => t.ID == task_id);
				    if (task != null) list.Add(task);
				}

				return list;
			}
			catch (Exception e)
			{
				string errorMessage = "Exception in DataBaseHandler -> GetRequestedTasks \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return list;
			}
		} // End of GetRequestedTasks

        /// <summary>
		/// TESTED 2016.05.11
        /// Gets the active task for user.
        /// </summary>
        /// <returns>The active task for user.</returns>
        /// <param name="user">User.</param>
        public TaskData GetActiveTaskForUser(UserData user)
        {
            if (user == null) return null;
            if (user.ActiveTask == DBDefaults.DefaultId) return null;

            // Get task
            ProjectData myProject = GetActiveProjectsList().Find(p => p.ID == user.ActiveProject);
            TaskData task = GetTasksForProject(myProject).Find(t => t.ID == user.ActiveTask);
            return task;
		} // End of GetActiveTaskForUser

		/// <summary>
		/// DOESNT WORK FOR SOME REASON
		/// Gets the users who requested task.
		/// </summary>
		/// <returns>The users who requested task.</returns>
		/// <param name="task">Task.</param>
		public List<UserData> GetUsersWhoRequestedTask (TaskData task) {

			List<UserData> list = new List<UserData> ();

			if (task == null || task.IsDefault ()) {
				return list; 
			}

			list = GetAllUsers ().FindAll (u => GetRequestedTasksForUser(u).Find(t => t.ID == task.ID) != null);
			return list;
		}

		/// <summary>
		/// TESTED 2016.05.11
		/// Gets the user who completed a task.
		/// </summary>
		/// <returns>The user who completed task.</returns>
		/// <param name="task">Task.</param>
		public UserData GetUserWhoCompletedTask (TaskData task) {

			// throw new Exception("Null parameter!");
			if (task == null) return null;
			if (task.IsDefault ()) return null;

			// throw new Exception("Task was not completed!");
			if (task.CompletedBy == DBDefaults.DefaultId) return null;

			// May return null if user is no longer in database!
			return GetAllUsers ().Find (u => u.ID == task.CompletedBy);
		} // End of GetUserWhoCompletedTask

		/// <summary>
		/// TESTED 2016.05.11
		/// Removes the active task.
		/// </summary>
		/// <returns><c>true</c>, if active task was removed, <c>false</c> otherwise.</returns>
		/// <param name="user">User.</param>
		public bool RemoveActiveTaskForUser (UserData user) {

			if (user == null || user.IsDefault ()) return false;

			user.ActiveTask = DBDefaults.DefaultId;
			UpdateUser (user);
			return true;
		} // RemoveActiveTaskForUser

    } // End of Partial Class

    public partial class DatabaseHandler // Connection and other stuff related to basic operations
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

		// TESTED 2016.05.06
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBase.DatabaseHandler"/> class.
        /// </summary>
        public DatabaseHandler()
        {
            server = "localhost";
            database = "test";
            uid = "root";
            password = "root";

            string connectionString =
                "SERVER=" + server + ";"
                + "DATABASE= " + database + ";"
                + "UID=" + uid + ";"
                + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        } // End of Constructor
			
		/// <summary>
		/// TESTED 2016.05.06
		/// This is the display function, when testing one can use the console, or if the
		/// program is live, one can change it to MessageBox for the gui. This will affect all
		/// errormessages.
		/// </summary>
		/// <param name="message">Message.</param>
		private void DisplayMessage (string message) 
		{
			//MessageBox.Show(message); // Uncomment this
			Console.WriteLine(message); // Comment this
		} // End of DisplayMessage
			
		/// <summary>
		/// // TESTED 2016.05.06
		/// This function returns true if the databasehandler can make a connection to the 
		/// database, and return false if not.
		/// </summary>
		public bool Test ()
		{
			bool succes = OpenConnection ();
			CloseConnection ();
			return succes;
		} // End of Test
			
		/// <summary>
		/// TESTED 2016.05.06
		/// Opens the connection.
		/// </summary>
		/// <returns><c>true</c>, if connection was opened, <c>false</c> otherwise.</returns>
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
				string errorMessage;
                switch (ex.Number) {
                case 0:
					errorMessage = "Cannot connect to server.  Contact administrator!";
                	break;
				case 1045:
					errorMessage = "Invalid username/password, please try again!";
                    break;
				default:
					errorMessage = "Could not open connection for some reason. No ideea why.";
					break;
                }

				DisplayMessage (errorMessage);
                return false;
            }
        } // End of OpenConnection()
			
		/// <summary>
		/// TESTED 2016.05.06
		/// Closes the connection.
		/// </summary>
		/// <returns><c>true</c>, if connection was closed, <c>false</c> otherwise.</returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
				DisplayMessage ("Could not close connection: " + ex.ToString ());
                return false;
            }
        } // End of CloseConnection
			
		/// <summary>
		/// TESTED 2016.05.11
		/// Determines whether this instance hash  password salt. (Auto-Generated :)))
		/// Implemented from Ramona's code (copy-paste) and replaced some stuff
		/// Also added some Gyuri magic (deleted curly brackets and stuff)
		/// Don't try to understand this stuff, it is easier to make a new hash 
		/// function than to try to fix this, if it breaks.
		/// </summary>
		/// <returns><c>true</c> if this instance hash password salt; otherwise, <c>false</c>.</returns>
		/// <param name="password">Password.</param>
		/// <param name="salt">Salt.</param>
		public string Hash (string password, int salt) 
		{
			int length = 16; // length of the hash

			if (password == null || salt == 0 || length == 0) return null;
            
            String h = password;
            
            char[] sa;
            char[] ha = new char[length];

            if (password.Length < length)
            {
                //if the string is longer, it repeats the string until it fills the length specified
                while (h.Length <= length - password.Length) h = h + password;
                h = h + password.Substring(0, length % password.Length);

                //create two character arrays: one to return and one to keep the original characters
                sa = h.ToCharArray();
            }
            else
            {
                sa = h.Substring(0, length).ToCharArray();
                int ls = h.Length;//in order not to call the method on every iteration for a potentially very long string
                for (int i = length, j = 0; i < ls; i++, j++)
                {
                    if (j == length) j = i % (password[i] / 9) % length;//predicted character to be ASCII and legible
                                                                        //avoids hash collision on repeated strings and palindroms
                    sa[j] = (char)(sa[j] + password[i]);
                }
            }

            //create sum and products as property variables
            int sum = 0, prod = 7;
			//uses original string
            for (int i = 0; i < password.Length; i++) {
				sum = sum + password[i];
				prod = prod * password[i];
                if (sum > 256) sum = sum % 256;
                if (prod > 256) prod = prod % 256;
                if (prod == 0) prod = 1;
            }
            for (int k = 1; k <= 1; k++)
            {
                //calculate the hash for the characters
                for (int i = 0, j = length / 2; i < length; i++, j++)
                {
                    if (j == length) j = 0;
                    ha[i] = (char)( (Math.Abs(((sa[i] * sa[j] * k + salt) * (sum * (j + 1) + prod * (i + 1))))) % 256);
                    if (ha[i] == 0) ha[i] = (char)231;
                }
                //copy array for next iteration
                for (int t = 0; t < length; t++) sa[t] = ha[t];

                //rotate the array
                char c = ha[0];
                for (int i = 0; i < length - 1; i++) ha[i] = ha[i + 1];
                ha[length - 1] = c;
            }
            return new String(ha);
		} // End of Hash function
    } // End of Partial Class

	// This contains all methods and fields related to the nested user.
    public partial class DatabaseHandler
    {
        // Let it be known that Gyuri objected to this on 2016.04.25!
        private UserData _user;
        public UserData User
        {
			get {return _user;}
            set {_user = value;}
        }
			
		/// <summary>
		/// TESTED 2016.05.06
		/// Login with the specified userName and password.
		/// </summary>
		/// <param name="userName">User name.</param>
		/// <param name="password">Password.</param>
		public bool Login (string userName, string password) {
			User = VerifyLogin (userName, password);
			return !User.IsDefault ();
		} // End of Login
			
        /// <summary>
		/// TESTED 2016.05.07
        /// Gets the current project.
        /// </summary>
        /// <returns>The current project.</returns>
        public ProjectData GetCurrentProject()
        {
			if (User == null) return new ProjectData ();

			ProjectData project = GetActiveProjectsList ().Find (p => p.ID == User.ActiveProject);
			if (project == null)
				return new ProjectData ();
			else
				return project;
        } // End of GetCurrentProject

		/// <summary>
		/// TESTED 2016.05.07
		/// Gets the mode.
		/// </summary>
		/// <returns>The mode.</returns>
        public string GetMode()
        {
            return GetModeForUser(User);
        } // End of GetMode
			
		/// <summary>
		/// TESTED 2016.05.06
		/// Updates the this user.
		/// </summary>
		/// <returns><c>true</c>, if this user was updated, <c>false</c> otherwise.</returns>
		public bool UpdateThisUser()
		{
			return UpdateUser (User);
		} // End of UpdateThisUser ()
			
		/// <summary>
		/// TESTED 2016.05.06
		/// Refreshs the this user.
		/// </summary>
		/// <returns><c>true</c>, if this user was refreshed, <c>false</c> otherwise.</returns>
		public bool RefreshThisUser()
		{
			return RefreshUser (User);
		} // End of RefresThishUser()

		/// <summary>
		/// TESTED 2016.05.06
		/// Drops the task.
		/// </summary>
		/// <returns><c>true</c>, if task was droped, <c>false</c> otherwise.</returns>
		public bool DropTask()
		{
			if (User.ActiveTask == DBDefaults.DefaultId)
				return false;
			else {
				User.ActiveTask = DBDefaults.DefaultId;
				return UpdateUser (User);
			}
		} // End of DropTask
			
		/// <summary>
		/// TESTED 2016.05.06
		/// Leaves the project.
		/// </summary>
		/// <returns><c>true</c>, if project was left, <c>false</c> otherwise.</returns>
		public bool LeaveProject()
		{
			if (User.ActiveProject == DBDefaults.DefaultId) return false;

			//Check if teamleader
			ProjectData project = GetActiveProjectsList ().Find (p => p.ProjectLead == User.ID);
			if (project != null) return false; // Cannot leave if teamleader

			// If not leave project
			User.ActiveProject = DBDefaults.DefaultId;
			return this.UpdateUser(User);
		} // End of LeaveProject
			
       /// <summary>
	   /// TESTED 2016.05.11
       /// Gets the active task.
       /// </summary>
       /// <returns>The active task.</returns>
        public TaskData GetActiveTask()
       {
           return GetActiveTaskForUser(User);
       } // End of GetActiveTask

		/// <summary>
		/// TESTED 2016.05.10
		/// Gets the requested tasks.
		/// </summary>
		/// <returns>The requested tasks.</returns>
		public List<TaskData> GetRequestedTasks () {
			return GetRequestedTasksForUser (User);
        }// End of GetRequestedTasksForUser

		/// <summary>
		/// TESTED 2016.05.07
		/// Cancel a project joinrequest.
		/// </summary>
		/// <returns><c>true</c> if succes; otherwise, <c>false</c>.</returns>
		/// <param name="project">Project.</param>
		public bool CancelProjectJoinRequest(ProjectData project)
		{
			if (project == null) return false;

			try
			{
				{ // Check if there is already a request
					OpenConnection();
					string query = "SELECT * FROM projectrequests WHERE user_id = @user_id AND project_id = @project_id;";
					query = query.Replace ("@user_id", User.ID.ToString ());
					query = query.Replace ("@project_id", project.ID.ToString ());

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "projectrequests");
					CloseConnection();

					if (ds.Tables["projectrequests"].Rows.Count == 0) return false;
				}
				{ // Drop Join Request
					OpenConnection();
					string query = "DELETE FROM projectrequests WHERE user_id = @user_id AND project_id = @project_id;";
					query = query.Replace ("@user_id", User.ID.ToString ());
					query = query.Replace ("@project_id", project.ID.ToString ());

					MySqlCommand command = new MySqlCommand(query, connection);

					command.ExecuteNonQuery();
					command.Dispose();
					CloseConnection();
					return true;
				}
			}
			catch (Exception e)
			{
				string errorMessage = "Exception in DataBaseHandler -> CancelProjectJoinRequest \n\n" + e.ToString();
				DisplayMessage(errorMessage);
				return false;
			}
		} // End of ProjectJoinRequests

        /// <summary>
		/// TESTED 2016.05.11
        /// Cancel a task request.
        /// </summary>
        /// <returns><c>true</c> if succes; otherwise, <c>false</c>.</returns>
        /// <param name="task">Task.</param>
        public bool CancelTaskRequest(TaskData task)
        {
            if (task == null) return false;

            try
            {
                { // Check if there is already a request
                    OpenConnection();
                    string query = "SELECT * FROM taskrequests WHERE user_id = @user_id AND task_id = @task_id;";
                    query = query.Replace("@user_id", User.ID.ToString());
                    query = query.Replace("@task_id", task.ID.ToString());

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds, "taskrequests");
                    CloseConnection();

                    if (ds.Tables["taskrequests"].Rows.Count == 0) return false;
                }
                { // Drop Join Request
                    OpenConnection();
                    string query = "DELETE FROM taskrequests WHERE user_id = @user_id AND task_id = @task_id;";
                    query = query.Replace("@user_id", User.ID.ToString());
                    query = query.Replace("@task_id", task.ID.ToString());

                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.ExecuteNonQuery();
                    command.Dispose();
                    CloseConnection();
                    return true;
                }
            }
            catch (Exception e)
            {
                string errorMessage = "Exception in DataBaseHandler -> CancelTaskRequest \n\n" + e.ToString();
                DisplayMessage(errorMessage);
                return false;
            }
        } // End of CancelTaskRequest

		/// <summary>
		/// TESTED 2016.05.06
		/// Determines whether the User has requested a join to a project.
		/// </summary>
		/// <returns><c>true</c> if this instance has already requested join the specified project; otherwise, <c>false</c>.</returns>
		/// <param name="project">Project.</param>
		public bool HasAlreadyRequestedJoin(ProjectData project)
		{
			if (project == null) return false;

			try
			{
				// Check if there is already a request
				OpenConnection();
				string query = "SELECT * FROM projectrequests WHERE user_id = @user_id AND project_id = @project_id;";
				query = query.Replace("@user_id", User.ID.ToString());
				query = query.Replace("@project_id", project.ID.ToString());

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
				DataSet ds = new DataSet();
				dataAdapter.Fill(ds, "projectrequests");
				CloseConnection();

				if (ds.Tables["projectrequests"].Rows.Count != 0)
					return true;
				else
					return false;

			}
			catch (Exception e)
			{
				string errorMessage = "Exception in DataBaseHandler -> HasAlreadyRequestedJoin \n\n" + e.ToString();
				DisplayMessage(errorMessage);
				return false;
			}
		} // End of HasAlreadyRequestedJoin
    } // End of EmbeddedUser stuff


}