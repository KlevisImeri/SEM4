
//Problem: How to iterate the same for all collections


abstract class Iterator {
  public abstract object First();
  public abstract object Next();
  public abstract bool IsDone();
  public abstract object CurrentItem();
}

class ConcreateIterator : Iterator {
  ConcreateAggregate concreateAggregate;
  public ConcreateIterator(ConcreateAggregate a) {
    concreateAggregate = a;
  }
  public override object CurrentItem() { throw new NotImplementedException();}
  public override object First() { throw new NotImplementedException();}
  public override bool IsDone() { throw new NotImplementedException();}
  public override object Next() { throw new NotImplementedException();}
}

abstract class Aggregate {
  abstract public ConcreateIterator CreateIterator();
}

class ConcreateAggregate : Aggregate { 
  override public ConcreateIterator CreateIterator() {
    return new ConcreateIterator(this);
  } 
}

class Example {
  static void Main() {

  }
}