using System;
using System.Drawing;

public class Line
{
    Graphics ge;
    Point pt1;
    Point pt2;
    int width;

    public Line(Graphics g)
    {
        ge = g;
    }

    public void Draw(Color color, int width, Point pt1, Point pt2)
    {
        this.pt1 = new Point(pt1.X, pt1.Y);
        this.pt2 = new Point(pt2.X, pt2.Y);
        this.width = width;
        ge.DrawLine(new Pen(color, width), pt1, pt2);
    }

    public void Hide(Color color)
    {
        ge.DrawLine(new Pen(color, this.width), this.pt1, this.pt2);
    }
}