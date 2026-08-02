using System.Drawing;
using System.Windows.Forms;

namespace WinFormSunnyUIDemo.UserControls
{
    /// <summary>Màn hình con: Home</summary>
    public class UcHome : UserControl
    {
        public UcHome()
        {
            Dock = DockStyle.Fill;
            var title = new Label
            {
                Text = "Trang chủ (Home)",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 30)
            };
            Controls.Add(title);

            // TODO: thêm nội dung thực tế của màn hình Home tại đây
        }

        private void InitializeComponent()
        {

        }
    }
}
