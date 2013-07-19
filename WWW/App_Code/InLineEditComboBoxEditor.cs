using System.Drawing;
using System.Web.UI;
using Telerik.WebControls;

/// <summary>
/// Summary description for InLineEditComboBoxEditor
/// </summary>
public class InLineEditComboBoxEditor : GridDropDownColumnEditor
{
    private Telerik.WebControls.RadComboBox combo;
    private string m_ComboID = "combo";
    private string m_OnClientSelectedIndexChanged = "";

    public RadComboBox radDatePicker
    {
        get
        {
            this.EnsureControlsCreated();
            return combo;
        }
    }

    protected override void CreateControls()
    {
        combo = new RadComboBox();
        combo.EnableLoadOnDemand = false;
        combo.ShowToggleImage = true;
        combo.NoWrap = false;
        combo.MarkFirstMatch = true;
        combo.AllowCustomText = false;
        combo.ID = ComboID;
        combo.Width = 105;
        combo.Skin = "Default";
        /*foreach(Control c in combo.Controls)
        {
            c.BackColor = Color.White;
        }*/
        combo.BackColor = Color.White;
        combo.CssClass = "VIKKI_WhiteBackround";
        combo.OnClientSelectedIndexChanged = m_OnClientSelectedIndexChanged;
    }

    protected override void AddControlsToContainer()
    {
        this.EnsureControlsCreated();

        this.ContainerControl.Controls.Add(combo);
        combo.DataMember = this.DataMember;
        combo.DataTextField = this.DataTextField;
        combo.DataValueField = this.DataValueField;
        combo.DataSource = this.DataSource;
        combo.DataBind();
    }

    protected override void LoadControlsFromContainer()
    {
        this.combo = (RadComboBox)this.ContainerControl.Controls[0];
    }

    public override void DataBind()
    {
        combo.DataBind();
    }

    public override int SelectedIndex
    {
        get
        {
            return combo.SelectedIndex;
        }
        set
        {
            int i = 0;
            foreach (RadComboBoxItem rcbi in combo.Items)
            {
                if(i == value)
                {
                    rcbi.Selected = true;
                }
                i++;
            }
        }
    }

    public override string SelectedValue
    {
        get
        {
            if (combo.SelectedItem != null)
            {
                return combo.SelectedItem.Value;
            }
            return "";
        }
        set
        {
            foreach(RadComboBoxItem rcbi in combo.Items)
            {
                if(rcbi.Value == value)
                {
                    rcbi.Selected = true;
                }
            }
        }
    }

    public override string SelectedText
    {
        get
        {
            if (combo.SelectedItem != null)
            {
                return combo.SelectedItem.Text;
            }
            return "";
        }
        set
        {
            foreach(RadComboBoxItem rcbi in combo.Items)
            {
                if(rcbi.Text == value)
                {
                    rcbi.Selected = true;
                }
            }
        }
    }

    public string ComboID
    {
        set
        {
            m_ComboID = value;
        }
        get
        {
            return m_ComboID;
        }
    }

    public string OnClientSelectedIndexChanged
    {
        set
        {
            m_OnClientSelectedIndexChanged = value;
        }
    }
}
