//Problem: The addaptee (objecet we need to use) interface is not the same as
//         the interface that is needed.
// Wrapper = Adapter

abstract class Target { //Client uses this
  abstract public void Request();
}
class Adapter : Target {
  private Addaptee addaptee = new Addaptee();

  public override void Request() {
    addaptee.SpecificRequest();  
  }
}

class Addaptee {
  public void SpecificRequest() { 
    Console.WriteLine("SpecificRequest()");
  }
}

// class Example { 
//   public static void Main() {
//     Target target = new Adapter();
//     target.Request();
//   }
// }