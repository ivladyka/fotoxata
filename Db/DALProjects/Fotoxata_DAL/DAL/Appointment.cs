
/*
'===============================================================================
'  Generated From - CSharp_dOOdads_BusinessEntity.vbgen
' 
'  ** IMPORTANT  ** 
'  How to Generate your stored procedures:
' 
'  SQL        = SQL_StoredProcs.vbgen
'  ACCESS     = Access_StoredProcs.vbgen
'  ORACLE     = Oracle_StoredProcs.vbgen
'  FIREBIRD   = FirebirdStoredProcs.vbgen
'  POSTGRESQL = PostgreSQL_StoredProcs.vbgen
'
'  The supporting base class SqlClientEntity is in the Architecture directory in "dOOdads".
'  
'  This object is 'abstract' which means you need to inherit from it to be able
'  to instantiate it.  This is very easilly done. You can override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  public class YourObject :  _YourObject
'  {
'
'  }
'
'===============================================================================
*/

// Generated by MyGeneration Version # (1.2.0.2)

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;

namespace VikkiSoft_BLL.DAL
{
	public abstract class _Appointment : SqlClientEntity
	{
		public _Appointment()
		{
			this.QuerySource = "Appointment";
			this.MappingName = "Appointment";

		}	

		//=================================================================
		//  public Overrides void AddNew()
		//=================================================================
		//
		//=================================================================
		public override void AddNew()
		{
			base.AddNew();
			
		}
		
		
		public override void FlushData()
		{
			this._whereClause = null;
			this._aggregateClause = null;
			base.FlushData();
		}
		
