

  // class Question {
  //   public int x, y;
  //   public Question(int x, int y){
  //     this.x = x;
  //     this.y = y;
  //   }
  //   public override string ToString() {
  //     return $"{x}+{y}?";
  //   }
  // }

  // class Test {
  //   static Queue<Question> questions = new();
  //   static object consoleLock = new object();
  //   static List<int> students = new();
  //   static List<Thread> threads = new();

  //   static void Main() {
  //     for(int i=0; i<100; i++) {
  //       questions.Enqueue(new Question(new Random().Next(0,1000), new Random().Next(0,1000)));
  //     }
  //     Console.WriteLine("Created Questions!");


  //     for(int i=0; i<10; i++) {
  //       Thread thread = new Thread((x) => Run((int)x));
  //       threads.Add(thread);
  //       thread.Start(i);
  //       students.Add(0);
  //     }

  //     foreach(var thread in threads) {
  //       thread.Join();
  //     }

  //     Console.WriteLine(string.Join(", ", students));
      
  //     Thread.Sleep(1000);
  //   }

  //   static void Run(int x) {
  //     while(true){
  //       Question current;
  //       lock(questions){
  //         if(questions.Count == 0) break;
  //         current = questions.Dequeue();
  //       }
  //       string answer = SolveQuestion(current);
  //       students[x]++;
  //       lock(consoleLock){
  //         DisplayResult(current.ToString(), answer);
  //       }
  //     }
  //   }

  //   static void DisplayResult(string question, string answer) {
  //     Console.WriteLine($"{question}:{answer}");
  //   }

  //   static String SolveQuestion(Question question) {
  //     Thread.Sleep(new Random().Next(100, 500));
  //     return $"{question.x+question.y}";
  //   }
  // }