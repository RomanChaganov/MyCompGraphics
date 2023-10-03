using System;
using System.Drawing;

public class Ellipse
{
    Graphics ge;
    Rectangle rectangle;
    int width;
    Font font;
    string line;

    public Ellipse(Graphics g)
    {
        ge = g;
    }

    public void Draw(Color borderColor, Color color, int width, Rectangle rectangle, string line)
    {
        this.rectangle = rectangle;
        this.width = width;
        this.line = line;
        ge.DrawEllipse(new Pen(borderColor, width), rectangle);
        ge.FillEllipse(new SolidBrush(color), rectangle);
        font = new Font("Arial", 10);
        ge.DrawString(line, font, new SolidBrush(borderColor), rectangle);
    }

    public void Hide(Color color)
    {
        ge.DrawEllipse(new Pen(color, this.width), this.rectangle);
        ge.FillEllipse(new SolidBrush(color), this.rectangle);
        ge.DrawString(this.line, this.font, new SolidBrush(color), this.rectangle);
    }
}