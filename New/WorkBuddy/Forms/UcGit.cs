using System.Drawing;
using System.Windows.Forms;

namespace WinFormSunnyUIDemo.UserControls
{
    /// <summary>Màn hình con: Git</summary>
    public class UcGit : UserControl
    {
        public UcGit()
        {
            Dock = DockStyle.Fill;
            var titleLbl = new Label
            {
                Text = "Màn hình Git",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 30)
            };
            Controls.Add(titleLbl);

            // TODO: thêm nội dung thực tế của màn hình Git tại đây
        }
    }
}
