

namespace Tests;

public class Form2 : Form {
  Random random = new ();
  Rectangle square = new () {
    Size = new Size(4,4),
  };
  Color color = Color.Red;
  System.Windows.Forms.Timer timer = new();

  public Form2() {
    square.Location =  new Point(random.Next(10), random.Next(10));

    KeyPress += (o,e) => {
      if(e.KeyChar == 'D'){
        square.Size *= 2;
        if(square.Size.Height > 400) {
          square.Size = new Size(400,400);
        }
        Invalidate();
      }
    };

    timer.Interval = 1000;
    timer.Tick += (o,e) => {
      if(color == Color.Red) color = Color.Yellow;
      else color = Color.Red;
      Invalidate();
    };
    timer.Start();


    MouseDown += (o,e) => {
      square.Location = e.Location;
      Invalidate();
      MessageBox.Show($"{e.Location}");
    };

  }

  override protected void OnPaint(PaintEventArgs e) {
    e.Graphics.FillRectangle(new SolidBrush(color), square);
  }
}