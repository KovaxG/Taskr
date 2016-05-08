/*
 * This is something that I use purely for testing, don't bother reading this!
 */ 
using System;
using System.Collections.Generic;
using DataBase;
using System.Linq;

namespace DataBase
{
	// This class will be used for testing
	class MainClass
	{

		public DatabaseHandler db = new DatabaseHandler();

		public static void Main (string[] args)
		{
			MainClass main = new MainClass ();
			main.run ();

			Console.ReadKey ();
		}

		public void run () {

			// Check if can connect to database-------------------------------------------------
			Console.WriteLine ("Attempting to connect to database...");
			if (!db.Test ()) {
				Console.WriteLine ("Could not connect to database!");
				return;
			} else
				Console.WriteLine ("Connection to database succesfull.");
			// End of Check----------------------------------------------------------------------



			// Login-----------------------------------------------------------------------------
			Console.WriteLine ("Login\n\n");
			Console.Write ("UserName: ");
			string username = "Gyuri";//Console.ReadLine ();
			Console.Write ("Password: ");
			string password = "password";//
			if (db.Login (username, password)) {
				Console.WriteLine ("\n\nSuccessful login.");
				printUserDetails (db.User);
				Console.WriteLine ("Current Project = " + db.GetCurrentProject ().Title);
			}
			else Console.WriteLine ("Login not succesfull.");
			// End of Login----------------------------------------------------------------------

			viewAvailibleProjects ();



		}

		public void viewAvailibleProjects() {
			List<ProjectData> projectList = db.GetActiveProjectsList ();
			List<ProjectSuggestionData> projectSuggestionList = db.GetProjectSuggestionsList ();

			Console.WriteLine ("\n========================================");
			Console.WriteLine ("Printing Projects List: \n");

			foreach (ProjectData p in projectList) {
				Console.WriteLine (p.Title);
			}

			Console.WriteLine ("\n\nPrinting ProjectSuggestions List: \n");
			foreach (ProjectSuggestionData ps in projectSuggestionList) {
				Console.WriteLine (ps.Title);
			}
			Console.WriteLine ("\n========================================");


			ProjectData project = db.GetActiveProjectsList ().Find (p => p.ID == 1);
			TaskData task = db.GetTasksForProject (project).First();
		
			task.ShortDescription = "Bla bla bla";

			Console.WriteLine (db.UpdateTask (task));

			//db.ProjectJoinRequest (projectList.Find(p => p.ID == 1));
			//db.CancelProjectJoinRequest (projectList.Find(p => p.ID == 8));

			//db.AbolishProject ("Testing");

		}
			

		// User details can be used to fill in any data you want from the form
		public void printUserDetails (UserData user) {
			if (user == null) return;
			Console.WriteLine ("\n========================================");
			Console.WriteLine ("Printing user details...\n");
			Console.WriteLine ("FirstName: " + user.FirstName);
			Console.WriteLine ("LastName: " + user.LastName);
			Console.WriteLine ("DisplayName: " + user.DisplayName);
			Console.WriteLine ("AvatarURL: " + user.AvatarURL);
			Console.WriteLine ("Email: " + user.Email);
			Console.WriteLine ("Password: " + user.Password);
			Console.WriteLine ("PhoneNumber: " + user.PhoneNumber);
			Console.WriteLine ("JoinDate: " + user.JoinDate.ToString ());
			Console.WriteLine ("AddedById: " + user.AddedById);
			Console.WriteLine ("ActiveProject: " + user.ActiveProject);
			Console.WriteLine ("ActiveTask: " + user.ActiveTask);
			Console.WriteLine ("WorkStatus: " + user.WorkStatus);
			Console.WriteLine ("PersonalNotes: " + user.PersonalNotes);
			Console.WriteLine ("DateLeft: " + user.DateLeft.ToString ());
			Console.WriteLine ("ReasonForLeaving: " + user.ReasonForLeaving);
			Console.WriteLine ("RejoinDesirability: " + user.RejoinDesirability);
			Console.WriteLine ("Observations: " + user.Notes);
			Console.WriteLine ("\n========================================");
		}
	}
}
