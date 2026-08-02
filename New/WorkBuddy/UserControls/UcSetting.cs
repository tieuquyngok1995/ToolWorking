namespace WorkBuddy.UserControls;

/// <summary>Màn hình con: Setting</summary>
public class UcSetting : UserControl
{
    public UcSetting()
    {
        Dock = DockStyle.Fill;
        var titleLbl = new Label
        {
            Text = "Màn hình Setting",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(30, 30)
        };
        Controls.Add(titleLbl);

        // TODO: thêm nội dung thực tế của màn hình Setting tại đây
    }
}
