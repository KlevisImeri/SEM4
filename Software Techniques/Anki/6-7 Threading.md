TARGET DECK: SEM4::Software Techniques::Threading

What is an application, process, thred? #flashcard 
> Application := many processes
> Process := unit of protection
> Thread := unit of scheduling and execution
<!--ID: 1712827694952-->



How is memory allocated and what is the message for invalid address? #flashcard 
- API calls to OS : VirutalAlloc, HeapAlloc
- Invalid address :  „Access violation at address ...” 
<!--ID: 1712827694964-->



What are some functions of the process class? #flashcard 
```c#
class System.Diagnostics.Process {
	PriorityClass;
	Start()
	Kill()
	GetCurrentProcess()
}
```
<!--ID: 1712827694971-->



How are threads created? #flashcard 
User ->Application -> Process -> Main thread -> Other threads
OS schedules the threads
<!--ID: 1712827694977-->


What is hyperthreading? #flashcard
Usually one thread per CPU
> Hyperthreading := CPU several threads
<!--ID: 1712827694984-->


Types of scheduling? #flashcard 
- Non preemtive
- Preemtive  - scheduler is the boss
<!--ID: 1712827694991-->


States of threads? #flashcard 
- Running
- Suspended
- Waiting for I/O operation
<!--ID: 1712827694997-->


How is the meme of the threads, what do they share with each other? #flashcard 
Each thread its separate stack.
![[Pasted image 20240411105108.png]]
<!--ID: 1712827695006-->



What is synchronous/Asynchronous execution? #flashcard 
![[Pasted image 20240411105518.png]]
<!--ID: 1712827695012-->



How to implement asynchronous tasks? #flashcard 
![[Pasted image 20240411105629.png]]
<!--ID: 1712827695019-->


What is the namespace for threads? #flashcard 
System.Threading 
<!--ID: 1712827695026-->



Wheare are multithreadd applcations usually used? #flashcard 
![[Pasted image 20240411105935.png]]
<!--ID: 1712827695033-->



Write a simple thread that pints y's while main prints x?
Then make is so the new thread prints a deseried charactged? #flashcard 
![[Pasted image 20240411111015.png]]
![[Pasted image 20240411111402.png]]
<!--ID: 1712827695040-->



What is the diff between background and foreground threads?
What are threads by default? 
Give and example? #flashcard 
![[Pasted image 20240411111908.png]]
![[Pasted image 20240411112725.png]]
<!--ID: 1712827695046-->




What functions does the thread class include? #flashcard 

 
<!--ID: 1712827695053-->



What are the priorities level of the process and thread?
What is default value? 
How do you change these priorities in code?  #flashcard 
Default is ***Normal***;
![[Pasted image 20240411114550.png]]
<!--ID: 1713632951091-->


What are the types of RealTime Opreating systems? #flashcard 
![[Pasted image 20240411114802.png]]
<!--ID: 1713632951096-->


What happens when you have an unhandled exception in a thread (not main)? #flashcard 
The whole application will exit
<!--ID: 1713632951101-->


Can you handle the exception of a thread from where you created it? #flashcard 
No
![[Pasted image 20240411115536.png]]
<!--ID: 1713632951107-->


How to handel exceptions in genarl way in windows forms? #flashcard 
![[Pasted image 20240411120054.png]]
<!--ID: 1713632951112-->



What is the critical section? #flashcard 
![[Pasted image 20240417061941.png]]
<!--ID: 1713632951117-->


Goal: print ‘Done’ once using ‘racing’ threads. #flashcard 
![[Pasted image 20240417062345.png]]
<!--ID: 1713632951122-->



How does lock(objet){ //.. } translate to? #flashcard 
![[Pasted image 20240417062515.png]]
<!--ID: 1713632951127-->




Can you nest locks? What happpens? #flashcard 
![[Pasted image 20240417062629.png]]
<!--ID: 1713632951131-->


Montitor{
	Enter(sycnObject)
	Exit(syncIbject)
}

What can be used as a synchronization object? How to protect our variables? #flashcard 
![[Pasted image 20240417062744.png]]
<!--ID: 1713632951136-->


What are Thread-Safe classes? Give Example? Should we make all our classes thread-safe? #flashcard 
![[Pasted image 20240417062853.png]]![[Pasted image 20240417062936.png]]
<!--ID: 1713632951142-->


What do we have to protect inside classes and how to do it? #flashcard 
![[Pasted image 20240417063210.png]]![[Pasted image 20240417063231.png]]
<!--ID: 1713632951146-->


What are volatile fields?
If there is a lock do we have to use volatile? #flashcard 
![[Pasted image 20240417063418.png]]![[Pasted image 20240417063448.png]]
<!--ID: 1713632951150-->



Give an example of stopping a thread? #flashcard 
![[Pasted image 20240417063648.png]]
<!--ID: 1713632951155-->

How can you synchronize with signaling using thread? #flashcard 
![[Pasted image 20240421223234.png]]
<!--ID: 1713731556885-->


Can you explain the Waithadle hierarchy? #flashcard 
![[Pasted image 20240421223336.png]]
<!--ID: 1713732812502-->


Talk about autoResetEvent and ManualRestEvent and other clases derive from Wiathandle? #flashcard 
![[Pasted image 20240421223428.png]]![[Pasted image 20240421223439.png]]
![[Pasted image 20240421224154.png]]
<!--ID: 1713732812507-->


Talk about the waitHandle class? #flashcard 
![[Pasted image 20240421224215.png]]
<!--ID: 1713732812512-->



What are teh states of the thread? #flashcard 
![[Pasted image 20240421224233.png]]![[Pasted image 20240421224240.png]]\
<!--ID: 1713732812516-->


How to strop a thread with Interrupt? #flashcard 
![[Pasted image 20240421224600.png]]![[Pasted image 20240421224613.png]]
<!--ID: 1713732812521-->


What about thread abourt? #flashcard 
![[Pasted image 20240421224710.png]]
<!--ID: 1713732812525-->


Multi-threaded Windows Forms applications? #flashcard 
![[Pasted image 20240421225013.png]]
<!--ID: 1713732812531-->


Talk about the thread pool? #flashcard 
![[Pasted image 20240421225156.png]]
![[Pasted image 20240421225207.png]]
![[Pasted image 20240421225216.png]]
<!--ID: 1713732812535-->



Talk about deadlock? #flashcard 
![[Pasted image 20240421225231.png]]
<!--ID: 1713732812540-->


What are the drawbacks of multithreaded applciatoins? #flashcard 
![[Pasted image 20240421225317.png]]
<!--ID: 1713732812545-->
