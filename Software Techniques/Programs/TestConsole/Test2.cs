// using System.Reflection.Metadata.Ecma335;
// using System.Threading;


// class Car {
//   public double speed;
//   public double distace;
//   public Car(double s, double d) {
//     speed = s; distace = d;
//   }
// }

// class Program {
//   static Random rand = new ();
//   static ManualResetEvent start = new(false);
//   static volatile bool finished;

//   static void Main() {

//     Thread car1 = new Thread((car) => Race((Car)car));
//     car1.Start(new Car(0,0)); 
//     Thread car2 = new Thread((car) => Race((Car)car));
//     Thread car3 = new Thread((car) => Race((Car)car));

//     Thread.Sleep(rand.Next(10,500));
//     start.Set();

//     while(tr)

//   }

//   static void Race(Car car) {
//     start.WaitOne();
//     while(true) {
//       lock(car){
//         if(finished == true) break;
//         car.speed += rand.Next(1,2);
//         car.distace += 0.1*car.speed;
//       }
//     }
//   }
// }