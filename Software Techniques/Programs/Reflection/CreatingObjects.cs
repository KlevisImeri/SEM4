// using System.Reflection;

// class Student {
//   public int Id { get; set; }
//   public string Name { get; set; }
//   public string Info => $"Name is: {Name} and Id is {Id}";

//   public Student(int id, string name) {
//     Id = id;
//     Name = name;
//   }
// }

// class Teacher {
//   public int TeacherID { get; set; }
//   public int TeacherName { get; set; }
//   public string Info => $"Name is: {TeacherID} and Id is {TeacherName}";
//   public Teacher(int id, int name) {
//     TeacherID = id;
//     TeacherName = name;
//   }

// }


// class CreatingObjets {
//   public static void Main() {

//     Console.WriteLine("Select the type of the object: ");
//     String choice = Console.ReadLine();
//     Type[] types = Assembly.GetExecutingAssembly().GetTypes();
//     Type type = types.Single(t => t.Name.ToLower() == choice.ToLower());
//     Console.WriteLine($"You selected {type.FullName}");

//     List<object> fields = new List<object>();

//     foreach (PropertyInfo p in type.GetProperties()) {
//       if (p.Name == "Info") continue;
//       Console.WriteLine("Enter " + p.Name);
//       if (p.PropertyType == typeof(int)) {
//         fields.Add(int.Parse(Console.ReadLine()));
//       } else {
//         fields.Add(Console.ReadLine());
//       }
//     }

//     ConstructorInfo cn = type.GetConstructors()[0];
//     var o = cn.Invoke(fields.ToArray());
//     PropertyInfo fi = type.GetProperty("Info");

//     Console.WriteLine("Info: " + fi.GetValue(o));
//   }


// }
