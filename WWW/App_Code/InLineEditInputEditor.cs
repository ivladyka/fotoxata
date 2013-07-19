using System.Drawing;
using Telerik.WebControls;

/// <summary>
/// Summary description for InLineEditInputEditor
/// </summary>
public class InLineEditInputEditor : Telerik.WebControls.GridTextColumnEditor//GridTextBoxColumnEditor
{
    private RadNumericTextBox _numTextBox;
    private string m_OnClientValueChanged = "";

    protected override void CreateControls()
    {
        _numTextBox = new RadNumericTextBox();
        //_numTextBox.DataType = typeof(int);
        _numTextBox.NumberFormat.DecimalDigits = 0;
        _numTextBox.NumberFormat.DecimalSeparator = "!";
        _numTextBox.MinValue = 1;
        _numTextBox.Width = 60;
        _numTextBox.ShowSpinButtons = true;
        _numTextBox.ID = "numTextBox";
        _numTextBox.Skin = "Default";
        _numTextBox.BackColor = Color.White;
        _numTextBox.ClientEvents.OnValueChanged = m_OnClientValueChanged;
    }

    public RadNumericTextBox numTextBox
    {
        get
        {
            this.EnsureControlsCreated();
            return this._numTextBox;
        }
    }

    public override string Text
    {
        get
        {
            if (_numTextBox.Value == null)
            {
                return "1";
            }
            return _numTextBox.Value.ToString();
        }
        set
        {
            _numTextBox.Value = double.Parse(value);
        }
    }

    protected override void AddControlsToContainer()
    {
        this.EnsureControlsCreated();

        this.ContainerControl.Controls.Add(_numTextBox);
    }

    protected override void LoadControlsFromContainer()
    {
        this._numTextBox = (RadNumericTextBox)this.ContainerControl.Controls[0];
    }

    public string OnClientValueChanged
    {
        set
        {
            m_OnClientValueChanged = value;
        }
    }
}
