//Problem:  You wan't to be able to create several objects wihthout specifying their concreate classes
//          This objects/products belong to different product families.
//Example:  GUI (dark or white mode). The WhiteModeAbstractFactory gives you objects/constrols of 
//          white mode while The DarkModeAbstractFactory gives you objects/controls of dark mode

abstract class AbstractProductA { }
class ProductA1 : AbstractProductA { }
class ProductA2 : AbstractProductA { }

abstract class AbstractProductB { }
class ProductB1 : AbstractProductB { }
class ProductB2 : AbstractProductB { }


abstract class AbstractFactory {
  abstract public AbstractProductA CreateProductA();
  abstract public AbstractProductB CreateProductB();
}
class ConcreteFactory1 : AbstractFactory {
  override public AbstractProductA CreateProductA(){
    return new ProductA1();
  }
  override public AbstractProductB CreateProductB() {
    return new ProductB1();
  }
}
class ConcreteFactory2 : AbstractFactory {
  public override AbstractProductA CreateProductA() {
    return new ProductA2();
  }
  public override AbstractProductB CreateProductB() {
    return new ProductB2();
  }
}

class Client {
  private AbstractProductA ProductA;
  private AbstractProductB ProductB;

  public Client(AbstractFactory factory) {
    ProductA = factory.CreateProductA();
    ProductB = factory.CreateProductB();
  }
  public void Run() { //... Let product a interact with product b
    Console.WriteLine( 
      $"{ProductA.GetType().Name} <-> {ProductB.GetType().Name}"
    );
  }
}

// class Example {
//   static void Main() {
//     Client client1 = new Client(new ConcreteFactory1());
//     client1.Run();
//     Client client2 = new Client(new ConcreteFactory2());
//     client2.Run();
//   }
// }