//Problem: can't undo the state of the objects. Need to save the state to do so


class Memento {
  public string State { get; init; }
  public Memento(string state) {
    State = state;
  }
  //set
  //get
}

class Originator {
  string state;
  public Memento CreateMemento() => new Memento(state);
  public void SetMemento(Memento memento) { }
}

class CareTaker {
  List<Memento> mementos = new();
  //set
  //get
}
