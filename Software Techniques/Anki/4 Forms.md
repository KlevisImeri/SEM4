TARGET DECK: SEM4::Software Techniques::4 Forms

Win32 API vs .NET Windows Forms? #flashcard 
![[Pasted image 20240421120658.png]]
<!--ID: 1713705004556-->


How is event handling done in Win32 platform? #flashcard 
![[Pasted image 20240421121555.png]]
<!--ID: 1713705004564-->



What are partial classes? #flashcard 
![[Pasted image 20240313223209.png]]
<!--ID: 1710367167765-->


Explain the technology stack? #flashcard 
![[Pasted image 20240313223217.png]]
<!--ID: 1710367167788-->

Form which class does every window derive from? 
What is this class? 
What are the events this class publishes? 
What are some of the properties? 
Where are the controls initilized? #flashcard 
![[Pasted image 20240421132533.png]]
- The Form class.
- Is the topmost container in the container-
controller hierarchy.
<!--ID: 1710367167804-->


What are the controls in windows forms? 
Where are they instantiated from? #flashcard 
- Member variables of the from object.
- They are instantiated in the InitializeComponent() method that is called by the constructor
<!--ID: 1710367167809-->


Does visual studio generate full or partial classes? #flashcard 
- Visual Studio generates partial classes
<!--ID: 1710367167813-->



Based on the design of the application interface what are the types of programs? #flashcard 
- **Dialog-based**: only controls are placed on the form, as it was a dialog
window. We open new windows for some functions if neccesary. Example:
the Calculator application in Windows
 - **SDI or MDI applications**: document-based programs, where the form’s
primary function is to allow the user to view/edit certain documents. Other
services are accessible from menus and toolbars. SDI (Single Document
Interface) applications can handle only one document at a time, while MDI
(Multiple Document Interface) applications can deal with several. Example:
Microsoft Word
 - **Mixed solutions**: the main purpose of these application is viewing/editing
documents, just like in SDI/MDI applications, but certain areas of the form
are reserved for different controls, through which users can access several
functions of the applications. Example: Microsoft Visual Studio
<!--ID: 1710367167831-->


Explain the Container-Controller Hiearchy? #flashcard 
The Container-Controller Hierarchy in Windows Forms refers to the organization of controls within a form or container, along with the way these controls are managed and interact with each other.
Here's a breakdown of the Container-Controller Hierarchy:
1. **Form or Container**: At the top level is typically a form, which serves as the main window of the application, or another container control like a panel or group box. Containers can hold other controls and help organize the layout of the user interface.
2. **Controls**: Controls are the user interface elements such as buttons, text boxes, labels, etc., that are placed within the form or container. These controls can be directly added to the form or nested within container controls.
3. **Parent-Child Relationship**: Controls within a form or container form a parent-child relationship. The form or container is the parent, and the controls it contains are its children. This hierarchy allows for organizing and managing controls within the user interface.
4. **Control Properties**: Each control has properties that define its appearance, behavior, and functionality. These properties can be set programmatically or through the design view in the Visual Studio IDE.
5. **Control Events**: Controls can raise events in response to user actions or changes in their state. For example, a button control can raise a Click event when clicked by the user. Developers can handle these events by writing event handler methods to perform specific actions.
6. **Layout Management**: Containers often provide layout management capabilities to arrange and position their child controls. Layout options include absolute positioning, docking, anchoring, flow layout, and table layout, among others.
Overall, the Container-Controller Hierarchy in Windows Forms provides a structured approach to building user interfaces by organizing controls within forms or containers and managing their interactions and layout. This hierarchy helps developers create visually appealing and functional applications with ease.
<!--ID: 1710367167836-->


How is Message-handling done in windows forms? #flashcard 
A Windows Form program is an event-driven application, which receives messages
through the Windows operating system. The message loop can be found in the Main
function of the application (Application.Run), it will only terminated when the
application is closed.
Even simple Controls (like a TextBox) communicate through messages, but in .NET
we see them as properties (e.g. setting the Text property of a TextBox sends a
message to that control, which responds to that message by setting it’s text to the
given string).
<!--ID: 1710367167841-->


What are the most commonly used controls and what do they do? #flashcard 
Some of the most commonly used controls:
- TextBox: an input field
- Label: shows a simple text
-  Button: a button that can be pressed
-  MenuStrip: the main menu
-  ToolStrip: placeholder for toolbar items
-  StatusStrip: status bar, can provide the user with additional information
about the status of the application
-  SplitContainer: divides it’s parent control into two separate parts
-  TreeView: shows elements in a tree-like hierarchy
 - ListView: shows the elements of a list, can have multiple columns, may
