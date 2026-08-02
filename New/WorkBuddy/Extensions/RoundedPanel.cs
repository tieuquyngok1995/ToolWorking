using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WorkBuddy.Extensions;

public class RoundedPanel : Panel
{
    //Fields
    private int borderSize = 0;
    private int borderRadius = 20;
    private Color borderColor = Color.PaleVioletRed;
    private bool roundTopLeft = true;
    private bool roundTopRight = true;
    private bool roundBottomLeft = true;
    private bool roundBottomRight = true;

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
            Invalidate();
        }
    }

    [Category("Appearance")]
    public bool RoundTopLeft
    {
        get { return roundTopLeft; }
        set { roundTopLeft = value; Invalidate(); }
    }

    [Category("Appearance")]
    public bool RoundTopRight
    {
        get { return roundTopRight; }
        set { roundTopRight = value; Invalidate(); }
    }

    [Category("Appearance")]
    public bool RoundBottomLeft
    {
        get { return roundBottomLeft; }
        set { roundBottomLeft = value; Invalidate(); }
    }

    [Category("Appearance")]
    public bool RoundBottomRight
    {
        get { return roundBottomRight; }
        set { roundBottomRight = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color BackgroundColor
    {
        get { return BackColor; }
        set { BackColor = value; }
    }

    //Constructor
    public RoundedPanel()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.ResizeRedraw |
                  ControlStyles.OptimizedDoubleBuffer, true);
        DoubleBuffered = true;
        BackColor = Color.MediumSlateBlue;
        Resize += new EventHandler(Panel_Resize);
    }

    private void Panel_Resize(object sender, EventArgs e)
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

        //Top-left
        if (roundTopLeft)
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        else
            path.AddLine(rect.X, rect.Y, rect.X, rect.Y);

        //Top-right
        if (roundTopRight)
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        else
            path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);

        //Bottom-right
        if (roundBottomRight)
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        else
            path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);

        //Bottom-left
        if (roundBottomLeft)
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        else
            path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);

        path.CloseFigure();
        return path;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Rectangle rectSurface = ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
        int smoothSize = 2;
        if (borderSize > 0)
            smoothSize = borderSize;

        if (borderRadius > 2) //Rounded panel
        {
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
            using (Pen penSurface = new Pen(Parent != null ? Parent.BackColor : BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //Panel surface
                Region = new Region(pathSurface);
                //Draw surface border for HD result
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                //Panel border
                if (borderSize >= 1)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
        else //Normal panel
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.None;
            //Panel surface
            Region = new Region(rectSurface);
            //Panel border
            if (borderSize >= 1)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                }
            }
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        if (Parent != null)
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