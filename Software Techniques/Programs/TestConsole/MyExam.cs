public class Program {
  static ManualResetEvent manual = new ManualResetEvent(true);
  static Queue<string> questions = new Queue<string>();
  static object lockObject = new object();
  static Random random = new Random();
  static volatile bool generatingQuestion = true;

  public static void Main(string[] args) {

    /*----------Adding Threads and starting Them----------*/
    List<Thread> students = new List<Thread>();

    for (int i = 0; i < 50; i++) {
      Thread student = new Thread(StudentThreadFunction);
      student.Start(); students.Add(student);
    }
    /*----------------------------------------------------*/

    
    /*---------------Adding the Questions-----------------*/
    for (int i = 0; i < 100; i+= 10) {
      for (int j = 0; j < 10; j++) {
        lock(questions){//You have to lock the Queue everytime
          questions.Enqueue($"Question {i + j + 1}");
        }
      }
      manual.Set(); //Every time the teacher adds to questoins 
                    //it sets the Manual event. To say to the 
                    //threads not to wait
      Thread.Sleep(1000);
    }
    generatingQuestion = false; //After you finish generating
                                //You have to tell other thre-
                                //ds to stop.
    manual.Set(); //One more time in the end to make sure to 
                  //release any waiting thread
    /*----------------------------------------------------*/


    /*--------------------Usual Ending------------------*/
    //Wait for otther threads to stop
    foreach (Thread student in students) student.Join();

    Thread.Sleep(1000);
    /*----------------------------------------------------*/
  }

  public static void StudentThreadFunction() {
    string question = "";
    while (true) {
      manual.WaitOne();
      lock (questions) {
        if (questions.Count==0 && generatingQuestion==false) break;
        else if (questions.Count==0 && generatingQuestion==true) {manual.Reset(); continue;}
        else if (questions.Count > 0) question = questions.Dequeue();
      }
      
      Thread.Sleep(random.Next(300, 700));
      Solved(question, "answered");
      
      Thread.Sleep(100);
    }
  }

  public static void Solved(string question, string solution) {
    lock (lockObject) {
      DisplayResult(question, solution);
    }
  }

  public static void DisplayResult(string question, string solution){
    Console.WriteLine($"{question} is {solution}");
  }
}