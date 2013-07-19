using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class TopMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utils.InitTopMenu(mnTop);
        foreach (SiteMapProvider mapProvider in SiteMap.Providers)
        {
            if (mapProvider.ResourceKey == "TopMenu.sitemap")
            {
                foreach (SiteMapNode node in mapProvider.RootNode.ChildNodes)
                {
                    SetRecursiveSiteMapNode(node);
                }
            }
        }
    }

    private void SetRecursiveSiteMapNode(SiteMapNode node)
    {
        string title = GetMenuTitle(node.Url);
        if (title != "")
        {
            node.ReadOnly = false;
            node.Title = title;
        }
        foreach (SiteMapNode nodeChild in node.ChildNodes)
        {
            SetRecursiveSiteMapNode(nodeChild);
        }
    }

    private string GetMenuTitle(string url)
    {
        foreach (MenuItem item in mnTop.Items)
        {
            string title = RecursiveGetMenuTitle(item, url);
            if (title != "")
            {
                return title;
            }
        }
        return "";
    }

    private string RecursiveGetMenuTitle(MenuItem item, string url)
    {
        if (GetURLQuery(item.NavigateUrl) == GetURLQuery(url))
        {
            return item.Text;
        }
        foreach (MenuItem itemChild in item.ChildItems)
        {
            string title = RecursiveGetMenuTitle(itemChild, url);
            if (title != "")
            {
                return title;
            }
        }
        return "";
    }

    private string GetURLQuery(string url)
    {
        if (url.IndexOf(".aspx") > 0)
        {
            return url.Substring(url.IndexOf(".aspx"));
        }
        return url;
    }
}
