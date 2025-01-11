//Problem: How to react ot evetents
//Solution: Command Pattern is just one of them SUPPORTS UNDO
//          Java - Adapter (KeyListner ...)
//          .NET - Delegate (Delates Callback
//Also Action 
//Macro := a sequence of commands


// abstract class Command { //Interface for commands
//   protected Receiver receiver;
//   public Command(Receiver receiver) {
//     this.receiver = receiver;
//   }
//   abstract public void Execute();
// }
// class ConcreteCommand : Command {
//   public ConcreteCommand(Receiver receiver) : base(receiver) { }
//   public override void Execute() {
//     receiver.Action();
//   }
// }

// class Receiver {
//   public void Action() { 
//     Console.WriteLine("Hello World!");
//   }
// }

// class Invoker {
//   Command? command;
//   public void SetCommand(Command command) { //for example what should happen in OnClick
//     this.command = command;
//   }
//   public void ExecuteCommand() { // for example OnClick
//     command?.Execute();
//   }
// }

// class Example {
//   static void Main() {
//     Receiver receiver = new Receiver();
//     Command command = new ConcreteCommand(receiver);
//     Invoker invoker = new Invoker();
//     invoker.SetCommand(command);
//     invoker.ExecuteCommand();
//   }
// }

// public abstract class Command {
//   public abstract void Execute();
//   public abstract void UnExecute();
// }
// public class CalculatorCommand : Command {
//   char @operator;
//   int operand;
//   Calculator calculator;

//   public CalculatorCommand(Calculator calculator,
//       char @operator, int operand) {
//     this.calculator = calculator;
//     this.@operator = @operator;
//     this.operand = operand;
//   }

//   public char Operator { set { @operator = value; } }

//   public int Operand { set { operand = value; } }

//   public override void Execute() {
//     calculator.Operation(@operator, operand);
//   }

//   public override void UnExecute() {
//     calculator.Operation(Undo(@operator), operand);
//   }

//   private char Undo(char @operator) {
//     switch (@operator) {
//       case '+': return '-';
//       case '-': return '+';
//       case '*': return '/';
//       case '/': return '*';
//       default:
//         throw new ArgumentException("@operator");
//     }
//   }
// }

// public class Calculator { //receiver
//   int curr = 0;
//   public void Operation(char @operator, int operand) {
//     switch (@operator) {
//       case '+': curr += operand; break;
//       case '-': curr -= operand; break;
//       case '*': curr *= operand; break;
//       case '/': curr /= operand; break;
//     }
//     Console.WriteLine(
//         "Current value = {0,3} (following {1} {2})",
//         curr, @operator, operand);
//   }
// }

// public class User { //Invoker
//   Calculator calculator = new Calculator();
//   List<Command> commands = new List<Command>();
//   int current = 0;

//   public void Redo(int levels) {
//     Console.WriteLine("\n---- Redo {0} levels ", levels);
//     for (int i = 0; i < levels; i++) {
//       if (current < commands.Count - 1) {
//         Command command = commands[current++];
//         command.Execute();
//       }
//     }
//   }

//   public void Undo(int levels) {
//     Console.WriteLine("\n---- Undo {0} levels ", levels);
//     for (int i = 0; i < levels; i++) {
//       if (current > 0) {
//         Command command = commands[--current];
//         command.UnExecute();
//       }
//     }
//   }

//   public void Compute(char @operator, int operand) {
//     // Create command operation and execute it
//     Command command = new CalculatorCommand(calculator, @operator, operand);
//     command.Execute();
//     // Add command to undo list
//     commands.Add(command);
//     current++;
//   }
// }

// public class Program {
//   public static void Main(string[] args) {
//     // Create user and let her compute
//     User user = new User();
//     // User presses calculator buttons
//     user.Compute('+', 100);
//     user.Compute('-', 50);
//     user.Compute('*', 10);
//     user.Compute('/', 2);
//     // Undo 4 commands
//     user.Undo(4);
//     // Redo 3 commands
//     user.Redo(3);
//   }
// }


abstract class Command {
  abstract public void Execute();
  abstract public void Undo();
}

class ChangeColorOfFormToRed : Command { //concreate command
  Form from; //receiver
  int color; //previous color

  public ChangeColorOfFormToRed(Form form) {
    from = form;
  }

  public override void Execute() {
    color=from.GetGolor();
    from.ChangeColor(2); //2 i red
  }

  public override void Undo() {
    from.ChangeColor(color);
  }
}

class Form { //receiver
  int Color=0; //0 is blue

  public void ChangeColor(int color){
    Color=color;
  }
  public int GetGolor(){
    return Color;
  }
}

class Button {
  Command onPressCommand;

  public Button(Command onPress){
    onPressCommand = onPress;
  }

  public void Press() {
    //the color fo the butgton becomes red
    //also called the command
    CommandPrecessor.Instace.ExecuteCommand(onPressCommand);

    //ass usser do you ean to keep this color.
    //if use says no then undo;
    CommandPrecessor.Instace.Undo();
  }
}

class CommandPrecessor {
  static private CommandPrecessor instance = new();
  static public CommandPrecessor Instace = instance;
  
  protected CommandPrecessor() {}

  static Stack<Command> commands = new();

  public void ExecuteCommand(Command com){
    com.Execute();
    commands.Push(com);
  }

  public void Undo(){
    Command com = commands.Pop();
    com.Undo();
  }
}

class Client {
  static void Main() {
    Form form = new();
    Button button = new(new ChangeColorOfFormToRed(form));
    
    button.Press();
  }
}