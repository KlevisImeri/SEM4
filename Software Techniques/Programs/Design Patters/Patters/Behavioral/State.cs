//Problem: The state fo the object changes during runtime. And with
//         different states different actions happen


abstract class State {
  abstract public void Handle(Context con); //Contex may be needed
}
class ConcreteStateA : State {
  override public void Handle(Context con) { }
}
class ConcreteStateB : State {
  //The states shoudl change the states
  override public void Handle(Context con) { } 
}

class Context {
  State state;
  public void Request() {
    //...
    state.Handle(this);
    //.. 
  }
}