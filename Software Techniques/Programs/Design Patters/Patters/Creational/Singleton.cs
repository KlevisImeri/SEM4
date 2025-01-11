//Problem:  You only want one instance (object) of the specified class 
//          and you want everyont to only use that (aka global point for access)
// Requrers programing lanuage support why? (Can you do it for structures?)


class Singleton {
  static private Singleton? instance;
  static private readonly object lock_ = new object();
  static public Singleton Instance { get {
    if(instance == null) {
      lock (lock_)  {
        if(instance == null) {
          instance = new Singleton();
        }
      }
    }
    return instance;
  }}

  protected Singleton() {}
}
  
// //If the constroctor is private there can not be any derived classes
// class PrivateConstructor {
//   private PrivateConstructor() {}
// }
// class Derived: PrivateConstructor { //Can't create this class
//   public Derived() {} 
// }