//Problem: I don't want to implemetn the whole method/algortithm. Just the skeleton structure.
//         Aand also want flexibity in the implentation. DO it in diff ways
//Solution: Leave the implemtntion to the dervied classes
//Good for frameworks becaue:
//  - you need base classes that have template methods





abstract class AbstractClass {
  public void TemplateMethod() {
    //...
    PrimitiveOperation1();
    //...
    PrimitiveOperation2();
    //...
  }
  abstract protected void PrimitiveOperation1();
  abstract protected void PrimitiveOperation2(); //Can return other stuf
}
class ContcreteClass : AbstractClass {
  protected override void PrimitiveOperation1() { }
  protected override void PrimitiveOperation2() { }
}

