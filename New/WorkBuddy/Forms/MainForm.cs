using Sunny.UI;
using System.Reflection;
using System.Runtime.InteropServices;
using static WorkBuddy.Helpers.UIHelper;

namespace WorkBuddy.Forms;

public partial class MainForm : UIForm
{
    // Dll
    [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.DLL", EntryPoint = "SendMessage")]
    private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

    private UIButton? _activeButton;
    private UserControl? _currentControl;

    public MainForm()
    {
        InitializeComponent();
    }

    #region Event

    private void MainForm_Load(object sender, EventArgs e)
    {
        lblVersion.Text = $"Version {GetCurrentVersion()}";
    }

    /// <summary>
    /// Event mouse move form
    /// </summary>
    private void pctLogo_MouseMove(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, 0x112, 0xf012, 0);
    }

    /// <summary>
    /// Event mouse move form
    /// </summary>
    private void panelTop_MouseMove(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, 0x112, 0xf012, 0);
    }


    /// <summary>
    /// Event minimize form
    /// </summary>
    private void btMinimize_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    /// <summary>
    /// Event close form
    /// </summary>
    private void btnClose_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    #endregion


    #region Setting layout
    /// <summary>
    /// Handles the Click event of the MenuButton control.
    /// </summary>
    /// <param name="sender">The source of the event, typically the menu button.</param>
    /// <param name="e">An <see cref="EventArgs"/> containing the event data.</param>
    private void MenuButton_Click(object? sender, EventArgs e)
    {
        if (sender is not Control { Tag: string controlName }) return;

        Type? type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == controlName);

        if (type == null || Activator.CreateInstance(type) is not UserControl control) return;

        OpenChildUserControl(control);
        SetActive((UIButton)sender);
    }

    /// <summary>
    /// Opens and displays a child <see cref="UserControl"/> inside the container view.
    /// </summary>
    /// <param name="control">The child <see cref="UserControl"/> to be displayed.</param>
    private void OpenChildUserControl(UserControl control)
    {
        _currentControl?.Dispose();
        uiUserControl.Controls.Clear();

        _currentControl = control;
        uiUserControl.Controls.Add(_currentControl);
    }

    /// <summary>
    /// Setting panel color
    /// </summary>
    private void SetActive(UIButton button)
    {
        if (_activeButton == button)
            return;

        var (bColor, fColor) = ColorHelper.CreateColorPair();

        // Deactivate old button
        foreach (Control control in panelCenterLeft.Controls)
        {
            if (control is UIButton _deactiveButton)
            {
                _deactiveButton.FillColor = bColor;
                _deactiveButton.FillHoverColor = Color.White;
                _deactiveButton.RectColor = bColor;
                _deactiveButton.RectHoverColor = Color.White;
                _deactiveButton.RectPressColor = bColor;
                _deactiveButton.RectSelectedColor = bColor;
                _deactiveButton.ForeColor = fColor;
            }
        }

        // Set colot to active button
        _activeButton = button;
        _activeButton.FillColor = Color.White;
        _activeButton.FillHoverColor = Color.White;
        _activeButton.RectColor = Color.White;
        _activeButton.RectHoverColor = Color.White;
        _activeButton.RectPressColor = Color.White;
        _activeButton.RectSelectedColor = Color.White;
        _activeButton.ForeColor = Color.Black;

        // Set color header button
        if (fColor == Color.Black)
        {
            btnClose.BackgroundImage = Properties.Resources.Icon_Close_Black;
            btMinimize.BackgroundImage = Properties.Resources.Icon_Minimize_Black;
        }
        else
        {
            btnClose.BackgroundImage = Properties.Resources.icon_Close_Write;
            btMinimize.BackgroundImage = Properties.Resources.Icon_Minimize_Write;
        }

        // Set location button border
        panelRoundedTopCorners.Top = _activeButton.Top - 20;
        panelRoundedBotCorners.Top = _activeButton.Top + 35;

        lblVersion.ForeColor = fColor;

        // Set colot to panel
        panelTop.BackColor = bColor;
        panelCenterLeft.BackColor = bColor;
        panelCenterMain.BackColor = bColor;
        panelCenterRight.BackColor = bColor;
        panelBottom.BackColor = bColor;
    }

    /// <summary>
    /// Get the current version of the app.
    /// </summary>
    /// <returns></returns>
    private static string GetCurrentVersion()
    {
        var version = Assembly.GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        return version?.Split('+')[0] ?? "0.0.0";
    }
    #endregion
}