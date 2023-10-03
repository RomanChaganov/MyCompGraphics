using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Program : Form
{
    private int width = 170;

    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private TextBox beginX;
    private TextBox beginY;
    private TextBox endX;
    private TextBox endY;
    private TextBox widthText;
    private Button startButton;
    private Button drawLineButton;
    private Button hideLineButton;
    private Button clearButton;
    private PictureBox drawArea;
    private Button drawEllipseButton;
    private Button hideEllipseButton;
    private TextBox pointTextBox;
    private Button pointAddButton;
    private ListBox pointsListBox;
    private Button drawPolygonButton;
    private Button hidePolygonButton;
    private RadioButton polygonRadioButton1;
    private RadioButton polygonRadioButton2;

    Graphics g;
    Line line;
    Ellipse ellipse;
    Polygon polygon;

    List<Point> points;

    private Program()
    {
        points = new List<Point>();

        this.Text = "Компьютерная графика";
        this.Size = new Size(900, 500);

        Icon icon = new Icon("icon.ico");
        this.Icon = icon;

        this.Resize += new EventHandler(Program_Resize);
        this.MaximumSize = new Size(1100, 550);

        startButton = new Button();
        startButton.Text = "Начать";

        beginX = new TextBox();
        beginX.Location = new Point(10, 20);
        beginX.Size = startButton.Size;

        beginY = new TextBox();
        beginY.Location = new Point(5 + beginX.Size.Width + beginX.Location.X, beginX.Location.Y);
        beginY.Size = startButton.Size;

        endX = new TextBox();
        endX.Location = new Point(beginX.Location.X, 5 + beginX.Size.Height + beginX.Location.Y);
        endX.Size = startButton.Size;

        endY = new TextBox();
        endY.Location = new Point(beginY.Location.X, endX.Location.Y);
        endY.Size = startButton.Size;

        widthText = new TextBox();
        widthText.Location = new Point((int)((beginY.Location.X + beginY.Size.Width) / 2.0f - startButton.Size.Width / 2.0f), 5 + endX.Size.Height + endX.Location.Y);
        widthText.Size = startButton.Size;

        startButton.Location = new Point(endX.Location.X, 5 + widthText.Size.Height + widthText.Location.Y);
        startButton.Click += new EventHandler(startButton_Click);

        drawLineButton = new Button();
        drawLineButton.Text = "Линия";
        drawLineButton.Location = new Point(beginY.Location.X, startButton.Location.Y);
        drawLineButton.Click += new EventHandler(drawLineButton_Click);

        hideLineButton = new Button();
        hideLineButton.Text = "Скрыть";
        hideLineButton.Location = new Point(startButton.Location.X, 5 + startButton.Size.Height + startButton.Location.Y);
        hideLineButton.Click += new EventHandler(hideLineButton_Click);

        clearButton = new Button();
        clearButton.Text = "Очистить";
        clearButton.Location = new Point(beginY.Location.X, hideLineButton.Location.Y);
        clearButton.Click += new EventHandler(clearButton_Click);

        drawEllipseButton = new Button();
        drawEllipseButton.Text = "Эллипс";
        drawEllipseButton.Location = new Point(startButton.Location.X, 5 + hideLineButton.Size.Height + hideLineButton.Location.Y);
        drawEllipseButton.Click += new EventHandler(drawEllipseButton_Click);

        hideEllipseButton = new Button();
        hideEllipseButton.Text = "Стер. Элл";
        hideEllipseButton.Location = new Point(beginY.Location.X, drawEllipseButton.Location.Y);
        hideEllipseButton.Click += new EventHandler(hideEllipseButton_Click);

        pointTextBox = new TextBox();
        pointTextBox.Location = new Point(startButton.Location.X, 30 + drawEllipseButton.Size.Height + drawEllipseButton.Location.Y);
        pointTextBox.Size = startButton.Size;

        pointAddButton = new Button();
        pointAddButton.Text = "Добавить";
        pointAddButton.Location = new Point(startButton.Location.X, 5 + pointTextBox.Size.Height + pointTextBox.Location.Y);
        pointAddButton.Click += new EventHandler(pointAddButton_Click);

        polygonRadioButton1 = new RadioButton();
        polygonRadioButton1.Text = "Непр. Мног";
        polygonRadioButton1.Location = new Point(startButton.Location.X, 5 + pointAddButton.Size.Height + pointAddButton.Location.Y);

        polygonRadioButton2 = new RadioButton();
        polygonRadioButton2.Text = "Прав. Мног";
        polygonRadioButton2.Location = new Point(startButton.Location.X, polygonRadioButton1.Size.Height + polygonRadioButton1.Location.Y);

        drawPolygonButton = new Button();
        drawPolygonButton.Text = "Полигон";
        drawPolygonButton.Location = new Point(startButton.Location.X, 7 + polygonRadioButton2.Size.Height + polygonRadioButton2.Location.Y);
        drawPolygonButton.Click += new EventHandler(drawPolygonButton_Click);

        hidePolygonButton = new Button();
        hidePolygonButton.Text = "Стер. Пол";
        hidePolygonButton.Location = new Point(startButton.Location.X, 5 + drawPolygonButton.Size.Height + drawPolygonButton.Location.Y);
        hidePolygonButton.Click += new EventHandler(hidePolygonButton_Click);

        pointsListBox = new ListBox();
        pointsListBox.Location = new Point(beginY.Location.X, pointTextBox.Location.Y);
        pointsListBox.Size = new Size(startButton.Size.Width, 160);

        groupBox1 = new GroupBox();
        groupBox1.Text = "Управление";
        groupBox1.Location = new Point(10, 10);
        width = drawLineButton.Location.X + drawLineButton.Size.Width + 10;
        groupBox1.Size = new Size(width, this.ClientSize.Height - 20);
        groupBox1.Controls.Add(beginX);
        groupBox1.Controls.Add(beginY);
        groupBox1.Controls.Add(endX);
        groupBox1.Controls.Add(endY);
        groupBox1.Controls.Add(widthText);
        groupBox1.Controls.Add(startButton);
        groupBox1.Controls.Add(drawLineButton);
        groupBox1.Controls.Add(hideLineButton);
        groupBox1.Controls.Add(clearButton);
        groupBox1.Controls.Add(drawEllipseButton);
        groupBox1.Controls.Add(hideEllipseButton);
        groupBox1.Controls.Add(pointTextBox);
        groupBox1.Controls.Add(pointAddButton);
        groupBox1.Controls.Add(pointsListBox);
        groupBox1.Controls.Add(drawPolygonButton);
        groupBox1.Controls.Add(hidePolygonButton);
        groupBox1.Controls.Add(polygonRadioButton1);
        groupBox1.Controls.Add(polygonRadioButton2);

        groupBox2 = new GroupBox();
        groupBox2.Text = "Графика";
        groupBox2.Location = new Point(groupBox1.Location.X + groupBox1.Size.Width + 10, groupBox1.Location.Y);
        groupBox2.Size = new Size(this.ClientSize.Width - groupBox2.Location.X - 10, groupBox1.Size.Height);

        drawArea = new PictureBox();
        drawArea.BorderStyle = BorderStyle.FixedSingle;
        drawArea.Location = new Point(10, 20);
        drawArea.Size = new Size(groupBox2.Size.Width - 20, groupBox2.Size.Height - 30);

        groupBox2.Controls.Add(drawArea);

        this.Controls.Add(groupBox1);
        this.Controls.Add(groupBox2);
    }

    private bool isDigit(string line)
    {
        int n;
        return int.TryParse(line, out n);
    }

    private void Program_Resize(object sender, EventArgs e)
    {
        groupBox1.Size = new Size(width, this.ClientSize.Height - 20);
        groupBox2.Size = new Size(this.ClientSize.Width - groupBox2.Location.X - 10, groupBox1.Size.Height);
        drawArea.Size = new Size(groupBox2.Size.Width - 20, groupBox2.Size.Height - 30);
    }

    private void startButton_Click(object sender, EventArgs e)
    {
        g = drawArea.CreateGraphics();
        startButton.Enabled = false;
    }

    private void drawLineButton_Click(object sender, EventArgs e)
    {
        if (g == null) return;

        int x1, y1, x2, y2, width;
        x1 = y1= x2 = y2 = width = 0;

        // Console.WriteLine(isDigit(beginX.Text));

        if (isDigit(beginX.Text)) x1 = int.Parse(beginX.Text);
        else return;
        if (isDigit(beginY.Text)) y1 = int.Parse(beginY.Text);
        else return;
        if (isDigit(endX.Text)) x2 = int.Parse(endX.Text);
        else return;
        if (isDigit(endY.Text)) y2 = int.Parse(endY.Text);
        else return;
        if (isDigit(widthText.Text)) width = int.Parse(widthText.Text);
        else return;

        line = new Line(g);
        line.Draw(Color.Red, width, new Point(x1, y1), new Point(x2, y2));
    }

    private void hideLineButton_Click(object sender, EventArgs e)
    {
        if (line != null) line.Hide(drawArea.BackColor);
    }

    private void clearButton_Click(object sender, EventArgs e)
    {
        if (g != null) g.Clear(drawArea.BackColor);
    }

    private void drawEllipseButton_Click(object sender, EventArgs e)
    {
        if (g == null) return;

        int x, y, width, height, width_border;
        x = y = width = height = width_border = 0;

        if (isDigit(beginX.Text)) x = int.Parse(beginX.Text);
        else return;
        if (isDigit(beginY.Text)) y = int.Parse(beginY.Text);
        else return;
        if (isDigit(endX.Text)) width = int.Parse(endX.Text);
        else return;
        if (isDigit(endY.Text)) height = int.Parse(endY.Text);
        else return;
        if (isDigit(widthText.Text)) width_border = int.Parse(widthText.Text);
        else return;

        ellipse = new Ellipse(g);
        ellipse.Draw(Color.Black, Color.Red, width_border, new Rectangle(x, y, width, height), "Эллипс");
    }

    private void hideEllipseButton_Click(object sender, EventArgs e)
    {
        if (ellipse != null) ellipse.Hide(drawArea.BackColor);
    }

    private void pointAddButton_Click(object sender, EventArgs e)
    {
        int x, y;
        string[] point = pointTextBox.Text.Split();
        if (point.Length != 2) return;
        if (isDigit(point[0])) x = int.Parse(point[0]);
        else return;
        if (isDigit(point[1])) y = int.Parse(point[1]);
        else return;

        points.Add(new Point(x, y));
        pointsListBox.Items.Add(pointTextBox.Text);
    }

    private void drawPolygonButton_Click(object sender, EventArgs e)
    {
        if (g == null) return;

        int width_border = 0;

        if (isDigit(widthText.Text)) width_border = int.Parse(widthText.Text);
        else return;

        polygon = new Polygon(g);

        if (polygonRadioButton1.Checked || !polygonRadioButton2.Checked)
        {
            if (points.Count == 0) return;
            polygon.Draw(Color.Black, width_border, points.ToArray());
        } 
        else
        {
            int x = 0;
            int y = 0;
            int radius = 0;
            int n = 0;
            if (isDigit(beginX.Text)) x = int.Parse(beginX.Text);
            else return;
            if (isDigit(beginY.Text)) y = int.Parse(beginY.Text);
            else return;
            if (isDigit(endX.Text)) radius = int.Parse(endX.Text);
            else return;
            if (isDigit(endY.Text)) n = int.Parse(endY.Text);
            else return;
            polygon.DrawRegular(Color.Black, width_border, x, y, radius, n);
        }
    }

    private void hidePolygonButton_Click(object sender, EventArgs e)
    {
        if (polygon != null) polygon.Hide(drawArea.BackColor);
    }

    private static void Main()
    {
        Application.Run(new Program());
    }
}