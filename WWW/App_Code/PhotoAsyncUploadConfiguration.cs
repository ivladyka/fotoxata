using System;
using Telerik.Web.UI;

/// <summary>
/// Summary description for PhotoAsyncUploadConfiguration
/// </summary>
public class PhotoAsyncUploadConfiguration : AsyncUploadConfiguration
{
    private int m_OrderID = 0;
    private int m_DeliveryID = 0;
    private int m_PaperTypeID = 0;
    private int m_MerchandiseID;

    public int OrderID
    {
        get
        {
            return m_OrderID;
        }

        set
        {
            m_OrderID = value;
        }
    }

    public int DeliveryID
    {
        get
        {
            return m_DeliveryID;
        }

        set
        {
            m_DeliveryID = value;
        }
    }

    public int PaperTypeID
    {
        get
        {
            return m_PaperTypeID;
        }

        set
        {
            m_PaperTypeID = value;
        }
    }

    public int MerchandiseID
    {
        get
        {
            return m_MerchandiseID;
        }

        set
        {
            m_MerchandiseID = value;
        }
    }
}