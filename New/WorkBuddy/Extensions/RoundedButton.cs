using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WorkBuddy.Extensions;

public class RoundedButton : Button
{
    //Fields
    private int borderSize = 0;
    private int borderRadius = 20;
    private Color borderColor = Color.PaleVioletRed;
    private Image? customImage;

    // Hover fields
    private bool enableHoverEffect = true;
    private Color hoverBackColor = Color.SlateBlue;
    private Color hoverTextColor = Color.White;
    private Color hoverBorderColor = Color.PaleVioletRed;
    private Color originalBackColor;
    private Color originalTextColor;
    private Color originalBorderColor;
    private bool isHovering = false;

    //Properties
    [Category("Appearance")]
    public int BorderSize
    {
        get { return borderSize; }
        set
        {
            borderSize = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public int BorderRadius
    {
        get { return borderRadius; }
        set
        {
            borderRadius = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color BorderColor
    {
        get { return borderColor; }
        set
        {
            borderColor = value;
            originalBorderColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color BackgroundColor
    {
        get { return BackColor; }
        set
        {
            BackColor = value;
            originalBackColor = value;
        }
    }

    [Category("Appearance")]
    public Color TextColor
    {
        get { return ForeColor; }
        set
        {
            ForeColor = value;
            originalTextColor = value;
        }
    }

    [Category("Appearance")]
    public new Image? Image
    {
        get { return customImage; }
        set
        {
            customImage = value;
            Invalidate();
        }
    }

    // --- Hover properties ---
    [Category("Hover")]
    public bool EnableHoverEffect
    {
        get { return enableHoverEffect; }
        set { enableHoverEffect = value; }
    }

    [Category("Hover")]
    public Color HoverBackColor
    {
        get { return hoverBackColor; }
        set { hoverBackColor = value; }
    }

    [Category("Hover")]
    public Color HoverTextColor
    {
        get { return hoverTextColor; }
        set { hoverTextColor = value; }
    }

    [Category("Hover")]
    public Color HoverBorderColor
    {
        get { return hoverBorderColor; }
        set { hoverBorderColor = value; }
    }

    //Constructor
    public RoundedButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Size = new Size(150, 40);
        BackColor = Color.MediumSlateBlue;
        ForeColor = Color.White;
        Resize += new EventHandler(Button_Resize);

        originalBackColor = BackColor;
        originalTextColor = ForeColor;
        originalBorderColor = borderColor;

        MouseEnter += new EventHandler(RoundedButton_MouseEnter);
        MouseLeave += new EventHandler(RoundedButton_MouseLeave);
    }

    private void RoundedButton_MouseEnter(object? sender, EventArgs e)
    {
        isHovering = true;

        if (!enableHoverEffect)
            return;

        BackColor = hoverBackColor;
        ForeColor = hoverTextColor;
        borderColor = hoverBorderColor;
        Invalidate();
    }

    private void RoundedButton_MouseLeave(object? sender, EventArgs e)
    {
        isHovering = false;

        if (!enableHoverEffect)
            return;

        BackColor = originalBackColor;
        ForeColor = originalTextColor;
        borderColor = originalBorderColor;
        Invalidate();
    }

    private void Button_Resize(object sender, EventArgs e)
    {
        if (borderRadius > Height)
            borderRadius = Height;
    }

    //Methods
    private GraphicsPath GetFigurePath(Rectangle rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        float curveSize = radius * 2F;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        path.CloseFigure();
        return path;
    }

    protected override void OnPaintBackground(PaintEventArgs pevent) { }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Rectangle rectSurface = ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
        int smoothSize = 2;
        if (borderSize > 0)
            smoothSize = borderSize;

        if (borderRadius > 2) //Rounded button
        {
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
            using (Pen penSurface = new Pen(Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //Button surface
                Region = new Region(pathSurface);
                //Draw surface border for HD result
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                //Button border                    
                if (borderSize >= 1)
                    //Draw control border
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
        else //Normal button
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.None;
            //Button surface
            Region = new Region(rectSurface);
            //Button border
            if (borderSize >= 1)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                }
            }
        }

        if (customImage != null)
        {
            pevent.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pevent.Graphics.DrawImage(customImage, ClientRectangle);
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    private void Container_BackColorChanged(object sender, EventArgs e)
    {
        Invalidate();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        ResumeLayout(false);

    }
}