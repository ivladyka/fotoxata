
// Generated by MyGeneration Version # (1.2.0.2)

using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using VikkiSoft_BLL.DAL;

namespace VikkiSoft_BLL
{
	public class Gallery : _Gallery
	{
		public Gallery()
		{
		
		}

        public virtual bool LoadByCategoryID(int categoryID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int), categoryID);

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "usp_Gallery_LoadByCategoryID]", parameters);
        }

        public virtual void Move(int categoryID, int sourceGalleryID, int destGalleryID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int), categoryID);
            parameters.Add(new SqlParameter("@SourceGalleryID", SqlDbType.Int), sourceGalleryID);
            if (destGalleryID > 0)
            {
                parameters.Add(new SqlParameter("@DestGalleryID", SqlDbType.Int), destGalleryID);
            }

            base.LoadFromSql("[" + this.SchemaStoredProcedure + "usp_Gallery_Move]", parameters);
        }

	}
}
