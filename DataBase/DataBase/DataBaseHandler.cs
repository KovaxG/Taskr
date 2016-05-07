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
using System.Net;
using System.Security.AccessControl;
using System.Windows;
using System.Xml;
using DataBase;

namespace DataBase
{
    public partial class DatabaseHandler
    {
		// TESTED 2016.05.06
        /*	@param userName - from login
		 *  @param password - from login
		 *  @return UserData - the data of the user with succesful login or DefaultUser
		 */
		public UserData VerifyLogin(string userName, string password)
        {
			if (userName == null) return new UserData();
			if (password == null) return new UserData();

			try {
            	OpenConnection();
            	string query = "SELECT * FROM users WHERE DisplayName = '@user_name' AND PasswordHash = '@password';";
				query = query.Replace ("@user_name", userName);
				query = query.Replace ("@password", password);

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
			}
			catch (Exception e) 
			{
				string errorMessage = "Exception in DataBaseHandler -> VerifyLogin |\n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return new UserData();
			}
        } // End of VerifyLogin

		// TESTED 2016.05.07 
		/*	@return List<UserData> - returns all users
		 */
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


		// TESTED 2016.05.06 
        /*	@return List<ProjectData> - returns all the availiable projects, emptylist if no projects
		 */
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

		// TESTED 2016.05.06
		/*	@return List<TaskData> - returns all the availiable projects
		 */
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

		// TESTED 2016.05.06
        /*
         * @return List<ProjectData> - returns all the availiable projects
         */ 
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


       	// TESTED 2016.05.06
        /*
		 * @param newProject - inserts into the database all the properties from newProject
		 * @return bool - true if succes, false if failure
		 */
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

		// TESTED 2016.05.07
        /*
		 * @param newTask - inserts into the database all the properties from newTask
		 * @return bool - true if succes, false if failure
		 */
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

        // TESTED 2016.05.06
        /*
		 * @param project - the project that is being requested
		 * @return bool - true if requested, false if not
		 */
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

        // TESTED 2016.05.06
        /*
		 * @param project - the project that is being requested
		 * @return bool - true if succes, false if failure
		 */
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

