using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
class StorableClassAttribute : Attribute {
  public StorableClassAttribute() { }
}


[AttributeUsage(AttributeTargets.Property)]
class StorableAttribute : Attribute {
  public String Name { get; init; }
  public StorableAttribute(string name) {
    Name = name;
  }
}


[StorableClass]
class Student {
  [Storable("Name")]
  public string Name { get; init; }
  [Storable("Neptun")]
  public string Neptun { get; init; }
  public Student(string name, string neptun) {
    Name = name;
    Neptun = neptun;
  }
}



class SaveUtils {
  public static void Save(object o) {
    Console.WriteLine("Saving...");
    Type type = o.GetType();

    object[] attributes = type.GetCustomAttributes(typeof(StorableClassAttribute), false);
    if (attributes.Length == 0) return;

    Console.WriteLine("Object is savable!");

    PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    foreach (PropertyInfo pi in propertyInfos) {
      object[] propertiesAttributes = pi.GetCustomAttributes(typeof(StorableAttribute), false);
      if (propertiesAttributes.Length == 0) continue;

      StorableAttribute attr = (StorableAttribute)propertiesAttributes[0];
      Console.WriteLine($"Name: {attr.Name}"); 
      Console.WriteLine($"Value: {pi.GetValue(o).ToString()}");
    }
  }
}

class Attributes {
  public static void Main() {
    Student student = new Student("James Bond", "007");
    SaveUtils.Save(student);
  }
}