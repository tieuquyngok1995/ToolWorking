using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WorkBuddy.Extensions;

public enum CornerStyle
{
    Square,
    Round,
    Inverted
}

public class InvertedCornerPanel : Panel
{
    //Fields
    private int borderSize = 0;
    private int cornerRadius = 30;
    private Color borderColor = Color.PaleVioletRed;

    private CornerStyle topLeft = CornerStyle.Square;
    private CornerStyle topRight = CornerStyle.Square;
    private CornerStyle bottomLeft = CornerStyle.Square;
    private CornerStyle bottomRight = CornerStyle.Inverted;

    //Properties
    [Category("Appearance")]
    public int BorderSize
    {
        get { return borderSize; }
        set { borderSize = value; Invalidate(); }
    }

    [Category("Appearance")]
    public int CornerRadius
    {
        get { return cornerRadius; }
        set { cornerRadius = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    public CornerStyle TopLeftStyle
    {
        get { return topLeft; }
        set { topLeft = value; Invalidate(); }
    }

    [Category("Appearance")]
    public CornerStyle TopRightStyle
    {
        get { return topRight; }
        set { topRight = value; Invalidate(); }
    }

    [Category("Appearance")]
    public CornerStyle BottomLeftStyle
    {
        get { return bottomLeft; }
        set { bottomLeft = value; Invalidate(); }
    }

    [Category("Appearance")]
    public CornerStyle BottomRightStyle
    {
        get { return bottomRight; }
        set { bottomRight = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color BackgroundColor
    {
        get { return BackColor; }
        set { BackColor = value; }
    }

    //Constructor
    public InvertedCornerPanel()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.ResizeRedraw |
                  ControlStyles.OptimizedDoubleBuffer, true);
        DoubleBuffered = true;
        BackColor = Color.DeepSkyBlue;
        Resize += new EventHandler(Panel_Resize);
    }

    private void Panel_Resize(object sender, EventArgs e)
    {
        if (cornerRadius > Height) cornerRadius = Height;
        if (cornerRadius > Width) cornerRadius = Width;
    }

    //Methods
    private GraphicsPath GetFigurePath(Rectangle rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        float d = radius * 2F;

        path.StartFigure();

        // ---- Top-left ----
        AddCorner(path, topLeft, rect.X, rect.Y, d, radius,
            convexStart: 180, concaveStart: 90,
            sharpPoint: new PointF(rect.X, rect.Y));

        // Top
        path.AddLine(
            topLeft == CornerStyle.Square ? rect.X : rect.X + radius, rect.Y,
            topRight == CornerStyle.Square ? rect.Right : rect.Right - radius, rect.Y);

        // ---- Top-right ----
        AddCorner(path, topRight, rect.Right, rect.Y, d, radius,
            convexStart: 270, concaveStart: 180,
            sharpPoint: new PointF(rect.Right, rect.Y));

        // Right
        path.AddLine(
            rect.Right, topRight == CornerStyle.Square ? rect.Y : rect.Y + radius,
            rect.Right, bottomRight == CornerStyle.Square ? rect.Bottom : rect.Bottom - radius);

        // ---- Bottom-right ----
        AddCorner(path, bottomRight, rect.Right, rect.Bottom, d, radius,
            convexStart: 0, concaveStart: 270,
            sharpPoint: new PointF(rect.Right, rect.Bottom));

        // Bottom
        path.AddLine(
            bottomRight == CornerStyle.Square ? rect.Right : rect.Right - radius, rect.Bottom,
            bottomLeft == CornerStyle.Square ? rect.X : rect.X + radius, rect.Bottom);

        // ---- Bottom-left ----
        AddCorner(path, bottomLeft, rect.X, rect.Bottom, d, radius,
            convexStart: 90, concaveStart: 0,
            sharpPoint: new PointF(rect.X, rect.Bottom));

        // Left
        path.AddLine(
            rect.X, bottomLeft == CornerStyle.Square ? rect.Bottom : rect.Bottom - radius,
            rect.X, topLeft == CornerStyle.Square ? rect.Y : rect.Y + radius);

        path.CloseFigure();
        return path;
    }

    private void AddCorner(GraphicsPath path, CornerStyle style,
        float cornerX, float cornerY, float d, float radius,
        float convexStart, float concaveStart, PointF sharpPoint)
    {
        switch (style)
        {
            case CornerStyle.Square:
                break;

            case CornerStyle.Round:
                {
                    float bx = cornerX == 0 ? 0 : cornerX;
                    var box = GetConvexBox(cornerX, cornerY, d, radius, convexStart);
                    path.AddArc(box.X, box.Y, d, d, convexStart, 90);
                }
                break;

            case CornerStyle.Inverted:
                path.AddArc(cornerX - radius, cornerY - radius, d, d, concaveStart, -90);
                break;
        }
    }

    private RectangleF GetConvexBox(float cornerX, float cornerY, float d, float radius, float startAngle)
    {
        float x = startAngle switch
        {
            180 => cornerX,               // Top-left
            270 => cornerX - d,           // Top-right
            0 => cornerX - d,             // Bottom-right
            90 => cornerX,                // Bottom-left
            _ => cornerX
        };
        float y = startAngle switch
        {
            180 => cornerY,               // Top-left
            270 => cornerY,               // Top-right
            0 => cornerY - d,             // Bottom-right
            90 => cornerY - d,            // Bottom-left
            _ => cornerY
        };
        return new RectangleF(x, y, d, d);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Rectangle rectSurface = ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
        int smoothSize = borderSize > 0 ? borderSize : 2;

        using (GraphicsPath pathSurface = GetFigurePath(rectSurface, cornerRadius))
        using (Pen penSurface = new Pen(Parent != null ? Parent.BackColor : BackColor, smoothSize))
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Region = new Region(pathSurface);
            pevent.Graphics.DrawPath(penSurface, pathSurface);

            if (borderSize >= 1)
            {
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, cornerRadius - borderSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
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