contain pictures
<!--ID: 1710367167845-->


Explain hwo message and event handling is done in forms? #flashcard 
![[Pasted image 20240421140257.png]]
<!--ID: 1713705004569-->


Tell the controls you can use in Form for things related to menu()? #flashcard 
![[Pasted image 20240421150949.png]]
<!--ID: 1713705004573-->


What are the possible timers in C#? #flashcard 
![[Pasted image 20240421153241.png]]
<!--ID: 1713709052196-->



What functions should you remember about timer? #flashcard 
timer.Interval = 10;
timer.Tick += (o, e) => {};
timer.Start();
<!--ID: 1713709052204-->



Talk about dialog windows and how to make the form fix? #flashcard 
![[Pasted image 20240421154353.png]]
<!--ID: 1713709052209-->



Give an example of how to create a dialog form and how to use it? #flashcard 
DialogResult = DialogResult.OK\/Cancel\/Yes ...
and
form.ShowDialog();
![[Pasted image 20240421161018.png]]![[Pasted image 20240421161040.png]]
<!--ID: 1713709052213-->


Give an example of a message box? #flashcard 
![[Pasted image 20240421162416.png]]
<!--ID: 1713710175950-->



Diff between `this.Close()` and `Application.Exit()`? #flashcard 
- `this.Close()`: This method is called on an instance of a form (or window) and is used to close that particular form. It releases the resources associated with the form and removes it from the screen. It's typically used when you want to close a specific form within your application. 
- `Application.Exit()`: This method is used to exit the entire application. It closes all forms and exits the message loop, terminating the application's execution. It's used when you want to close all forms and end the program completely.
<!--ID: 1713709052219-->



what are modal windows? #flashcard 
Modal windows are a type of graphical user interface (GUI) window that temporarily halts the workflow of the application until the modal window is closed.
Dialog
MessageBox
<!--ID: 1713709593603-->


What do you use to show a windows ontop of a parent? #flashcard 
```csharp
settingsForm.Show(this);
```
<!--ID: 1713710175955-->





Using verbatim string literals can make paths, regular expressions, and other strings with special characters easier to read and write.
<!--ID: 1713710175959-->


What are some common dialogs in C#? #flashcard 
![[Pasted image 20240421163710.png]]
<!--ID: 1713710234738-->


What are some important windows forms simple controls? #flashcard 
![[Pasted image 20240421163757.png]]
<!--ID: 1713710513663-->


Can you show some examples of Container Controls? #flashcard 
![[Pasted image 20240421164143.png]]
When you click on the tabs displayed at the top of the TabControl, the page changes to the corresponding TabPage. This allows users to switch between different sets of controls or content within the same window.
<!--ID: 1713710513668-->



Draw the Component/Control hierarchy? #flashcard 
![[Pasted image 20240421164330.png]]
![[Pasted image 20240421164949.png]]
![[Pasted image 20240421165404.png]]
This means that a ContainerControl, such as a Panel or GroupBox, can contain other controls within it. When you interact with controls inside a ContainerControl, the ContainerControl is responsible for managing the focus among its child controls.
For example, if you have multiple text boxes inside a Panel, clicking on one of the text boxes will give focus to that text box. However, the Panel will still keep track of which control had the focus last (the "active control"), even if you click outside of the text boxes within the Panel.
<!--ID: 1713710685365-->


Explain the relationship between Controls and Forms? #flashcard 
![[Pasted image 20240421170454.png]]
**Independence of Appearance**: Unlike child controls within a parent control, owned forms can have independent appearances, such as different sizes, positions, and visual styles. They are not constrained by the size or position of their owner form.
YOU CAN SEE THERE IS NOT CLIPPING.
<!--ID: 1713711920022-->

Talk about key events and and and how do you select Kyes? #flashcard 
Keys.E
![[Pasted image 20240421200220.png]]
<!--ID: 1713723016696-->


Do we know what thread will call the Finalizers? 
Do we now the order of Finalizers?
Are finalizers slow why? 
How do you write a finalizer? 
What is the problem with this:  
![[Pasted image 20240421201009.png]] #flashcard 
![[Pasted image 20240421200857.png]]
![[Pasted image 20240421200923.png]]
![[Pasted image 20240421201023.png]]
<!--ID: 1713723016724-->