		//=================================================================
		//  	public Function LoadAll() As Boolean
		//=================================================================
		//  Loads all of the records in the database, and sets the currentRow to the first row
		//=================================================================
		public bool LoadAll() 
		{
			ListDictionary parameters = null;
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadAllAppointment]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int AppointmentID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.AppointmentID, AppointmentID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadAppointmentByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter AppointmentID
			{
				get
				{
					return new SqlParameter("@AppointmentID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter UserID
			{
				get
				{
					return new SqlParameter("@UserID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter StartTime
			{
				get
				{
					return new SqlParameter("@StartTime", SqlDbType.DateTime, 0);
				}
			}
			
			public static SqlParameter EndTime
			{
				get
				{
					return new SqlParameter("@EndTime", SqlDbType.DateTime, 0);
				}
			}
			
			public static SqlParameter Subject
			{
				get
				{
					return new SqlParameter("@Subject", SqlDbType.VarChar, 255);
				}
			}
			
			public static SqlParameter AssignedBy
			{
				get
				{
					return new SqlParameter("@AssignedBy", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter AssignedDate
			{
				get
				{
					return new SqlParameter("@AssignedDate", SqlDbType.DateTime, 0);
				}
			}
			
			public static SqlParameter PhotoSalonID
			{
				get
				{
					return new SqlParameter("@PhotoSalonID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter MoneyAdvance
			{
				get
				{
					return new SqlParameter("@MoneyAdvance", SqlDbType.Money, 0);
				}
			}
			
			public static SqlParameter PhoneNumber
			{
				get
				{
					return new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 20);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string AppointmentID = "AppointmentID";
            public const string UserID = "UserID";
            public const string StartTime = "StartTime";
            public const string EndTime = "EndTime";
            public const string Subject = "Subject";
            public const string AssignedBy = "AssignedBy";
            public const string AssignedDate = "AssignedDate";
            public const string PhotoSalonID = "PhotoSalonID";
            public const string MoneyAdvance = "MoneyAdvance";
            public const string PhoneNumber = "PhoneNumber";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[AppointmentID] = _Appointment.PropertyNames.AppointmentID;
					ht[UserID] = _Appointment.PropertyNames.UserID;
					ht[StartTime] = _Appointment.PropertyNames.StartTime;
					ht[EndTime] = _Appointment.PropertyNames.EndTime;
					ht[Subject] = _Appointment.PropertyNames.Subject;
					ht[AssignedBy] = _Appointment.PropertyNames.AssignedBy;
					ht[AssignedDate] = _Appointment.PropertyNames.AssignedDate;
					ht[PhotoSalonID] = _Appointment.PropertyNames.PhotoSalonID;
					ht[MoneyAdvance] = _Appointment.PropertyNames.MoneyAdvance;
					ht[PhoneNumber] = _Appointment.PropertyNames.PhoneNumber;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string AppointmentID = "AppointmentID";
            public const string UserID = "UserID";
            public const string StartTime = "StartTime";
            public const string EndTime = "EndTime";
            public const string Subject = "Subject";
            public const string AssignedBy = "AssignedBy";
            public const string AssignedDate = "AssignedDate";
            public const string PhotoSalonID = "PhotoSalonID";
            public const string MoneyAdvance = "MoneyAdvance";
            public const string PhoneNumber = "PhoneNumber";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[AppointmentID] = _Appointment.ColumnNames.AppointmentID;
					ht[UserID] = _Appointment.ColumnNames.UserID;
					ht[StartTime] = _Appointment.ColumnNames.StartTime;
					ht[EndTime] = _Appointment.ColumnNames.EndTime;
					ht[Subject] = _Appointment.ColumnNames.Subject;
					ht[AssignedBy] = _Appointment.ColumnNames.AssignedBy;
					ht[AssignedDate] = _Appointment.ColumnNames.AssignedDate;
					ht[PhotoSalonID] = _Appointment.ColumnNames.PhotoSalonID;
					ht[MoneyAdvance] = _Appointment.ColumnNames.MoneyAdvance;
					ht[PhoneNumber] = _Appointment.ColumnNames.PhoneNumber;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string AppointmentID = "s_AppointmentID";
            public const string UserID = "s_UserID";
            public const string StartTime = "s_StartTime";
            public const string EndTime = "s_EndTime";
            public const string Subject = "s_Subject";
            public const string AssignedBy = "s_AssignedBy";
            public const string AssignedDate = "s_AssignedDate";
            public const string PhotoSalonID = "s_PhotoSalonID";
            public const string MoneyAdvance = "s_MoneyAdvance";
            public const string PhoneNumber = "s_PhoneNumber";

		}
		#endregion		
		
		#region Properties
	
		public virtual int AppointmentID
	    {
			get
	        {
				return base.Getint(ColumnNames.AppointmentID);
			}
			set
	        {
				base.Setint(ColumnNames.AppointmentID, value);
			}
		}

		public virtual int UserID
	    {
			get
	        {
				return base.Getint(ColumnNames.UserID);
			}
			set
	        {
				base.Setint(ColumnNames.UserID, value);
			}
		}

		public virtual DateTime StartTime
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.StartTime);
			}
			set
	        {
				base.SetDateTime(ColumnNames.StartTime, value);
			}
		}

		public virtual DateTime EndTime
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.EndTime);
			}
			set
	        {
				base.SetDateTime(ColumnNames.EndTime, value);
			}
		}

		public virtual string Subject
	    {
			get
	        {
				return base.Getstring(ColumnNames.Subject);
			}
			set
	        {
				base.Setstring(ColumnNames.Subject, value);
			}
		}

		public virtual int AssignedBy
	    {
			get
	        {
				return base.Getint(ColumnNames.AssignedBy);
			}
			set
	        {
				base.Setint(ColumnNames.AssignedBy, value);
			}
		}

		public virtual DateTime AssignedDate
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.AssignedDate);
			}
			set
	        {
				base.SetDateTime(ColumnNames.AssignedDate, value);
			}
		}

		public virtual int PhotoSalonID
	    {
			get
	        {
				return base.Getint(ColumnNames.PhotoSalonID);
			}
			set
	        {
				base.Setint(ColumnNames.PhotoSalonID, value);
			}
		}

		public virtual decimal MoneyAdvance
	    {
			get
	        {
				return base.Getdecimal(ColumnNames.MoneyAdvance);
			}
			set
	        {
				base.Setdecimal(ColumnNames.MoneyAdvance, value);
			}
		}

		public virtual string PhoneNumber
	    {
			get
	        {
				return base.Getstring(ColumnNames.PhoneNumber);
			}
			set
	        {
				base.Setstring(ColumnNames.PhoneNumber, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_AppointmentID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.AppointmentID) ? string.Empty : base.GetintAsString(ColumnNames.AppointmentID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.AppointmentID);
				else
					this.AppointmentID = base.SetintAsString(ColumnNames.AppointmentID, value);
			}
		}

		public virtual string s_UserID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.UserID) ? string.Empty : base.GetintAsString(ColumnNames.UserID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.UserID);
				else
					this.UserID = base.SetintAsString(ColumnNames.UserID, value);
			}
		}

