
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
	public abstract class _PaperType : SqlClientEntity
	{
		public _PaperType()
		{
			this.QuerySource = "PaperType";
			this.MappingName = "PaperType";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadAllPaperType]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int PaperTypeID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.PaperTypeID, PaperTypeID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadPaperTypeByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter PaperTypeID
			{
				get
				{
					return new SqlParameter("@PaperTypeID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter Name
			{
				get
				{
					return new SqlParameter("@Name", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter Name_ru
			{
				get
				{
					return new SqlParameter("@Name_ru", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter Name_en
			{
				get
				{
					return new SqlParameter("@Name_en", SqlDbType.VarChar, 50);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string PaperTypeID = "PaperTypeID";
            public const string Name = "Name";
            public const string Name_ru = "Name_ru";
            public const string Name_en = "Name_en";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[PaperTypeID] = _PaperType.PropertyNames.PaperTypeID;
					ht[Name] = _PaperType.PropertyNames.Name;
					ht[Name_ru] = _PaperType.PropertyNames.Name_ru;
					ht[Name_en] = _PaperType.PropertyNames.Name_en;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string PaperTypeID = "PaperTypeID";
            public const string Name = "Name";
            public const string Name_ru = "Name_ru";
            public const string Name_en = "Name_en";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[PaperTypeID] = _PaperType.ColumnNames.PaperTypeID;
					ht[Name] = _PaperType.ColumnNames.Name;
					ht[Name_ru] = _PaperType.ColumnNames.Name_ru;
					ht[Name_en] = _PaperType.ColumnNames.Name_en;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string PaperTypeID = "s_PaperTypeID";
            public const string Name = "s_Name";
            public const string Name_ru = "s_Name_ru";
            public const string Name_en = "s_Name_en";

		}
		#endregion		
		
		#region Properties
	
		public virtual int PaperTypeID
	    {
			get
	        {
				return base.Getint(ColumnNames.PaperTypeID);
			}
			set
	        {
				base.Setint(ColumnNames.PaperTypeID, value);
			}
		}

		public virtual string Name
	    {
			get
	        {
				return base.Getstring(ColumnNames.Name);
			}
			set
	        {
				base.Setstring(ColumnNames.Name, value);
			}
		}

		public virtual string Name_ru
	    {
			get
	        {
				return base.Getstring(ColumnNames.Name_ru);
			}
			set
	        {
				base.Setstring(ColumnNames.Name_ru, value);
			}
		}

		public virtual string Name_en
	    {
			get
	        {
				return base.Getstring(ColumnNames.Name_en);
			}
			set
	        {
				base.Setstring(ColumnNames.Name_en, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_PaperTypeID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.PaperTypeID) ? string.Empty : base.GetintAsString(ColumnNames.PaperTypeID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.PaperTypeID);
				else
					this.PaperTypeID = base.SetintAsString(ColumnNames.PaperTypeID, value);
			}
		}

		public virtual string s_Name
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Name) ? string.Empty : base.GetstringAsString(ColumnNames.Name);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Name);
				else
					this.Name = base.SetstringAsString(ColumnNames.Name, value);
			}
		}

		public virtual string s_Name_ru
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Name_ru) ? string.Empty : base.GetstringAsString(ColumnNames.Name_ru);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Name_ru);
				else
					this.Name_ru = base.SetstringAsString(ColumnNames.Name_ru, value);
			}
		}

		public virtual string s_Name_en
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Name_en) ? string.Empty : base.GetstringAsString(ColumnNames.Name_en);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Name_en);
				else
					this.Name_en = base.SetstringAsString(ColumnNames.Name_en, value);
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
				
				
				public WhereParameter PaperTypeID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.PaperTypeID, Parameters.PaperTypeID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Name
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Name, Parameters.Name);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Name_ru
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Name_ru, Parameters.Name_ru);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Name_en
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Name_en, Parameters.Name_en);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter PaperTypeID
		    {
				get
		        {
					if(_PaperTypeID_W == null)
	        	    {
						_PaperTypeID_W = TearOff.PaperTypeID;
					}
					return _PaperTypeID_W;
				}
			}

			public WhereParameter Name
		    {
				get
		        {
					if(_Name_W == null)
	        	    {
						_Name_W = TearOff.Name;
					}
					return _Name_W;
				}
			}

			public WhereParameter Name_ru
		    {
				get
		        {
					if(_Name_ru_W == null)
	        	    {
						_Name_ru_W = TearOff.Name_ru;
					}
					return _Name_ru_W;
				}
			}

			public WhereParameter Name_en
		    {
				get
		        {
					if(_Name_en_W == null)
	        	    {
						_Name_en_W = TearOff.Name_en;
					}
					return _Name_en_W;
				}
			}

			private WhereParameter _PaperTypeID_W = null;
			private WhereParameter _Name_W = null;
			private WhereParameter _Name_ru_W = null;
			private WhereParameter _Name_en_W = null;

			public void WhereClauseReset()
			{
				_PaperTypeID_W = null;
				_Name_W = null;
				_Name_ru_W = null;
				_Name_en_W = null;

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
				
				
				public AggregateParameter PaperTypeID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.PaperTypeID, Parameters.PaperTypeID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Name
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Name, Parameters.Name);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Name_ru
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Name_ru, Parameters.Name_ru);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Name_en
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Name_en, Parameters.Name_en);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter PaperTypeID
		    {
				get
		        {
					if(_PaperTypeID_W == null)
	        	    {
						_PaperTypeID_W = TearOff.PaperTypeID;
					}
					return _PaperTypeID_W;
				}
			}

			public AggregateParameter Name
		    {
				get
		        {
					if(_Name_W == null)
	        	    {
						_Name_W = TearOff.Name;
					}
					return _Name_W;
				}
			}

			public AggregateParameter Name_ru
		    {
				get
		        {
					if(_Name_ru_W == null)
	        	    {
						_Name_ru_W = TearOff.Name_ru;
					}
					return _Name_ru_W;
				}
			}

			public AggregateParameter Name_en
		    {
				get
		        {
					if(_Name_en_W == null)
	        	    {
						_Name_en_W = TearOff.Name_en;
					}
					return _Name_en_W;
				}
			}

			private AggregateParameter _PaperTypeID_W = null;
			private AggregateParameter _Name_W = null;
			private AggregateParameter _Name_ru_W = null;
			private AggregateParameter _Name_en_W = null;

			public void AggregateClauseReset()
			{
				_PaperTypeID_W = null;
				_Name_W = null;
				_Name_ru_W = null;
				_Name_en_W = null;

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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "InsertPaperType]";
	
			CreateParameters(cmd);
			    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "UpdatePaperType]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "DeletePaperType]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.PaperTypeID);
			p.SourceColumn = ColumnNames.PaperTypeID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.PaperTypeID);
			p.SourceColumn = ColumnNames.PaperTypeID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Name);
			p.SourceColumn = ColumnNames.Name;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Name_ru);
			p.SourceColumn = ColumnNames.Name_ru;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Name_en);
			p.SourceColumn = ColumnNames.Name_en;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