When do we write a destrcutor and why? #flashcard 
![[Pasted image 20240421201349.png]]
![[Pasted image 20240421201354.png]]
![[Pasted image 20240421201402.png]]
<!--ID: 1713723248022-->


Why do we need the Dispose? #flashcard
Because finalize is non-deterministic.
![[Pasted image 20240421201755.png]]
<!--ID: 1713723516788-->


sing classes that implement the IDisposable interface? #flashcard 
![[Pasted image 20240421201931.png]]![[Pasted image 20240421201937.png]]
<!--ID: 1713723579715-->

How is the Dispose integrated to the control? 
what is HWND? 
How does it look inside a premade form?  #flashcard 
Handle to Window.
![[Pasted image 20240421202324.png]]
![[Pasted image 20240421202619.png]]
<!--ID: 1713723808273-->


Explain The the Components that are worth knowing? #flashcard 
TextChanged
![[Pasted image 20240421202755.png]]
![[Pasted image 20240421202726.png]]
<!--ID: 1713724516941-->



What does @ before string do in C# ? #flashcard 
In C#, the `@` symbol before a string literal creates a verbatim string literal. This means that escape sequences are not processed within the string, allowing you to include backslashes and line breaks directly without escaping them.
For example:
```csharp
string path = @"C:\Folder\file.txt"; // Verbatim string literal
```
Without the `@` symbol, you would need to escape the backslashes:
```csharp
string path = "C:\\Folder\\file.txt"; // Escaped string literal
```
<!--ID: 1713724646023-->


Creating custom controls Ways? #flashcard 
![[Pasted image 20240421203854.png]]
![[Pasted image 20240421204156.png]]
![[Pasted image 20240421204202.png]]
![[Pasted image 20240421204258.png]]
<!--ID: 1713724738087-->

What do use for 2D graphics in windows? #flashcard 
![[Pasted image 20240421204726.png]]
<!--ID: 1713725249573-->

Talk about GDI architecture? #flashcard 
![[Pasted image 20240421204909.png]]
<!--ID: 1713725496510-->


What is the Device Context? #flashcard 
![[Pasted image 20240421204950.png]]
<!--ID: 1713725496515-->


Does the OS save the content of window (memory)? #flashcard 
No INVALID AREA has to be redrawn.
![[Pasted image 20240421205113.png]]
![[Pasted image 20240421205208.png]]
<!--ID: 1713725496519-->

Lest talk about Graphics in managed environment .NET architecture? #flashcard 
![[Pasted image 20240421205808.png]]
<!--ID: 1713725897165-->

Should be call onPaint and what what arguments does it take, Take about that arguemnt? #flashcard 
![[Pasted image 20240421210647.png]]
<!--ID: 1713726475693-->



How do you handle colors? #flashcard 
![[Pasted image 20240421210753.png]]
<!--ID: 1713726475697-->


What are some drawing operatoins? #flashcard 
![[Pasted image 20240421211238.png]]
<!--ID: 1713727281832-->


![[Pasted image 20240421211254.png]]


Can you give examples of drawing with pen? #flashcard 
![[Pasted image 20240421212108.png]]
![[Pasted image 20240421212114.png]]
<!--ID: 1713727281838-->


Can you give examples how to draw with brush? #flashcard 
![[Pasted image 20240421212234.png]]
![[Pasted image 20240421212309.png]]
<!--ID: 1713727357349-->


How to display and image? #flashcard 
![[Pasted image 20240421213723.png]]
<!--ID: 1713728871582-->


How would you draw text? #flashcard 
![[Pasted image 20240421214744.png]]
![[Pasted image 20240421214748.png]]
<!--ID: 1713728871590-->

What can CDI+ be used for and what not? #flashcard 
![[Pasted image 20240421214928.png]]
<!--ID: 1713728970645-->

What are the newest TEchonologies? #flashcard 
![[Pasted image 20240421215121.png]]
<!--ID: 1713729084864-->

Talk about how double buffering is done?
Why is manual double buffering faster?
What are virtual windows?
#flashcard 
![[Pasted image 20240421222141.png]]
![[Pasted image 20240421221633.png]]
![[Pasted image 20240421221637.png]]
<!--ID: 1713730675821-->


How can cordinate transpformation be done? #flashcard 
![[Pasted image 20240421221819.png]]
<!--ID: 1713730700694-->
