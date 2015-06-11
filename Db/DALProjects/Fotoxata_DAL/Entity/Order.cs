
// Generated by MyGeneration Version # (1.2.0.2)
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using VikkiSoft_BLL.DAL;

namespace VikkiSoft_BLL
{
	public class Order : _Order
	{
		public Order()
		{
		
		}

        public virtual bool LoadDashboard()
        {
            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "usp_Order_LoadDashboard]");
        }

        public virtual bool LoadByDeliveryIDAndOrderStatusID(int deliveryID, int orderStatusID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@DeliveryID", SqlDbType.Int), deliveryID);
            parameters.Add(new SqlParameter("@OrderStatusID", SqlDbType.Int), orderStatusID);

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "usp_Order_LoadByDeliveryIDAndOrderStatusID]", parameters);
        }
        public virtual bool LoadByUserID(int userID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@UserID", SqlDbType.Int), userID);
            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "usp_Order_LoadByUserID]", parameters);
        }

        public virtual void UpdateOrderPhotosAllUploaded(int orderID, int count, bool border, int paperTypeID, int merchandiseID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@OrderID", SqlDbType.Int), orderID);
            parameters.Add(new SqlParameter("@Count", SqlDbType.Int), count);
            parameters.Add(new SqlParameter("@Border", SqlDbType.Bit), border);
            parameters.Add(new SqlParameter("@PaperTypeID", SqlDbType.Int), paperTypeID);
            parameters.Add(new SqlParameter("@MerchandiseID", SqlDbType.Int), merchandiseID);

            base.LoadFromSql("[" + this.SchemaStoredProcedure + "UpdateOrderPhotosAllUploaded]", parameters);
        }

	}
}