		// TESTED 2016.05.07
		/*
		 * @param project - the project that is being requested
		 * @return bool - true if succes, false if failure
		 */
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
				string errorMessage = "Exception in DataBaseHandler -> CancelProjectJoinRequest \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
			}
		} // End of ProjectJoinRequests



		// TESTED 2016.05.06
		/*
		 * @param project - the task that is being requested
		 * @return bool - true if succes, false if failure
		 */
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

		//TESTED 2016.05.06
        /* Can Update only:
		 * Title, ShortDescription, DetailedDescription, Notes, AvailableFunds
		 * @param project - update project from table
		 * @return bool - true if succes, false if failure
		 */
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
			
		//TESTED 2016.05.06
        /* Can Update only:
		 * DisplayName, AvatarLink, Email, PasswordHash, PhoneNumber, WorkStatus, PersonalNotes, ActiveProject, ActiveTask
		 * @param user - update user from table
		 * @return bool - true if succes, false if failure
		 */
        private bool UpdateUser(UserData user)
        {
			if (user == null) return false;

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
				string errorMessage = "Exception in DataBaseHandler -> UpdateUser \n\n" + e.ToString ();
				DisplayMessage (errorMessage);
				return false;
            }
		} // End of UpdateUser 

		// TESTED 2016.05.06
        /*
		 * @param project - get all the users requesting for project
		 * @return List<UserData> - all the users
		 */
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

		// TESTED 2016.05.06
        /*
		 * @param user - the user that will be refreshed
		 * @return bool - succes
		 * Also! the user data is changed
		 */
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
			
		// TESTED 2016.05.06
        /*
		 * @param project - the project that will be refreshed
		 * @return bool - succes
		 * Also! the project data is changed
		 */
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
			
		// TESTED 2016.05.07
        /*
         * "Delete" a project. 
		 */
        public bool AbolishProject(string reason)
        {
			if (reason == null) return false;
			if (User.ActiveProject == DBDefaults.DefaultId) return false;

            try
            {
				// Add leavedata to project
				ProjectData myProject = GetCurrentProject();
				myProject.DateTerminated = DateTime.Now;
				myProject.TerminatedBy = User.ID;
				myProject.TerminationReason = reason;

				// Make everyone drop that project
				foreach (var user in GetAllUsers().Where(u => u.ActiveProject == myProject.ID)) {
					user.ActiveProject = DBDefaults.DefaultId;
					UpdateUser(user);
				}

				// Captain leaves last.
				if (!LeaveProject()) return false;
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

		// TESTED 2016.05.07
        /*
		 * @param projectSuggestion - the one that will be adopted? adoptend? ...
		 * @return ProjecData - after creating the project and database and whatevs
		 */
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

		// TESTED 2016.05.07
        /*
		 * @param task - that task that will be deleted
		 */
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

		// TESTED 2016.05.07
        /*
		 * @param pj - that projectSuggestion that will be deleted
		 */
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

		// TESTED 2016.05.07
        /* The teamleader can accept the request, so the user requesting can be part of the project.
		 * @param user - the user that is requesting
		 * @return bool
		 */
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

		// TESTED 2016.05.07
        /*
		 * @param task - the task that is to be assigned
		 * @param uesr - the user, the task that is to be assigned, is assigned to
		 * @return bool - succes
		 */
        public bool GrantTask(TaskData task, UserData user)
        {
			if (task == null) return false;
			if (user == null) return false;
			if (task.ID == DBDefaults.DefaultId) return false;

			bool hasRequest = false;

            try
            {
				// Check if task is free
				UserData tempUser = GetAllUsers ().Find (u => u.ActiveTask == task.ID);
				if (tempUser != null) return false;

				{ // Check if the user has requests
					OpenConnection();
					string query = "SELECT * FROM taskrequests WHERE user_id = @user_id AND task_id = @task_id;";
					query = query.Replace ("@user_id", user.ID.ToString ());
					query = query.Replace ("@task_id", task.ID.ToString ());

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
					DataSet ds = new DataSet();
					dataAdapter.Fill(ds, "taskrequests");
					CloseConnection();

					if (ds.Tables["taskrequests"].Rows.Count == 0) hasRequest = true;

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

		// TESTED 2016.05.07
        /* @ return "error -> <message>", 
         *          "freelancer", 
         *          "teammember", 
         *          "teamleader";
         * 
         */ 
        public string GetModeForUser(UserData user)
        {

			if (user == null) return "error -> user is null!";

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

    } // End of Partial Class

    public partial class DatabaseHandler // Connection and other stuff related to basic operations
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

		// TESTED 2016.05.06
        /* Create connectionstring and connection
         */ 
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

		// TESTED 2016.05.06
		/* This is the display function, when testing one can use the console, or if the
		 * program is live, one can change it to MessageBox for the gui. This will affect all
		 * errormessages.
		 */ 
		private void DisplayMessage (string message) 
		{
			//MessageBox.Show(message); // Uncomment this
			Console.WriteLine(message); // Comment this
		} // End of DisplayMessage

		// TESTED 2016.05.06
		/* This function returns true if the databasehandler can make a connection to the 
		 * database, and return false if not.
		 */ 
		public bool Test ()
		{
			bool succes = OpenConnection ();
			CloseConnection ();
			return succes;
		} // End of Test

		// TESTED 2016.05.06
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

		// TESTED 2016.05.06
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

		// TESTED 2016.05.06
		/* 
		 * Call VerifyUser on the DataBase User
		 */ 
		public bool Login (string userName, string password) {
			User = VerifyLogin (userName, password);
			return User.IsDefault()? false : true;
		} // End of Login

		// TESTED 2016.05.07
        // Used a lambda and I liked it.
        public ProjectData GetCurrentProject()
        {
			if (User == null) return new ProjectData ();

			ProjectData project = GetActiveProjectsList ().Find (p => p.ID == User.ActiveProject);
			if (project == null)
				return new ProjectData ();
			else
				return project;
        } // End of GetCurrentProject

		// TESTED 2016.05.07
        public string GetMode()
        {
            return GetModeForUser(User);
        } // End of GetMode

		// TESTED 2016.05.06
		/* Can Update only:
		 * DisplayName, AvatarLink, Email, PasswordHash, PhoneNumber, WorkStatus, PersonalNotes, ActiveProject, ActiveTask
		 * @return bool - true if succes, false if failure
		 */
		public bool UpdateThisUser()
		{
			return UpdateUser (User);
		} // End of UpdateThisUser ()

		// TESTED 2016.05.06
		/*
		 * @return bool - succes
		 * Also! the user data is changed
		 */
		public bool RefreshThisUser()
		{
			return RefreshUser (User);
		} // End of RefresThishUser()

		// TESTED 2016.05.06
		/*
		 * Drops a task.
		 * 
		 */
		public bool DropTask()
		{
			if (User.ActiveTask == DBDefaults.DefaultId)
				return false;
			else {
				User.ActiveTask = DBDefaults.DefaultId;
				return UpdateUser (User);
			}
		} // End of DropTask

		// TESTED 2016.05.06
		/*
		 * Leave a project
		 */
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
    } // End of EmbeddedUser stuff
}