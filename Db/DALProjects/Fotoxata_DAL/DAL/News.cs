
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

// Generated by MyGeneration Version # (1.3.0.3)

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;

namespace VikkiSoft_BLL.DAL
{
	public abstract class _News : SqlClientEntity
	{
		public _News()
		{
			this.QuerySource = "News";
			this.MappingName = "News";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadAllNews]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int NewsID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.NewsID, NewsID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadNewsByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter NewsID
			{
				get
				{
					return new SqlParameter("@NewsID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter Title
			{
				get
				{
					return new SqlParameter("@Title", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter NewsContent
			{
				get
				{
					return new SqlParameter("@NewsContent", SqlDbType.VarChar, 2147483647);
				}
			}
			
			public static SqlParameter DateNews
			{
				get
				{
					return new SqlParameter("@DateNews", SqlDbType.DateTime, 0);
				}
			}
			
			public static SqlParameter DateExpired
			{
				get
				{
					return new SqlParameter("@DateExpired", SqlDbType.DateTime, 0);
				}
			}
			
			public static SqlParameter Title_ru
			{
				get
				{
					return new SqlParameter("@Title_ru", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter Title_en
			{
				get
				{
					return new SqlParameter("@Title_en", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter NewsContent_ru
			{
				get
				{
					return new SqlParameter("@NewsContent_ru", SqlDbType.VarChar, 2147483647);
				}
			}
			
			public static SqlParameter NewsContent_en
			{
				get
				{
					return new SqlParameter("@NewsContent_en", SqlDbType.VarChar, 2147483647);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string NewsID = "NewsID";
            public const string Title = "Title";
            public const string NewsContent = "NewsContent";
            public const string DateNews = "DateNews";
            public const string DateExpired = "DateExpired";
            public const string Title_ru = "Title_ru";
            public const string Title_en = "Title_en";
            public const string NewsContent_ru = "NewsContent_ru";
            public const string NewsContent_en = "NewsContent_en";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[NewsID] = _News.PropertyNames.NewsID;
					ht[Title] = _News.PropertyNames.Title;
					ht[NewsContent] = _News.PropertyNames.NewsContent;
					ht[DateNews] = _News.PropertyNames.DateNews;
					ht[DateExpired] = _News.PropertyNames.DateExpired;
					ht[Title_ru] = _News.PropertyNames.Title_ru;
					ht[Title_en] = _News.PropertyNames.Title_en;
					ht[NewsContent_ru] = _News.PropertyNames.NewsContent_ru;
					ht[NewsContent_en] = _News.PropertyNames.NewsContent_en;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string NewsID = "NewsID";
            public const string Title = "Title";
            public const string NewsContent = "NewsContent";
            public const string DateNews = "DateNews";
            public const string DateExpired = "DateExpired";
            public const string Title_ru = "Title_ru";
            public const string Title_en = "Title_en";
            public const string NewsContent_ru = "NewsContent_ru";
            public const string NewsContent_en = "NewsContent_en";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[NewsID] = _News.ColumnNames.NewsID;
					ht[Title] = _News.ColumnNames.Title;
					ht[NewsContent] = _News.ColumnNames.NewsContent;
					ht[DateNews] = _News.ColumnNames.DateNews;
					ht[DateExpired] = _News.ColumnNames.DateExpired;
					ht[Title_ru] = _News.ColumnNames.Title_ru;
					ht[Title_en] = _News.ColumnNames.Title_en;
					ht[NewsContent_ru] = _News.ColumnNames.NewsContent_ru;
					ht[NewsContent_en] = _News.ColumnNames.NewsContent_en;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string NewsID = "s_NewsID";
            public const string Title = "s_Title";
            public const string NewsContent = "s_NewsContent";
            public const string DateNews = "s_DateNews";
            public const string DateExpired = "s_DateExpired";
            public const string Title_ru = "s_Title_ru";
            public const string Title_en = "s_Title_en";
            public const string NewsContent_ru = "s_NewsContent_ru";
            public const string NewsContent_en = "s_NewsContent_en";

		}
		#endregion		
		
		#region Properties
	
		public virtual int NewsID
	    {
			get
	        {
				return base.Getint(ColumnNames.NewsID);
			}
			set
	        {
				base.Setint(ColumnNames.NewsID, value);
			}
		}

		public virtual string Title
	    {
			get
	        {
				return base.Getstring(ColumnNames.Title);
			}
			set
	        {
				base.Setstring(ColumnNames.Title, value);
			}
		}

		public virtual string NewsContent
	    {
			get
	        {
				return base.Getstring(ColumnNames.NewsContent);
			}
			set
	        {
				base.Setstring(ColumnNames.NewsContent, value);
			}
		}

		public virtual DateTime DateNews
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.DateNews);
			}
			set
	        {
				base.SetDateTime(ColumnNames.DateNews, value);
			}
		}

		public virtual DateTime DateExpired
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.DateExpired);
			}
			set
	        {
				base.SetDateTime(ColumnNames.DateExpired, value);
			}
		}

		public virtual string Title_ru
	    {
			get
	        {
				return base.Getstring(ColumnNames.Title_ru);
			}
			set
	        {
				base.Setstring(ColumnNames.Title_ru, value);
			}
		}

		public virtual string Title_en
	    {
			get
	        {
				return base.Getstring(ColumnNames.Title_en);
			}
			set
	        {
				base.Setstring(ColumnNames.Title_en, value);
			}
		}

		public virtual string NewsContent_ru
	    {
			get
	        {
				return base.Getstring(ColumnNames.NewsContent_ru);
			}
			set
	        {
				base.Setstring(ColumnNames.NewsContent_ru, value);
			}
		}

		public virtual string NewsContent_en
	    {
			get
	        {
				return base.Getstring(ColumnNames.NewsContent_en);
			}
			set
	        {
				base.Setstring(ColumnNames.NewsContent_en, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_NewsID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.NewsID) ? string.Empty : base.GetintAsString(ColumnNames.NewsID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.NewsID);
				else
					this.NewsID = base.SetintAsString(ColumnNames.NewsID, value);
			}
		}

		public virtual string s_Title
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Title) ? string.Empty : base.GetstringAsString(ColumnNames.Title);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Title);
				else
					this.Title = base.SetstringAsString(ColumnNames.Title, value);
			}
		}

		public virtual string s_NewsContent
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.NewsContent) ? string.Empty : base.GetstringAsString(ColumnNames.NewsContent);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.NewsContent);
				else
					this.NewsContent = base.SetstringAsString(ColumnNames.NewsContent, value);
			}
		}

