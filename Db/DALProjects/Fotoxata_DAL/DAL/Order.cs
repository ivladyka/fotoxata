
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
	public abstract class _Order : SqlClientEntity
	{
		public _Order()
		{
			this.QuerySource = "Order";
			this.MappingName = "Order";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadAllOrder]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int OrderID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.OrderID, OrderID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "LoadOrderByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter OrderID
			{
				get
				{
					return new SqlParameter("@OrderID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter OrderStatusID
			{
				get
				{
					return new SqlParameter("@OrderStatusID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter DeliveryID
			{
				get
				{
					return new SqlParameter("@DeliveryID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter ClientNote
			{
				get
				{
					return new SqlParameter("@ClientNote", SqlDbType.VarChar, 2000);
				}
			}
			
			public static SqlParameter OfficeNote
			{
				get
				{
					return new SqlParameter("@OfficeNote", SqlDbType.VarChar, 2000);
				}
			}
			
			public static SqlParameter Amount
			{
				get
				{
					return new SqlParameter("@Amount", SqlDbType.Money, 0);
				}
			}
			
			public static SqlParameter CellPhone
			{
				get
				{
					return new SqlParameter("@CellPhone", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter UserID
			{
				get
				{
					return new SqlParameter("@UserID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter DateCreated
			{
				get
				{
					return new SqlParameter("@DateCreated", SqlDbType.DateTime, 0);
				}
			}
			
			public static SqlParameter PhotoCount
			{
				get
				{
					return new SqlParameter("@PhotoCount", SqlDbType.Int, 0);
				}
			}

            public static SqlParameter OrderGuid
            {
                get
                {
                    return new SqlParameter("@OrderGuid", SqlDbType.UniqueIdentifier, 0);
                }
            }
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string OrderID = "OrderID";
            public const string OrderStatusID = "OrderStatusID";
            public const string DeliveryID = "DeliveryID";
            public const string ClientNote = "ClientNote";
            public const string OfficeNote = "OfficeNote";
            public const string Amount = "Amount";
            public const string CellPhone = "CellPhone";
            public const string UserID = "UserID";
            public const string DateCreated = "DateCreated";
            public const string PhotoCount = "PhotoCount";
            public const string OrderGuid = "OrderGuid";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[OrderID] = _Order.PropertyNames.OrderID;
					ht[OrderStatusID] = _Order.PropertyNames.OrderStatusID;
					ht[DeliveryID] = _Order.PropertyNames.DeliveryID;
					ht[ClientNote] = _Order.PropertyNames.ClientNote;
					ht[OfficeNote] = _Order.PropertyNames.OfficeNote;
					ht[Amount] = _Order.PropertyNames.Amount;
					ht[CellPhone] = _Order.PropertyNames.CellPhone;
					ht[UserID] = _Order.PropertyNames.UserID;
					ht[DateCreated] = _Order.PropertyNames.DateCreated;
					ht[PhotoCount] = _Order.PropertyNames.PhotoCount;
                    ht[OrderGuid] = _Order.PropertyNames.OrderGuid;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string OrderID = "OrderID";
            public const string OrderStatusID = "OrderStatusID";
            public const string DeliveryID = "DeliveryID";
            public const string ClientNote = "ClientNote";
            public const string OfficeNote = "OfficeNote";
            public const string Amount = "Amount";
            public const string CellPhone = "CellPhone";
            public const string UserID = "UserID";
            public const string DateCreated = "DateCreated";
            public const string PhotoCount = "PhotoCount";
            public const string OrderGuid = "OrderGuid";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[OrderID] = _Order.ColumnNames.OrderID;
					ht[OrderStatusID] = _Order.ColumnNames.OrderStatusID;
					ht[DeliveryID] = _Order.ColumnNames.DeliveryID;
					ht[ClientNote] = _Order.ColumnNames.ClientNote;
					ht[OfficeNote] = _Order.ColumnNames.OfficeNote;
					ht[Amount] = _Order.ColumnNames.Amount;
					ht[CellPhone] = _Order.ColumnNames.CellPhone;
					ht[UserID] = _Order.ColumnNames.UserID;
					ht[DateCreated] = _Order.ColumnNames.DateCreated;
					ht[PhotoCount] = _Order.ColumnNames.PhotoCount;
                    ht[OrderGuid] = _Order.ColumnNames.OrderGuid;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string OrderID = "s_OrderID";
            public const string OrderStatusID = "s_OrderStatusID";
            public const string DeliveryID = "s_DeliveryID";
            public const string ClientNote = "s_ClientNote";
            public const string OfficeNote = "s_OfficeNote";
            public const string Amount = "s_Amount";
            public const string CellPhone = "s_CellPhone";
            public const string UserID = "s_UserID";
            public const string DateCreated = "s_DateCreated";
            public const string PhotoCount = "s_PhotoCount";
            public const string OrderGuid = "s_OrderGuid";

		}
		#endregion		
		
		#region Properties
	
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

		public virtual int DeliveryID
	    {
			get
	        {
				return base.Getint(ColumnNames.DeliveryID);
			}
			set
	        {
				base.Setint(ColumnNames.DeliveryID, value);
			}
		}

		public virtual string ClientNote
	    {
			get
	        {
				return base.Getstring(ColumnNames.ClientNote);
			}
			set
	        {
				base.Setstring(ColumnNames.ClientNote, value);
			}
		}

		public virtual string OfficeNote
	    {
			get
	        {
				return base.Getstring(ColumnNames.OfficeNote);
			}
			set
	        {
				base.Setstring(ColumnNames.OfficeNote, value);
			}
		}

		public virtual decimal Amount
	    {
			get
	        {
				return base.Getdecimal(ColumnNames.Amount);
			}
			set
	        {
				base.Setdecimal(ColumnNames.Amount, value);
			}
		}

		public virtual string CellPhone
	    {
			get
	        {
				return base.Getstring(ColumnNames.CellPhone);
			}
			set
	        {
				base.Setstring(ColumnNames.CellPhone, value);
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

		public virtual DateTime DateCreated
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.DateCreated);
			}
			set
	        {
				base.SetDateTime(ColumnNames.DateCreated, value);
			}
		}

		public virtual int PhotoCount
	    {
			get
	        {
				return base.Getint(ColumnNames.PhotoCount);
			}
			set
	        {
				base.Setint(ColumnNames.PhotoCount, value);
			}
		}

        public virtual Guid OrderGuid
        {
            get
            {
                return base.GetGuid(ColumnNames.OrderGuid);
            }
            set
            {
                base.SetGuid(ColumnNames.OrderGuid, value);
            }
        }


		#endregion
		
		#region String Properties
	
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

		public virtual string s_DeliveryID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.DeliveryID) ? string.Empty : base.GetintAsString(ColumnNames.DeliveryID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.DeliveryID);
				else
					this.DeliveryID = base.SetintAsString(ColumnNames.DeliveryID, value);
			}
		}

		public virtual string s_ClientNote
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ClientNote) ? string.Empty : base.GetstringAsString(ColumnNames.ClientNote);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ClientNote);
				else
					this.ClientNote = base.SetstringAsString(ColumnNames.ClientNote, value);
			}
		}

		public virtual string s_OfficeNote
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.OfficeNote) ? string.Empty : base.GetstringAsString(ColumnNames.OfficeNote);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.OfficeNote);
				else
					this.OfficeNote = base.SetstringAsString(ColumnNames.OfficeNote, value);
			}
		}

		public virtual string s_Amount
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Amount) ? string.Empty : base.GetdecimalAsString(ColumnNames.Amount);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Amount);
				else
					this.Amount = base.SetdecimalAsString(ColumnNames.Amount, value);
			}
		}

		public virtual string s_CellPhone
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.CellPhone) ? string.Empty : base.GetstringAsString(ColumnNames.CellPhone);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.CellPhone);
				else
					this.CellPhone = base.SetstringAsString(ColumnNames.CellPhone, value);
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

		public virtual string s_DateCreated
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.DateCreated) ? string.Empty : base.GetDateTimeAsString(ColumnNames.DateCreated);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.DateCreated);
				else
					this.DateCreated = base.SetDateTimeAsString(ColumnNames.DateCreated, value);
			}
		}

		public virtual string s_PhotoCount
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.PhotoCount) ? string.Empty : base.GetintAsString(ColumnNames.PhotoCount);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.PhotoCount);
				else
					this.PhotoCount = base.SetintAsString(ColumnNames.PhotoCount, value);
			}
		}

        public virtual string s_OrderGuid
        {
            get
            {
                return this.IsColumnNull(ColumnNames.OrderGuid) ? string.Empty : base.GetGuidAsString(ColumnNames.OrderGuid);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.OrderGuid);
                else
                    this.OrderGuid = base.SetGuidAsString(ColumnNames.OrderGuid, value);
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
				
				
				public WhereParameter OrderID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.OrderID, Parameters.OrderID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
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

				public WhereParameter DeliveryID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.DeliveryID, Parameters.DeliveryID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ClientNote
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ClientNote, Parameters.ClientNote);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter OfficeNote
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.OfficeNote, Parameters.OfficeNote);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Amount
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Amount, Parameters.Amount);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter CellPhone
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.CellPhone, Parameters.CellPhone);
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

				public WhereParameter DateCreated
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.DateCreated, Parameters.DateCreated);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter PhotoCount
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.PhotoCount, Parameters.PhotoCount);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

                public WhereParameter OrderGuid
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.OrderGuid, Parameters.OrderGuid);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }


				private WhereClause _clause;
			}
			#endregion
		
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

			public WhereParameter DeliveryID
		    {
				get
		        {
					if(_DeliveryID_W == null)
	        	    {
						_DeliveryID_W = TearOff.DeliveryID;
					}
					return _DeliveryID_W;
				}
			}

			public WhereParameter ClientNote
		    {
				get
		        {
					if(_ClientNote_W == null)
	        	    {
						_ClientNote_W = TearOff.ClientNote;
					}
					return _ClientNote_W;
				}
			}

			public WhereParameter OfficeNote
		    {
				get
		        {
					if(_OfficeNote_W == null)
	        	    {
						_OfficeNote_W = TearOff.OfficeNote;
					}
					return _OfficeNote_W;
				}
			}

			public WhereParameter Amount
		    {
				get
		        {
					if(_Amount_W == null)
	        	    {
						_Amount_W = TearOff.Amount;
					}
					return _Amount_W;
				}
			}

			public WhereParameter CellPhone
		    {
				get
		        {
					if(_CellPhone_W == null)
	        	    {
						_CellPhone_W = TearOff.CellPhone;
					}
					return _CellPhone_W;
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

			public WhereParameter DateCreated
		    {
				get
		        {
					if(_DateCreated_W == null)
	        	    {
						_DateCreated_W = TearOff.DateCreated;
					}
					return _DateCreated_W;
				}
			}

			public WhereParameter PhotoCount
		    {
				get
		        {
					if(_PhotoCount_W == null)
	        	    {
						_PhotoCount_W = TearOff.PhotoCount;
					}
					return _PhotoCount_W;
				}
			}

            public WhereParameter OrderGuid
            {
                get
                {
                    if (_OrderGuid_W == null)
                    {
                        _OrderGuid_W = TearOff.OrderGuid;
                    }
                    return _OrderGuid_W;
                }
            }

			private WhereParameter _OrderID_W = null;
			private WhereParameter _OrderStatusID_W = null;
			private WhereParameter _DeliveryID_W = null;
			private WhereParameter _ClientNote_W = null;
			private WhereParameter _OfficeNote_W = null;
			private WhereParameter _Amount_W = null;
			private WhereParameter _CellPhone_W = null;
			private WhereParameter _UserID_W = null;
			private WhereParameter _DateCreated_W = null;
			private WhereParameter _PhotoCount_W = null;
            private WhereParameter _OrderGuid_W = null;

			public void WhereClauseReset()
			{
				_OrderID_W = null;
				_OrderStatusID_W = null;
				_DeliveryID_W = null;
				_ClientNote_W = null;
				_OfficeNote_W = null;
				_Amount_W = null;
				_CellPhone_W = null;
				_UserID_W = null;
				_DateCreated_W = null;
				_PhotoCount_W = null;
                _OrderGuid_W = null;

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
				
				
				public AggregateParameter OrderID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.OrderID, Parameters.OrderID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
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

				public AggregateParameter DeliveryID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.DeliveryID, Parameters.DeliveryID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter ClientNote
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ClientNote, Parameters.ClientNote);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter OfficeNote
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.OfficeNote, Parameters.OfficeNote);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Amount
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Amount, Parameters.Amount);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter CellPhone
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.CellPhone, Parameters.CellPhone);
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

				public AggregateParameter DateCreated
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.DateCreated, Parameters.DateCreated);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter PhotoCount
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.PhotoCount, Parameters.PhotoCount);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

                public AggregateParameter OrderGuid
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.OrderGuid, Parameters.OrderGuid);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }


				private AggregateClause _clause;
			}
			#endregion
		
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

			public AggregateParameter DeliveryID
		    {
				get
		        {
					if(_DeliveryID_W == null)
	        	    {
						_DeliveryID_W = TearOff.DeliveryID;
					}
					return _DeliveryID_W;
				}
			}

			public AggregateParameter ClientNote
		    {
				get
		        {
					if(_ClientNote_W == null)
	        	    {
						_ClientNote_W = TearOff.ClientNote;
					}
					return _ClientNote_W;
				}
			}

			public AggregateParameter OfficeNote
		    {
				get
		        {
					if(_OfficeNote_W == null)
	        	    {
						_OfficeNote_W = TearOff.OfficeNote;
					}
					return _OfficeNote_W;
				}
			}

			public AggregateParameter Amount
		    {
				get
		        {
					if(_Amount_W == null)
	        	    {
						_Amount_W = TearOff.Amount;
					}
					return _Amount_W;
				}
			}

			public AggregateParameter CellPhone
		    {
				get
		        {
					if(_CellPhone_W == null)
	        	    {
						_CellPhone_W = TearOff.CellPhone;
					}
					return _CellPhone_W;
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

			public AggregateParameter DateCreated
		    {
				get
		        {
					if(_DateCreated_W == null)
	        	    {
						_DateCreated_W = TearOff.DateCreated;
					}
					return _DateCreated_W;
				}
			}

			public AggregateParameter PhotoCount
		    {
				get
		        {
					if(_PhotoCount_W == null)
	        	    {
						_PhotoCount_W = TearOff.PhotoCount;
					}
					return _PhotoCount_W;
				}
			}

            public AggregateParameter OrderGuid
            {
                get
                {
                    if (_OrderGuid_W == null)
                    {
                        _OrderGuid_W = TearOff.OrderGuid;
                    }
                    return _OrderGuid_W;
                }
            }

			private AggregateParameter _OrderID_W = null;
			private AggregateParameter _OrderStatusID_W = null;
			private AggregateParameter _DeliveryID_W = null;
			private AggregateParameter _ClientNote_W = null;
			private AggregateParameter _OfficeNote_W = null;
			private AggregateParameter _Amount_W = null;
			private AggregateParameter _CellPhone_W = null;
			private AggregateParameter _UserID_W = null;
			private AggregateParameter _DateCreated_W = null;
			private AggregateParameter _PhotoCount_W = null;
            private AggregateParameter _OrderGuid_W = null;

			public void AggregateClauseReset()
			{
				_OrderID_W = null;
				_OrderStatusID_W = null;
				_DeliveryID_W = null;
				_ClientNote_W = null;
				_OfficeNote_W = null;
				_Amount_W = null;
				_CellPhone_W = null;
				_UserID_W = null;
				_DateCreated_W = null;
				_PhotoCount_W = null;
                _OrderGuid_W = null;

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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "InsertOrder]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.OrderID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "UpdateOrder]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "DeleteOrder]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.OrderID);
			p.SourceColumn = ColumnNames.OrderID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.OrderID);
			p.SourceColumn = ColumnNames.OrderID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.OrderStatusID);
			p.SourceColumn = ColumnNames.OrderStatusID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.DeliveryID);
			p.SourceColumn = ColumnNames.DeliveryID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ClientNote);
			p.SourceColumn = ColumnNames.ClientNote;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.OfficeNote);
			p.SourceColumn = ColumnNames.OfficeNote;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Amount);
			p.SourceColumn = ColumnNames.Amount;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.CellPhone);
			p.SourceColumn = ColumnNames.CellPhone;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.UserID);
			p.SourceColumn = ColumnNames.UserID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.DateCreated);
			p.SourceColumn = ColumnNames.DateCreated;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.PhotoCount);
			p.SourceColumn = ColumnNames.PhotoCount;
			p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.OrderGuid);
            p.SourceColumn = ColumnNames.OrderGuid;
            p.SourceVersion = DataRowVersion.Current;

			return cmd;
		}
	}
}