		public virtual string s_StartTime
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.StartTime) ? string.Empty : base.GetDateTimeAsString(ColumnNames.StartTime);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.StartTime);
				else
					this.StartTime = base.SetDateTimeAsString(ColumnNames.StartTime, value);
			}
		}

		public virtual string s_EndTime
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.EndTime) ? string.Empty : base.GetDateTimeAsString(ColumnNames.EndTime);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.EndTime);
				else
					this.EndTime = base.SetDateTimeAsString(ColumnNames.EndTime, value);
			}
		}

		public virtual string s_Subject
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Subject) ? string.Empty : base.GetstringAsString(ColumnNames.Subject);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Subject);
				else
					this.Subject = base.SetstringAsString(ColumnNames.Subject, value);
			}
		}

		public virtual string s_AssignedBy
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.AssignedBy) ? string.Empty : base.GetintAsString(ColumnNames.AssignedBy);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.AssignedBy);
				else
					this.AssignedBy = base.SetintAsString(ColumnNames.AssignedBy, value);
			}
		}

		public virtual string s_AssignedDate
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.AssignedDate) ? string.Empty : base.GetDateTimeAsString(ColumnNames.AssignedDate);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.AssignedDate);
				else
					this.AssignedDate = base.SetDateTimeAsString(ColumnNames.AssignedDate, value);
			}
		}

		public virtual string s_PhotoSalonID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.PhotoSalonID) ? string.Empty : base.GetintAsString(ColumnNames.PhotoSalonID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.PhotoSalonID);
				else
					this.PhotoSalonID = base.SetintAsString(ColumnNames.PhotoSalonID, value);
			}
		}

		public virtual string s_MoneyAdvance
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.MoneyAdvance) ? string.Empty : base.GetdecimalAsString(ColumnNames.MoneyAdvance);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.MoneyAdvance);
				else
					this.MoneyAdvance = base.SetdecimalAsString(ColumnNames.MoneyAdvance, value);
			}
		}

		public virtual string s_PhoneNumber
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.PhoneNumber) ? string.Empty : base.GetstringAsString(ColumnNames.PhoneNumber);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.PhoneNumber);
				else
					this.PhoneNumber = base.SetstringAsString(ColumnNames.PhoneNumber, value);
			}
		}


		#endregion		
	
		#region Where Clause
		public class WhereClause
		{
			public WhereClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffWhereParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffWhereParameter(this);
					}

					return _tearOff;
				}
			}

			#region WhereParameter TearOff's
			public class TearOffWhereParameter
			{
				public TearOffWhereParameter(WhereClause clause)
				{
					this._clause = clause;
				}
				
				
				public WhereParameter AppointmentID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.AppointmentID, Parameters.AppointmentID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter UserID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.UserID, Parameters.UserID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter StartTime
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.StartTime, Parameters.StartTime);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter EndTime
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.EndTime, Parameters.EndTime);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Subject
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Subject, Parameters.Subject);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter AssignedBy
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.AssignedBy, Parameters.AssignedBy);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter AssignedDate
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.AssignedDate, Parameters.AssignedDate);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter PhotoSalonID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.PhotoSalonID, Parameters.PhotoSalonID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter MoneyAdvance
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.MoneyAdvance, Parameters.MoneyAdvance);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter PhoneNumber
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.PhoneNumber, Parameters.PhoneNumber);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter AppointmentID
		    {
				get
		        {
					if(_AppointmentID_W == null)
	        	    {
						_AppointmentID_W = TearOff.AppointmentID;
					}
					return _AppointmentID_W;
				}
			}

			public WhereParameter UserID
		    {
				get
		        {
					if(_UserID_W == null)
	        	    {
						_UserID_W = TearOff.UserID;
					}
					return _UserID_W;
				}
			}

			public WhereParameter StartTime
		    {
				get
		        {
					if(_StartTime_W == null)
	        	    {
						_StartTime_W = TearOff.StartTime;
					}
					return _StartTime_W;
				}
			}

			public WhereParameter EndTime
		    {
				get
		        {
					if(_EndTime_W == null)
	        	    {
						_EndTime_W = TearOff.EndTime;
					}
					return _EndTime_W;
				}
			}

			public WhereParameter Subject
		    {
				get
		        {
					if(_Subject_W == null)
	        	    {
						_Subject_W = TearOff.Subject;
					}
					return _Subject_W;
				}
			}

			public WhereParameter AssignedBy
		    {
				get
		        {
					if(_AssignedBy_W == null)
	        	    {
						_AssignedBy_W = TearOff.AssignedBy;
					}
					return _AssignedBy_W;
				}
			}

			public WhereParameter AssignedDate
		    {
				get
		        {
					if(_AssignedDate_W == null)
	        	    {
						_AssignedDate_W = TearOff.AssignedDate;
					}
					return _AssignedDate_W;
				}
			}

			public WhereParameter PhotoSalonID
		    {
				get
		        {
					if(_PhotoSalonID_W == null)
	        	    {
						_PhotoSalonID_W = TearOff.PhotoSalonID;
					}
					return _PhotoSalonID_W;
				}
			}

			public WhereParameter MoneyAdvance
		    {
				get
		        {
					if(_MoneyAdvance_W == null)
	        	    {
						_MoneyAdvance_W = TearOff.MoneyAdvance;
					}
					return _MoneyAdvance_W;
				}
			}

			public WhereParameter PhoneNumber
		    {
				get
		        {
					if(_PhoneNumber_W == null)
	        	    {
						_PhoneNumber_W = TearOff.PhoneNumber;
					}
					return _PhoneNumber_W;
				}
			}

			private WhereParameter _AppointmentID_W = null;
			private WhereParameter _UserID_W = null;
			private WhereParameter _StartTime_W = null;
			private WhereParameter _EndTime_W = null;
			private WhereParameter _Subject_W = null;
			private WhereParameter _AssignedBy_W = null;
			private WhereParameter _AssignedDate_W = null;
			private WhereParameter _PhotoSalonID_W = null;
			private WhereParameter _MoneyAdvance_W = null;
			private WhereParameter _PhoneNumber_W = null;

			public void WhereClauseReset()
			{
				_AppointmentID_W = null;
				_UserID_W = null;
				_StartTime_W = null;
				_EndTime_W = null;
				_Subject_W = null;
				_AssignedBy_W = null;
				_AssignedDate_W = null;
				_PhotoSalonID_W = null;
				_MoneyAdvance_W = null;
				_PhoneNumber_W = null;

				this._entity.Query.FlushWhereParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffWhereParameter _tearOff;
			
		}
	
		public WhereClause Where
		{
			get
			{
				if(_whereClause == null)
				{
					_whereClause = new WhereClause(this);
				}
		
				return _whereClause;
			}
		}
		
		private WhereClause _whereClause = null;	
		#endregion
	
		#region Aggregate Clause
		public class AggregateClause
		{
			public AggregateClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffAggregateParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffAggregateParameter(this);
					}

					return _tearOff;
				}
			}

			#region AggregateParameter TearOff's
			public class TearOffAggregateParameter
			{
				public TearOffAggregateParameter(AggregateClause clause)
				{
					this._clause = clause;
				}
				
				
				public AggregateParameter AppointmentID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.AppointmentID, Parameters.AppointmentID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter UserID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.UserID, Parameters.UserID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter StartTime
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.StartTime, Parameters.StartTime);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter EndTime
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.EndTime, Parameters.EndTime);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Subject
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Subject, Parameters.Subject);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter AssignedBy
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.AssignedBy, Parameters.AssignedBy);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter AssignedDate
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.AssignedDate, Parameters.AssignedDate);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter PhotoSalonID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.PhotoSalonID, Parameters.PhotoSalonID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter MoneyAdvance
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.MoneyAdvance, Parameters.MoneyAdvance);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter PhoneNumber
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.PhoneNumber, Parameters.PhoneNumber);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter AppointmentID
		    {
				get
		        {
					if(_AppointmentID_W == null)
	        	    {
						_AppointmentID_W = TearOff.AppointmentID;
					}
					return _AppointmentID_W;
				}
			}

			public AggregateParameter UserID
		    {
				get
		        {
					if(_UserID_W == null)
	        	    {
						_UserID_W = TearOff.UserID;
					}
					return _UserID_W;
				}
			}

			public AggregateParameter StartTime
		    {
				get
		        {
					if(_StartTime_W == null)
	        	    {
						_StartTime_W = TearOff.StartTime;
					}
					return _StartTime_W;
				}
			}

			public AggregateParameter EndTime
		    {
				get
		        {
					if(_EndTime_W == null)
	        	    {
						_EndTime_W = TearOff.EndTime;
					}
					return _EndTime_W;
				}
			}

			public AggregateParameter Subject
		    {
				get
		        {
					if(_Subject_W == null)
	        	    {
						_Subject_W = TearOff.Subject;
					}
					return _Subject_W;
				}
			}

			public AggregateParameter AssignedBy
		    {
				get
		        {
					if(_AssignedBy_W == null)
	        	    {
						_AssignedBy_W = TearOff.AssignedBy;
					}
					return _AssignedBy_W;
				}
			}

			public AggregateParameter AssignedDate
		    {
				get
		        {
					if(_AssignedDate_W == null)
	        	    {
						_AssignedDate_W = TearOff.AssignedDate;
					}
					return _AssignedDate_W;
				}
			}

			public AggregateParameter PhotoSalonID
		    {
				get
		        {
					if(_PhotoSalonID_W == null)
	        	    {
						_PhotoSalonID_W = TearOff.PhotoSalonID;
					}
					return _PhotoSalonID_W;
				}
			}

			public AggregateParameter MoneyAdvance
		    {
				get
		        {
					if(_MoneyAdvance_W == null)
	        	    {
						_MoneyAdvance_W = TearOff.MoneyAdvance;
					}
					return _MoneyAdvance_W;
				}
			}

			public AggregateParameter PhoneNumber
		    {
				get
		        {
					if(_PhoneNumber_W == null)
	        	    {
						_PhoneNumber_W = TearOff.PhoneNumber;
					}
					return _PhoneNumber_W;
				}
			}

			private AggregateParameter _AppointmentID_W = null;
			private AggregateParameter _UserID_W = null;
			private AggregateParameter _StartTime_W = null;
			private AggregateParameter _EndTime_W = null;
			private AggregateParameter _Subject_W = null;
			private AggregateParameter _AssignedBy_W = null;
			private AggregateParameter _AssignedDate_W = null;
			private AggregateParameter _PhotoSalonID_W = null;
			private AggregateParameter _MoneyAdvance_W = null;
			private AggregateParameter _PhoneNumber_W = null;

			public void AggregateClauseReset()
			{
				_AppointmentID_W = null;
				_UserID_W = null;
				_StartTime_W = null;
				_EndTime_W = null;
				_Subject_W = null;
				_AssignedBy_W = null;
				_AssignedDate_W = null;
				_PhotoSalonID_W = null;
				_MoneyAdvance_W = null;
				_PhoneNumber_W = null;

				this._entity.Query.FlushAggregateParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffAggregateParameter _tearOff;
			
		}
	
		public AggregateClause Aggregate
		{
			get
			{
				if(_aggregateClause == null)
				{
					_aggregateClause = new AggregateClause(this);
				}
		
				return _aggregateClause;
			}
		}
		
		private AggregateClause _aggregateClause = null;	
		#endregion
	
		protected override IDbCommand GetInsertCommand() 
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "InsertAppointment]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.AppointmentID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "UpdateAppointment]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "DeleteAppointment]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.AppointmentID);
			p.SourceColumn = ColumnNames.AppointmentID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.AppointmentID);
			p.SourceColumn = ColumnNames.AppointmentID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.UserID);
			p.SourceColumn = ColumnNames.UserID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.StartTime);
			p.SourceColumn = ColumnNames.StartTime;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.EndTime);
			p.SourceColumn = ColumnNames.EndTime;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Subject);
			p.SourceColumn = ColumnNames.Subject;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.AssignedBy);
			p.SourceColumn = ColumnNames.AssignedBy;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.AssignedDate);
			p.SourceColumn = ColumnNames.AssignedDate;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.PhotoSalonID);
			p.SourceColumn = ColumnNames.PhotoSalonID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.MoneyAdvance);
			p.SourceColumn = ColumnNames.MoneyAdvance;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.PhoneNumber);
			p.SourceColumn = ColumnNames.PhoneNumber;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
