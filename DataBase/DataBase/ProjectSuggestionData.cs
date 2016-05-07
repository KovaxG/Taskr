/*
 * Name: UserData
 * By: Kovacs Gyorgy
 * Date: 2016.04.10 ->
 * 
 * This class will allow, or rather make easier communication with the
 * databaseHandler and the forms. One doesn't have to remember to call
 * the handler 20 times per add or read.
 * 
 * 2016.05.06 - Final Modifications.
 * 
 */
using System;
using System.Data;

namespace DataBase
{
	// This part contains all the methods of the class
	public partial class ProjectSuggestionData : DataBaseDataType
	{

		/* Make sure everything is initialized as we want it.
		 * If you have a better idea of doing it pls talk to Gyuri.
		 *  @param creatorId - Takes the id of the secretary that creates it.
		 */
		public ProjectSuggestionData () : this(DBDefaults.DefaultId)
		{
			// Nothing to do here
		}

		public ProjectSuggestionData (int creatorId)
		{

			Title = DBDefaults.DefaultText;
			ShortDescription = DBDefaults.DefaultText;
			DetailedDescription = DBDefaults.DefaultText;
			CreatedBy = creatorId;
			DateCreated = DBDefaults.DefaultDate;
			InvestmentRequired = DBDefaults.DefaultText;
			EstimatedReturn = DBDefaults.DefaultText;
			Priority = DBDefaults.DefaultText;
			Notes = DBDefaults.DefaultText;
			ImageURL = DBDefaults.DefaultText;
		} // End of Constructor

	    public string ToQueryString ()
		{
			string returnString = "(";

			returnString += "'" + Title + "', "; 								// 1
			returnString += "'" + ShortDescription + "', ";						// 2
			returnString += "'" + DetailedDescription + "', ";					// 3
			returnString += "'" + CreatedBy + "', ";							// 4
			returnString += "'" + DateCreated.ToShortDateString() + "', ";		// 5
			returnString += "'" + InvestmentRequired.ToString() + "', ";		// 6
			returnString += "'" + EstimatedReturn.ToString() + "', ";		    // 7
			returnString += "'" + Priority.ToString() + "', ";					// 8
			returnString += "'" + Notes.ToString() + "', ";						// 9
			returnString += "'" + ImageURL.ToString() + ", ";                   //10

			return returnString += ")";
		} // End of ToQueryString ()

		public void FillFromDataRow (DataRow row)
		{
			_id                 =      int.Parse(row.ItemArray.GetValue (0).ToString ());
			Title               =                row.ItemArray.GetValue (1).ToString ();
			ShortDescription    =                row.ItemArray.GetValue (2).ToString ();
			DetailedDescription =                row.ItemArray.GetValue (3).ToString ();
			CreatedBy           =      int.Parse(row.ItemArray.GetValue (4).ToString ());
			DateCreated         = DateTime.Parse(row.ItemArray.GetValue (5).ToString ());
			InvestmentRequired  =                row.ItemArray.GetValue (6).ToString ();
			EstimatedReturn     =                row.ItemArray.GetValue (7).ToString ();
			Priority            =                row.ItemArray.GetValue (8).ToString ();
			Notes               =                row.ItemArray.GetValue (9).ToString ();
			ImageURL            =                row.ItemArray.GetValue (10).ToString ();
		} // FillFromDataRow ()

		// Check if it is default, kind of like null
		public bool IsDefault() 
		{
			return Equals(Default);
		} // End of IsDefault

		// Compares two ProjectSuggestions
		public bool Equals(ProjectSuggestionData projectSuggestion) 
		{
			if (projectSuggestion == null) return false;
			if (this._id != projectSuggestion.ID) return false;
			return true;
		} // End of Equals
	}

	// This class contains all the attributes of the class, and 
	// setter and getter methods.
	public partial class ProjectSuggestionData
	{
		private int _id;// Id
		public int ID {
			get{return _id;}
		}

		private string _title; // Title
		public string Title {
			set {_title = value;}
			get {return _title;}
		}

		private string _shortDescription; // ShortDescription
		public string ShortDescription {
			set {_shortDescription = value;}
			get {return _shortDescription;}
		}

		private string _detailedDescription; // DetailedDescription
		public string DetailedDescription {
			set {_detailedDescription = value;}
			get {return _detailedDescription;}
		}

		private int _createdBy; // CreatedBy
		public int CreatedBy {
			set {_createdBy = value;}
			get {return _createdBy;}
		}

		private DateTime _dateCreated; // DateCreated
		public DateTime DateCreated {
			set {_dateCreated = value;}
			get {return _dateCreated;}
		}

		private string _investmentRequired; // InvestmentRequired
		public string InvestmentRequired {
			set {_investmentRequired = value;}
			get {return _investmentRequired;}
		}

		private string _estimatedReturn; // EstimatedReturn
		public string EstimatedReturn {
			set {_estimatedReturn = value;}
			get {return _estimatedReturn;}
		}

		private string _priority; // Priority
		public string Priority {
			set {_priority = value;}
			get {return _priority;}
		}

		private string _notes; // Notes
		public string Notes {
			set {_notes = value;}
			get {return _notes;}
		}

	    private string _ImageURL; // ImageURL
	    public string ImageURL {
	        set {_ImageURL = value; }
            get { return _ImageURL; }
	    }

		public static ProjectSuggestionData Default = new ProjectSuggestionData ();
	}
}

