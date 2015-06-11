using System;
using Telerik.Web.UI;

/// <summary>
/// Summary description for PhotoAsyncUploadResult
/// </summary>
public class PhotoAsyncUploadResult : AsyncUploadResult
{
    private int m_OrderID = 0;

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
}