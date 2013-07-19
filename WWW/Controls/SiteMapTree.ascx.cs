using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SiteMapTree : ControlBase
{
    public SiteMapTree()
	{
        this.m_Name = "";
        AddOnlyBrowserTitle = true;
        m_Name = "Послуги";
	}

    protected override void InitOnFirstLoading()
    {
        
    }

    protected void Page_Prerender(object sender, System.EventArgs e)
    {
        if (Page.Master != null)
        {
            MasterPageBase master = (MasterPageBase)Page.Master;
            if (master.TopMenuItemsCollection != null)
            {
                foreach (MenuItem item in master.TopMenuItemsCollection)
                {
                    TreeNode node = CopyNode(item);
                    RecursiveSetSiteMap(item, node);
                    tvSiteMap.Nodes.Add(node);
                }
            }
        }
    }

    private TreeNode CopyNode(MenuItem item)
    {
        TreeNode node = new TreeNode(item.Text);
        node.ToolTip = item.ToolTip;
        node.NavigateUrl = item.NavigateUrl;
        return node;
    }

    private void RecursiveSetSiteMap(MenuItem item, TreeNode node)
    {
        foreach (MenuItem itemChils in item.ChildItems)
        {
            TreeNode nodeChils = CopyNode(itemChils);
            RecursiveSetSiteMap(itemChils, nodeChils);
            node.ChildNodes.Add(nodeChils);
        }
    }

    private void SetClientOnMouseEvents(string imageName, HtmlImage img)
    {
        string defaultPrefix = "";
        if (Request.Url.PathAndQuery.IndexOf("/Office/") != -1)
        {
            defaultPrefix = "../";
        }
        img.Attributes["onmouseover"] = "VIKKI_PuzzleOnMouseOver(event, '" + defaultPrefix
            + "Images/" + imageName + "2.png');";
        img.Attributes["onmouseout"] = "VIKKI_PuzzleOnMouseOver(event, '" + defaultPrefix
            + "Images/" + imageName + "1.png');";
    }
}