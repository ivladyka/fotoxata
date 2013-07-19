
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
	public abstract class _OrderPhoto : SqlClientEntity
	{
		public _OrderPhoto()
		{
			this.QuerySource = "OrderPhoto";
			this.MappingName = "OrderPhoto";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadAllOrderPhoto]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int OrderPhotoID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.OrderPhotoID, OrderPhotoID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadOrderPhotoByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter OrderPhotoID
			{
				get
				{
					return new SqlParameter("@OrderPhotoID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter ClientPhotoName
			{
				get
				{
					return new SqlParameter("@ClientPhotoName", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter Count
			{
				get
				{
					return new SqlParameter("@Count", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter Border
			{
				get
				{
					return new SqlParameter("@Border", SqlDbType.Bit, 0);
				}
			}
			
			public static SqlParameter PaperTypeID
			{
				get
				{
					return new SqlParameter("@PaperTypeID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter MerchandiseID
			{
				get
				{
					return new SqlParameter("@MerchandiseID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter OrderID
			{
				get
				{
					return new SqlParameter("@OrderID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter PhotoName
			{
				get
				{
					return new SqlParameter("@PhotoName", SqlDbType.VarChar, 50);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string OrderPhotoID = "OrderPhotoID";
            public const string ClientPhotoName = "ClientPhotoName";
            public const string Count = "Count";
            public const string Border = "Border";
            public const string PaperTypeID = "PaperTypeID";
            public const string MerchandiseID = "MerchandiseID";
            public const string OrderID = "OrderID";
            public const string PhotoName = "PhotoName";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[OrderPhotoID] = _OrderPhoto.PropertyNames.OrderPhotoID;
					ht[ClientPhotoName] = _OrderPhoto.PropertyNames.ClientPhotoName;
					ht[Count] = _OrderPhoto.PropertyNames.Count;
					ht[Border] = _OrderPhoto.PropertyNames.Border;
					ht[PaperTypeID] = _OrderPhoto.PropertyNames.PaperTypeID;
					ht[MerchandiseID] = _OrderPhoto.PropertyNames.MerchandiseID;
					ht[OrderID] = _OrderPhoto.PropertyNames.OrderID;
					ht[PhotoName] = _OrderPhoto.PropertyNames.PhotoName;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string OrderPhotoID = "OrderPhotoID";
            public const string ClientPhotoName = "ClientPhotoName";
            public const string Count = "Count";
            public const string Border = "Border";
            public const string PaperTypeID = "PaperTypeID";
            public const string MerchandiseID = "MerchandiseID";
            public const string OrderID = "OrderID";
            public const string PhotoName = "PhotoName";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[OrderPhotoID] = _OrderPhoto.ColumnNames.OrderPhotoID;
					ht[ClientPhotoName] = _OrderPhoto.ColumnNames.ClientPhotoName;
					ht[Count] = _OrderPhoto.ColumnNames.Count;
					ht[Border] = _OrderPhoto.ColumnNames.Border;
					ht[PaperTypeID] = _OrderPhoto.ColumnNames.PaperTypeID;
					ht[MerchandiseID] = _OrderPhoto.ColumnNames.MerchandiseID;
					ht[OrderID] = _OrderPhoto.ColumnNames.OrderID;
					ht[PhotoName] = _OrderPhoto.ColumnNames.PhotoName;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string OrderPhotoID = "s_OrderPhotoID";
            public const string ClientPhotoName = "s_ClientPhotoName";
            public const string Count = "s_Count";
            public const string Border = "s_Border";
            public const string PaperTypeID = "s_PaperTypeID";
            public const string MerchandiseID = "s_MerchandiseID";
            public const string OrderID = "s_OrderID";
            public const string PhotoName = "s_PhotoName";

		}
		#endregion		
		
		#region Properties
	
		public virtual int OrderPhotoID
	    {
			get
	        {
				return base.Getint(ColumnNames.OrderPhotoID);
			}
			set
	        {
				base.Setint(ColumnNames.OrderPhotoID, value);
			}
		}

		public virtual string ClientPhotoName
	    {
			get
	        {
				return base.Getstring(ColumnNames.ClientPhotoName);
			}
			set
	        {
				base.Setstring(ColumnNames.ClientPhotoName, value);
			}
		}

		public virtual int Count
	    {
			get
	        {
				return base.Getint(ColumnNames.Count);
			}
			set
	        {
				base.Setint(ColumnNames.Count, value);
			}
		}

		public virtual bool Border
	    {
			get
	        {
				return base.Getbool(ColumnNames.Border);
			}
			set
	        {
				base.Setbool(ColumnNames.Border, value);
			}
		}

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

		public virtual int MerchandiseID
	    {
			get
	        {
				return base.Getint(ColumnNames.MerchandiseID);
			}
			set
	        {
				base.Setint(ColumnNames.MerchandiseID, value);
			}
		}

		public virtual int OrderID
	    {
			get
	        {
				return base.Getint(ColumnNames.OrderID);
			}
			set
	        {
				base.Setint(ColumnNames.OrderID, value);
			}
		}

		public virtual string PhotoName
	    {
			get
	        {
				return base.Getstring(ColumnNames.PhotoName);
			}
			set
	        {
				base.Setstring(ColumnNames.PhotoName, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_OrderPhotoID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.OrderPhotoID) ? string.Empty : base.GetintAsString(ColumnNames.OrderPhotoID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.OrderPhotoID);
				else
					this.OrderPhotoID = base.SetintAsString(ColumnNames.OrderPhotoID, value);
			}
		}

		public virtual string s_ClientPhotoName
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ClientPhotoName) ? string.Empty : base.GetstringAsString(ColumnNames.ClientPhotoName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ClientPhotoName);
				else
					this.ClientPhotoName = base.SetstringAsString(ColumnNames.ClientPhotoName, value);
			}
		}

		public virtual string s_Count
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Count) ? string.Empty : base.GetintAsString(ColumnNames.Count);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Count);
				else
					this.Count = base.SetintAsString(ColumnNames.Count, value);
			}
		}

		public virtual string s_Border
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Border) ? string.Empty : base.GetboolAsString(ColumnNames.Border);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Border);
				else
					this.Border = base.SetboolAsString(ColumnNames.Border, value);
			}
		}

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

		public virtual string s_MerchandiseID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.MerchandiseID) ? string.Empty : base.GetintAsString(ColumnNames.MerchandiseID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.MerchandiseID);
				else
					this.MerchandiseID = base.SetintAsString(ColumnNames.MerchandiseID, value);
			}
		}

		public virtual string s_OrderID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.OrderID) ? string.Empty : base.GetintAsString(ColumnNames.OrderID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.OrderID);
				else
					this.OrderID = base.SetintAsString(ColumnNames.OrderID, value);
			}
		}

		public virtual string s_PhotoName
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.PhotoName) ? string.Empty : base.GetstringAsString(ColumnNames.PhotoName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.PhotoName);
				else
					this.PhotoName = base.SetstringAsString(ColumnNames.PhotoName, value);
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
				
				
				public WhereParameter OrderPhotoID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.OrderPhotoID, Parameters.OrderPhotoID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ClientPhotoName
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ClientPhotoName, Parameters.ClientPhotoName);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Count
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Count, Parameters.Count);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Border
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Border, Parameters.Border);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
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

				public WhereParameter MerchandiseID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.MerchandiseID, Parameters.MerchandiseID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter OrderID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.OrderID, Parameters.OrderID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter PhotoName
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.PhotoName, Parameters.PhotoName);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter OrderPhotoID
		    {
				get
		        {
					if(_OrderPhotoID_W == null)
	        	    {
						_OrderPhotoID_W = TearOff.OrderPhotoID;
					}
					return _OrderPhotoID_W;
				}
			}

			public WhereParameter ClientPhotoName
		    {
				get
		        {
					if(_ClientPhotoName_W == null)
	        	    {
						_ClientPhotoName_W = TearOff.ClientPhotoName;
					}
					return _ClientPhotoName_W;
				}
			}

			public WhereParameter Count
		    {
				get
		        {
					if(_Count_W == null)
	        	    {
						_Count_W = TearOff.Count;
					}
					return _Count_W;
				}
			}

			public WhereParameter Border
		    {
				get
		        {
					if(_Border_W == null)
	        	    {
						_Border_W = TearOff.Border;
					}
					return _Border_W;
				}
			}

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

			public WhereParameter MerchandiseID
		    {
				get
		        {
					if(_MerchandiseID_W == null)
	        	    {
						_MerchandiseID_W = TearOff.MerchandiseID;
					}
					return _MerchandiseID_W;
				}
			}

			public WhereParameter OrderID
		    {
				get
		        {
					if(_OrderID_W == null)
	        	    {
						_OrderID_W = TearOff.OrderID;
					}
					return _OrderID_W;
				}
			}

			public WhereParameter PhotoName
		    {
				get
		        {
					if(_PhotoName_W == null)
	        	    {
						_PhotoName_W = TearOff.PhotoName;
					}
					return _PhotoName_W;
				}
			}

			private WhereParameter _OrderPhotoID_W = null;
			private WhereParameter _ClientPhotoName_W = null;
			private WhereParameter _Count_W = null;
			private WhereParameter _Border_W = null;
			private WhereParameter _PaperTypeID_W = null;
			private WhereParameter _MerchandiseID_W = null;
			private WhereParameter _OrderID_W = null;
			private WhereParameter _PhotoName_W = null;

			public void WhereClauseReset()
			{
				_OrderPhotoID_W = null;
				_ClientPhotoName_W = null;
				_Count_W = null;
				_Border_W = null;
				_PaperTypeID_W = null;
				_MerchandiseID_W = null;
				_OrderID_W = null;
				_PhotoName_W = null;

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
				
				
				public AggregateParameter OrderPhotoID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.OrderPhotoID, Parameters.OrderPhotoID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter ClientPhotoName
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ClientPhotoName, Parameters.ClientPhotoName);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Count
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Count, Parameters.Count);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Border
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Border, Parameters.Border);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
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

				public AggregateParameter MerchandiseID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.MerchandiseID, Parameters.MerchandiseID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter OrderID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.OrderID, Parameters.OrderID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter PhotoName
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.PhotoName, Parameters.PhotoName);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter OrderPhotoID
		    {
				get
		        {
					if(_OrderPhotoID_W == null)
	        	    {
						_OrderPhotoID_W = TearOff.OrderPhotoID;
					}
					return _OrderPhotoID_W;
				}
			}

			public AggregateParameter ClientPhotoName
		    {
				get
		        {
					if(_ClientPhotoName_W == null)
	        	    {
						_ClientPhotoName_W = TearOff.ClientPhotoName;
					}
					return _ClientPhotoName_W;
				}
			}

			public AggregateParameter Count
		    {
				get
		        {
					if(_Count_W == null)
	        	    {
						_Count_W = TearOff.Count;
					}
					return _Count_W;
				}
			}

			public AggregateParameter Border
		    {
				get
		        {
					if(_Border_W == null)
	        	    {
						_Border_W = TearOff.Border;
					}
					return _Border_W;
				}
			}

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

			public AggregateParameter MerchandiseID
		    {
				get
		        {
					if(_MerchandiseID_W == null)
	        	    {
						_MerchandiseID_W = TearOff.MerchandiseID;
					}
					return _MerchandiseID_W;
				}
			}

			public AggregateParameter OrderID
		    {
				get
		        {
					if(_OrderID_W == null)
	        	    {
						_OrderID_W = TearOff.OrderID;
					}
					return _OrderID_W;
				}
			}

			public AggregateParameter PhotoName
		    {
				get
		        {
					if(_PhotoName_W == null)
	        	    {
						_PhotoName_W = TearOff.PhotoName;
					}
					return _PhotoName_W;
				}
			}

			private AggregateParameter _OrderPhotoID_W = null;
			private AggregateParameter _ClientPhotoName_W = null;
			private AggregateParameter _Count_W = null;
			private AggregateParameter _Border_W = null;
			private AggregateParameter _PaperTypeID_W = null;
			private AggregateParameter _MerchandiseID_W = null;
			private AggregateParameter _OrderID_W = null;
			private AggregateParameter _PhotoName_W = null;

			public void AggregateClauseReset()
			{
				_OrderPhotoID_W = null;
				_ClientPhotoName_W = null;
				_Count_W = null;
				_Border_W = null;
				_PaperTypeID_W = null;
				_MerchandiseID_W = null;
				_OrderID_W = null;
				_PhotoName_W = null;

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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "InsertOrderPhoto]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.OrderPhotoID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "UpdateOrderPhoto]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "DeleteOrderPhoto]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.OrderPhotoID);
			p.SourceColumn = ColumnNames.OrderPhotoID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.OrderPhotoID);
			p.SourceColumn = ColumnNames.OrderPhotoID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ClientPhotoName);
			p.SourceColumn = ColumnNames.ClientPhotoName;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Count);
			p.SourceColumn = ColumnNames.Count;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Border);
			p.SourceColumn = ColumnNames.Border;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.PaperTypeID);
			p.SourceColumn = ColumnNames.PaperTypeID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.MerchandiseID);
			p.SourceColumn = ColumnNames.MerchandiseID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.OrderID);
			p.SourceColumn = ColumnNames.OrderID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.PhotoName);
			p.SourceColumn = ColumnNames.PhotoName;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
