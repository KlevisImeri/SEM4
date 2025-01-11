namespace Tests;

public partial class Form1 : Form {
  Queue<Rectangle> squares = new();
  System.Windows.Forms.Timer timer = new();

  public delegate void Func(int x, int y);
  public event Action<int,int> SquareRemoved;

  public Form1() {
    // InitializeComponent();
    BackColor = Color.Blue;
    Size = new Size(1400,1400);

    MouseDown += (o, e) => {
      Rectangle square = new Rectangle(){
        Size = new Size(3,3),
        Location = new Point(e.X, e.Y)
      };
      squares.Enqueue(square);
      Invalidate();
    };

    timer.Interval = 900;
    timer.Tick += (o,e) => {
      if(squares.Count == 0) return;
      var square = squares.Dequeue();
      Invalidate();
      SquareRemoved?.Invoke(square.Location.X, square.Location.Y);
    };
    timer.Start();


    SquareRemoved += (x,y) => {
      Console.WriteLine("Hello Woeld!");
    };
    SquareRemoved += logXY;
  }

  public int NumberOfSquares => squares.Count;


  protected override void OnPaint(PaintEventArgs e) {
    base.OnPaint(e);

    foreach (var square in squares) {
      e.Graphics.FillRectangle(Brushes.Yellow, square);
    }
  }

  private void logXY(int x, int y) {
    Console.WriteLine($"{x} and {y}");
  }

}
