
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
	public abstract class _OrderStatus : SqlClientEntity
	{
		public _OrderStatus()
		{
			this.QuerySource = "OrderStatus";
			this.MappingName = "OrderStatus";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadAllOrderStatus]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int OrderStatusID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.OrderStatusID, OrderStatusID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadOrderStatusByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter OrderStatusID
			{
				get
				{
					return new SqlParameter("@OrderStatusID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter Name
			{
				get
				{
					return new SqlParameter("@Name", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter Active
			{
				get
				{
					return new SqlParameter("@Active", SqlDbType.Bit, 0);
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
            public const string OrderStatusID = "OrderStatusID";
            public const string Name = "Name";
            public const string Active = "Active";
            public const string Name_ru = "Name_ru";
            public const string Name_en = "Name_en";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[OrderStatusID] = _OrderStatus.PropertyNames.OrderStatusID;
					ht[Name] = _OrderStatus.PropertyNames.Name;
					ht[Active] = _OrderStatus.PropertyNames.Active;
					ht[Name_ru] = _OrderStatus.PropertyNames.Name_ru;
					ht[Name_en] = _OrderStatus.PropertyNames.Name_en;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string OrderStatusID = "OrderStatusID";
            public const string Name = "Name";
            public const string Active = "Active";
            public const string Name_ru = "Name_ru";
            public const string Name_en = "Name_en";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[OrderStatusID] = _OrderStatus.ColumnNames.OrderStatusID;
					ht[Name] = _OrderStatus.ColumnNames.Name;
					ht[Active] = _OrderStatus.ColumnNames.Active;
					ht[Name_ru] = _OrderStatus.ColumnNames.Name_ru;
					ht[Name_en] = _OrderStatus.ColumnNames.Name_en;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string OrderStatusID = "s_OrderStatusID";
            public const string Name = "s_Name";
            public const string Active = "s_Active";
            public const string Name_ru = "s_Name_ru";
            public const string Name_en = "s_Name_en";

		}
		#endregion		
		
		#region Properties
	
		public virtual int OrderStatusID
	    {
			get
	        {
				return base.Getint(ColumnNames.OrderStatusID);
			}
			set
	        {
				base.Setint(ColumnNames.OrderStatusID, value);
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

		public virtual bool Active
	    {
			get
	        {
				return base.Getbool(ColumnNames.Active);
			}
			set
	        {
				base.Setbool(ColumnNames.Active, value);
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
	
		public virtual string s_OrderStatusID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.OrderStatusID) ? string.Empty : base.GetintAsString(ColumnNames.OrderStatusID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.OrderStatusID);
				else
					this.OrderStatusID = base.SetintAsString(ColumnNames.OrderStatusID, value);
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

		public virtual string s_Active
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Active) ? string.Empty : base.GetboolAsString(ColumnNames.Active);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Active);
				else
					this.Active = base.SetboolAsString(ColumnNames.Active, value);
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
				
				
				public WhereParameter OrderStatusID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.OrderStatusID, Parameters.OrderStatusID);
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

				public WhereParameter Active
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Active, Parameters.Active);
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
		
			public WhereParameter OrderStatusID
		    {
				get
		        {
					if(_OrderStatusID_W == null)
	        	    {
						_OrderStatusID_W = TearOff.OrderStatusID;
					}
					return _OrderStatusID_W;
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

			public WhereParameter Active
		    {
				get
		        {
					if(_Active_W == null)
	        	    {
						_Active_W = TearOff.Active;
					}
					return _Active_W;
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

			private WhereParameter _OrderStatusID_W = null;
			private WhereParameter _Name_W = null;
			private WhereParameter _Active_W = null;
			private WhereParameter _Name_ru_W = null;
			private WhereParameter _Name_en_W = null;

			public void WhereClauseReset()
			{
				_OrderStatusID_W = null;
				_Name_W = null;
				_Active_W = null;
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
				
				
				public AggregateParameter OrderStatusID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.OrderStatusID, Parameters.OrderStatusID);
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

				public AggregateParameter Active
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Active, Parameters.Active);
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
		
			public AggregateParameter OrderStatusID
		    {
				get
		        {
					if(_OrderStatusID_W == null)
	        	    {
						_OrderStatusID_W = TearOff.OrderStatusID;
					}
					return _OrderStatusID_W;
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

			public AggregateParameter Active
		    {
				get
		        {
					if(_Active_W == null)
	        	    {
						_Active_W = TearOff.Active;
					}
					return _Active_W;
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

			private AggregateParameter _OrderStatusID_W = null;
			private AggregateParameter _Name_W = null;
			private AggregateParameter _Active_W = null;
			private AggregateParameter _Name_ru_W = null;
			private AggregateParameter _Name_en_W = null;

			public void AggregateClauseReset()
			{
				_OrderStatusID_W = null;
				_Name_W = null;
				_Active_W = null;
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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "InsertOrderStatus]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.OrderStatusID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "UpdateOrderStatus]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "DeleteOrderStatus]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.OrderStatusID);
			p.SourceColumn = ColumnNames.OrderStatusID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.OrderStatusID);
			p.SourceColumn = ColumnNames.OrderStatusID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Name);
			p.SourceColumn = ColumnNames.Name;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Active);
			p.SourceColumn = ColumnNames.Active;
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
