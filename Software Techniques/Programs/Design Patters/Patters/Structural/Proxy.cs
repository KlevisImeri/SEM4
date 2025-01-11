//Problem:  We want tio use the object but we want to do more things with this object
//          We want to CONTROL THE ACCESS to this object.
//Solution: Create another similar object/Proxy(in interface so you can subsittute it for the origanl one)
//          that controls the object/RealSubject

/*
Types: 
  - Remote Proxy : Encapsulates a remote object. 
                   Our proxy a local represnatative of a remote object
  - Virtual(Cashing) Proxy : On-demant creaton. When you say draw that is when the image is laoded
  - Protection Proxy: Acces Control  on permissions.
  - Smart Pointer: Encapsualtes the potinter
*/


abstract class Subject {  
  abstract public void Request();
}
class RealSubject : Subject { //hiden by the proxy
  public override void Request() { }
} 
class Proxy : Subject {
  RealSubject? realSubject;
  public override void Request() {
    if (realSubject == null ) realSubject = new RealSubject();
    //... 
    realSubject.Request();
    //...
  }
}