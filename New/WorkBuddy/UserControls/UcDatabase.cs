namespace WorkBuddy.UserControls;

/// <summary>Màn hình con: Database</summary>
public class UcDatabase : UserControl
{
    public UcDatabase()
    {
        Dock = DockStyle.Fill;
        var titleLbl = new Label
        {
            Text = "Màn hình Database",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(30, 30)
        };
        Controls.Add(titleLbl);

        // TODO: thêm nội dung thực tế của màn hình Database tại đây
    }
}