		public virtual string s_DateNews
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.DateNews) ? string.Empty : base.GetDateTimeAsString(ColumnNames.DateNews);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.DateNews);
				else
					this.DateNews = base.SetDateTimeAsString(ColumnNames.DateNews, value);
			}
		}

		public virtual string s_DateExpired
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.DateExpired) ? string.Empty : base.GetDateTimeAsString(ColumnNames.DateExpired);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.DateExpired);
				else
					this.DateExpired = base.SetDateTimeAsString(ColumnNames.DateExpired, value);
			}
		}

		public virtual string s_Title_ru
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Title_ru) ? string.Empty : base.GetstringAsString(ColumnNames.Title_ru);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Title_ru);
				else
					this.Title_ru = base.SetstringAsString(ColumnNames.Title_ru, value);
			}
		}

		public virtual string s_Title_en
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Title_en) ? string.Empty : base.GetstringAsString(ColumnNames.Title_en);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Title_en);
				else
					this.Title_en = base.SetstringAsString(ColumnNames.Title_en, value);
			}
		}

		public virtual string s_NewsContent_ru
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.NewsContent_ru) ? string.Empty : base.GetstringAsString(ColumnNames.NewsContent_ru);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.NewsContent_ru);
				else
					this.NewsContent_ru = base.SetstringAsString(ColumnNames.NewsContent_ru, value);
			}
		}

		public virtual string s_NewsContent_en
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.NewsContent_en) ? string.Empty : base.GetstringAsString(ColumnNames.NewsContent_en);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.NewsContent_en);
				else
					this.NewsContent_en = base.SetstringAsString(ColumnNames.NewsContent_en, value);
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
				
				
				public WhereParameter NewsID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.NewsID, Parameters.NewsID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Title
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Title, Parameters.Title);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter NewsContent
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.NewsContent, Parameters.NewsContent);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter DateNews
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.DateNews, Parameters.DateNews);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter DateExpired
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.DateExpired, Parameters.DateExpired);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Title_ru
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Title_ru, Parameters.Title_ru);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Title_en
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Title_en, Parameters.Title_en);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter NewsContent_ru
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.NewsContent_ru, Parameters.NewsContent_ru);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter NewsContent_en
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.NewsContent_en, Parameters.NewsContent_en);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter NewsID
		    {
				get
		        {
					if(_NewsID_W == null)
	        	    {
						_NewsID_W = TearOff.NewsID;
					}
					return _NewsID_W;
				}
			}

			public WhereParameter Title
		    {
				get
		        {
					if(_Title_W == null)
	        	    {
						_Title_W = TearOff.Title;
					}
					return _Title_W;
				}
			}

			public WhereParameter NewsContent
		    {
				get
		        {
					if(_NewsContent_W == null)
	        	    {
						_NewsContent_W = TearOff.NewsContent;
					}
					return _NewsContent_W;
				}
			}

			public WhereParameter DateNews
		    {
				get
		        {
					if(_DateNews_W == null)
	        	    {
						_DateNews_W = TearOff.DateNews;
					}
					return _DateNews_W;
				}
			}

			public WhereParameter DateExpired
		    {
				get
		        {
					if(_DateExpired_W == null)
	        	    {
						_DateExpired_W = TearOff.DateExpired;
					}
					return _DateExpired_W;
				}
			}

			public WhereParameter Title_ru
		    {
				get
		        {
					if(_Title_ru_W == null)
	        	    {
						_Title_ru_W = TearOff.Title_ru;
					}
					return _Title_ru_W;
				}
			}

			public WhereParameter Title_en
		    {
				get
		        {
					if(_Title_en_W == null)
	        	    {
						_Title_en_W = TearOff.Title_en;
					}
					return _Title_en_W;
				}
			}

			public WhereParameter NewsContent_ru
		    {
				get
		        {
					if(_NewsContent_ru_W == null)
	        	    {
						_NewsContent_ru_W = TearOff.NewsContent_ru;
					}
					return _NewsContent_ru_W;
				}
			}

			public WhereParameter NewsContent_en
		    {
				get
		        {
					if(_NewsContent_en_W == null)
	        	    {
						_NewsContent_en_W = TearOff.NewsContent_en;
					}
					return _NewsContent_en_W;
				}
			}

			private WhereParameter _NewsID_W = null;
			private WhereParameter _Title_W = null;
			private WhereParameter _NewsContent_W = null;
			private WhereParameter _DateNews_W = null;
			private WhereParameter _DateExpired_W = null;
			private WhereParameter _Title_ru_W = null;
			private WhereParameter _Title_en_W = null;
			private WhereParameter _NewsContent_ru_W = null;
			private WhereParameter _NewsContent_en_W = null;

			public void WhereClauseReset()
			{
				_NewsID_W = null;
				_Title_W = null;
				_NewsContent_W = null;
				_DateNews_W = null;
				_DateExpired_W = null;
				_Title_ru_W = null;
				_Title_en_W = null;
				_NewsContent_ru_W = null;
				_NewsContent_en_W = null;

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
				
				
				public AggregateParameter NewsID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.NewsID, Parameters.NewsID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Title
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Title, Parameters.Title);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter NewsContent
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.NewsContent, Parameters.NewsContent);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter DateNews
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.DateNews, Parameters.DateNews);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter DateExpired
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.DateExpired, Parameters.DateExpired);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Title_ru
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Title_ru, Parameters.Title_ru);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Title_en
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Title_en, Parameters.Title_en);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter NewsContent_ru
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.NewsContent_ru, Parameters.NewsContent_ru);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter NewsContent_en
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.NewsContent_en, Parameters.NewsContent_en);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter NewsID
		    {
				get
		        {
					if(_NewsID_W == null)
	        	    {
						_NewsID_W = TearOff.NewsID;
					}
					return _NewsID_W;
				}
			}

			public AggregateParameter Title
		    {
				get
		        {
					if(_Title_W == null)
	        	    {
						_Title_W = TearOff.Title;
					}
					return _Title_W;
				}
			}

			public AggregateParameter NewsContent
		    {
				get
		        {
					if(_NewsContent_W == null)
	        	    {
						_NewsContent_W = TearOff.NewsContent;
					}
					return _NewsContent_W;
				}
			}

			public AggregateParameter DateNews
		    {
				get
		        {
					if(_DateNews_W == null)
	        	    {
						_DateNews_W = TearOff.DateNews;
					}
					return _DateNews_W;
				}
			}

			public AggregateParameter DateExpired
		    {
				get
		        {
					if(_DateExpired_W == null)
	        	    {
						_DateExpired_W = TearOff.DateExpired;
					}
					return _DateExpired_W;
				}
			}

			public AggregateParameter Title_ru
		    {
				get
		        {
					if(_Title_ru_W == null)
	        	    {
						_Title_ru_W = TearOff.Title_ru;
					}
					return _Title_ru_W;
				}
			}

			public AggregateParameter Title_en
		    {
				get
		        {
					if(_Title_en_W == null)
	        	    {
						_Title_en_W = TearOff.Title_en;
					}
					return _Title_en_W;
				}
			}

			public AggregateParameter NewsContent_ru
		    {
				get
		        {
					if(_NewsContent_ru_W == null)
	        	    {
						_NewsContent_ru_W = TearOff.NewsContent_ru;
					}
					return _NewsContent_ru_W;
				}
			}

			public AggregateParameter NewsContent_en
		    {
				get
		        {
					if(_NewsContent_en_W == null)
	        	    {
						_NewsContent_en_W = TearOff.NewsContent_en;
					}
					return _NewsContent_en_W;
				}
			}

			private AggregateParameter _NewsID_W = null;
			private AggregateParameter _Title_W = null;
			private AggregateParameter _NewsContent_W = null;
			private AggregateParameter _DateNews_W = null;
			private AggregateParameter _DateExpired_W = null;
			private AggregateParameter _Title_ru_W = null;
			private AggregateParameter _Title_en_W = null;
			private AggregateParameter _NewsContent_ru_W = null;
			private AggregateParameter _NewsContent_en_W = null;

			public void AggregateClauseReset()
			{
				_NewsID_W = null;
				_Title_W = null;
				_NewsContent_W = null;
				_DateNews_W = null;
				_DateExpired_W = null;
				_Title_ru_W = null;
				_Title_en_W = null;
				_NewsContent_ru_W = null;
				_NewsContent_en_W = null;

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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "InsertNews]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.NewsID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "UpdateNews]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "DeleteNews]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.NewsID);
			p.SourceColumn = ColumnNames.NewsID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.NewsID);
			p.SourceColumn = ColumnNames.NewsID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Title);
			p.SourceColumn = ColumnNames.Title;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.NewsContent);
			p.SourceColumn = ColumnNames.NewsContent;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.DateNews);
			p.SourceColumn = ColumnNames.DateNews;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.DateExpired);
			p.SourceColumn = ColumnNames.DateExpired;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Title_ru);
			p.SourceColumn = ColumnNames.Title_ru;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Title_en);
			p.SourceColumn = ColumnNames.Title_en;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.NewsContent_ru);
			p.SourceColumn = ColumnNames.NewsContent_ru;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.NewsContent_en);
			p.SourceColumn = ColumnNames.NewsContent_en;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
