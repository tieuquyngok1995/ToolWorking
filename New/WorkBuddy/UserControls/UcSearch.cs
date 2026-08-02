namespace WorkBuddy.UserControls;

/// <summary>Màn hình con: API</summary>
public class UcSearch : UserControl
{
    public UcSearch()
    {
        Dock = DockStyle.Fill;
        var titleLbl = new Label
        {
            Text = "Màn hình Search",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(30, 30)
        };
        Controls.Add(titleLbl);

        // TODO: thêm nội dung thực tế của màn hình API tại đây
    }
}
