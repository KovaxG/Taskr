using System;
using System.Collections.Generic;
using DataBase;

namespace DataBase
{
	// This class will be used for testing
	class MainClass
	{

		public DatabaseHandler db = new DatabaseHandler();

		public static void Main (string[] args)
		{
			//UserData user = new UserData (1);
			//MainClass tester = new MainClass();
			//tester.Login();

			MainClass main = new MainClass ();
			main.run ();

			Console.ReadKey ();
		}

		public void run () {

			if (!db.Test ()) return;

			try {
				Console.WriteLine ("This is a test of Taskr.\n\n");
				Console.WriteLine ("Login\n\n");
				Console.Write ("UserName: ");
				string username = "mircea";//Console.ReadLine ();
				Console.Write ("Password: ");
				string password = "passwordmircea1";//
				db.Login (username, password);
				Console.WriteLine ("\n\nSuccessful login.");
				printUserDetails (db.User);

				List<ProjectData> projectList = db.GetActiveProjectsList ();
				List<ProjectSuggestionData> projectSuggestionList = db.GetProjectSuggestionsList ();

				Console.WriteLine ("\n========================================");
				Console.WriteLine ("Printing Projects List: \n");
				foreach (ProjectData p in projectList) {
					Console.WriteLine (p.Title);
				}
				foreach (ProjectSuggestionData ps in projectSuggestionList) {
					Console.WriteLine (ps.Title);
				}
				Console.WriteLine ("\n========================================");
			}
			catch(Exception e) 
			{
				Console.WriteLine (e.ToString ());
			}

		}
			

		// User details can be used to fill in any data you want from the form
		public void printUserDetails (UserData user) {
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
			Console.WriteLine ("Observations: " + user.Observations);
			Console.WriteLine ("\n========================================");
		}
	}
}
