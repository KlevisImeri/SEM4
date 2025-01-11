//Problem:  Treat the leaves (indivisual objects) the same as
//          as composite obejcts.
//          Composes objects into tree structure to represent
//          The part-whole heierchies

abstract class Component {
  protected string name = "";
  public Component(String name) {
    this.name = name;
  }
  abstract public void Operation(int depth); //depth just for fun to look good
  abstract public void Add(Component component);
  abstract public void Remove(Component component);
  abstract public Component GetChild(int index);
}
class Leaf : Component {
  public Leaf(String name) : base(name) { }
  public override void Operation(int depth) {
    Console.WriteLine($"{new String('-', depth)} {name}");
  }
  public override void Add(Component component) {
    throw new NotImplementedException();
  }
  public override void Remove(Component component) {
    throw new NotImplementedException();
  }
  public override Component GetChild(int index) {
    throw new NotImplementedException();
  }
}
class Composite : Component {
  List<Component> children = new List<Component>();

  public Composite(String name) : base(name) { }
  public override void Operation(int depth) {
    Console.WriteLine($"{new String('-', depth)} {name}");
    foreach (Component child in children) {
      child.Operation(depth + 3);
    }
  }
  public override void Add(Component component) {
    children.Add(component);
  }

  public override void Remove(Component component) {
    children.Remove(component);
  }
  public override Component GetChild(int index) => children[index];
}

// class Example {
//   public static void Main() {
//     Composite root = new Composite("root");
//     root.Add(new Leaf("Leaf A"));
//     root.Add(new Leaf("Leaf B"));

//     Composite comp = new Composite("Composite X");
//     comp.Add(new Leaf("Leaf XA"));
//     comp.Add(new Leaf("Leaf XB"));
//     root.Add(comp);

//     root.Add(new Leaf("Leaf C"));

//     Leaf leaf = new Leaf("Leaf D");
//     root.Add(leaf);
//     root.Remove(leaf);


//     root.Operation(1);
//   }
// }