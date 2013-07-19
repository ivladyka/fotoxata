
// Generated by MyGeneration Version # (1.2.0.2)

using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using VikkiSoft_BLL.DAL;

namespace VikkiSoft_BLL
{
	public class Appointment : _Appointment
	{
		public Appointment()
		{
		
		}

        public virtual bool LoadByUserID(int userID, DateTime dateStart, DateTime dateEnd)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@UserID", SqlDbType.Int), userID);
            parameters.Add(new SqlParameter("@DateStart", SqlDbType.DateTime), dateStart);
            parameters.Add(new SqlParameter("@DateEnd", SqlDbType.DateTime), dateEnd);

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "usp_Appointment_LoadByUserID]", parameters);
        }
	}
}
