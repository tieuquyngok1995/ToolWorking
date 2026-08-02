namespace WorkBuddy.UserControls;

/// <summary>Màn hình con: Excel</summary>
public class UcJSON : UserControl
{
    public UcJSON()
    {
        Dock = DockStyle.Fill;
        var titleLbl = new Label
        {
            Text = "Màn hình JSON",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(30, 30)
        };
        Controls.Add(titleLbl);

        // TODO: thêm nội dung thực tế của màn hình Excel tại đây
    }
}
