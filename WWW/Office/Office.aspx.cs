using System;
using System.Web;

public partial class Office : ProjectPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (SiteMapProvider mapProvider in SiteMap.Providers)
        {
            if (mapProvider.ResourceKey == "Office.sitemap")
            {
                mapProvider.SiteMapResolve += new SiteMapResolveEventHandler(ExpandAdminURLPaths);
            }
        }

    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    private SiteMapNode ExpandAdminURLPaths(Object sender, SiteMapResolveEventArgs e)
    {
        try
        {
            SiteMapNode currentNode = GetCurrentNode(e.Provider.RootNode);
            return currentNode;
        }
        catch { }
        return null;
    }

    private SiteMapNode GetCurrentNode(SiteMapNode node)
    {
        foreach (SiteMapNode childNode in node.ChildNodes)
        {
            foreach (SiteMapNode childNode1 in childNode.ChildNodes)
            {
                if (childNode1.Url.IndexOf(this.ContentControlName) != -1)
                {
                    return childNode1;
                }
                foreach (SiteMapNode childNode2 in childNode1.ChildNodes)
                {
                    if (childNode2.Url.IndexOf(this.ContentControlName) != -1)
                    {
                        return childNode2;
                    }
                }
            }
        }
        return null;
    }
}
