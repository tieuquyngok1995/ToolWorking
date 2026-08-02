using System.Drawing;
using System.Windows.Forms;

namespace WinFormSunnyUIDemo.UserControls
{
    /// <summary>Màn hình con: Excel</summary>
    public class UcExcel : UserControl
    {
        public UcExcel()
        {
            Dock = DockStyle.Fill;
            var titleLbl = new Label
            {
                Text = "Màn hình Excel",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 30)
            };
            Controls.Add(titleLbl);

            // TODO: thêm nội dung thực tế của màn hình Excel tại đây
        }
    }
}
