using System;
using System.Data;

namespace DataBase
{
	public interface DataBaseDataType
	{
		bool IsDefault ();
		string ToQueryString ();
		void FillFromDataRow (DataRow row);
	}
}

