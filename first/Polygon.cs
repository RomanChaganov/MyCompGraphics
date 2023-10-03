using System;
using System.Drawing;

public class Polygon
{
    Graphics ge;
    int width;
    Point[] points;

    int x;
    int y;
    int n;
    int radius;

    public Polygon(Graphics g)
    {
        ge = g;    
    }

    public void Draw(Color color, int width, Point[] points)
    {
        this.width = width;
        this.points = points;
        ge.DrawPolygon(new Pen(color, width), points);
        ge.FillPolygon(Brushes.Red, points);
    }

    public void DrawRegular(Color color, int width, int x, int y, int radius, int n)
    {
        this.x = x;
        this.y = y;
        this.n = n;
        this.radius = radius;
        this.width = width;

        points = new Point[n + 1];
        double z = 0;
        double angle = 360.0 / n;
        for (int i = 0; i < n + 1; i++)
        {
            points[i].X = x + (int)(Math.Round(Math.Cos(z / 180 * Math.PI) * radius));
            points[i].Y = y - (int)(Math.Round(Math.Sin(z / 180 * Math.PI) * radius));
            z = z + angle;
        }

        ge.FillPolygon(Brushes.Red, this.points);
        ge.DrawPolygon(new Pen(color, this.width), this.points);
    }

    public void Hide(Color color)
    {
        ge.DrawPolygon(new Pen(color, this.width), this.points);
        ge.FillPolygon(new SolidBrush(color), this.points);
    }
}