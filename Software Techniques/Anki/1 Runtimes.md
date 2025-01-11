TARGET DECK: SEM4::Software Techniques::1 Runtimes

What is a VM?
Do runtimes communicate with the hardware? #flashcard 
Yes both OS and hardware.
![[Pasted image 20240420184618.png]]
<!--ID: 1713632951051-->



Why do we need a runtime? 
Explain why n\*m -> n+m translations. #flashcard 
![[Pasted image 20240420185256.png]]
Without the IL for each language and platform you need to compile differently. With IL you compile (C# F#) and so on in one language IL and you need to compile the IL for each platform (because each platform has diff c code).
<!--ID: 1713632951081-->



Why do we need a runtime? #flashcard 
![[Pasted image 20240420185902.png]]
<!--ID: 1713632951085-->

Can draw the java from application to OS? 
Talk about java?
What kind of JVM implementations are there? #flashcard 
![[Pasted image 20240420191008.png]]
![[Pasted image 20240420191041.png]]\
![[Pasted image 20240420191047.png]]![[Pasted image 20240420191054.png]]
<!--ID: 1713635629534-->


Can you explain the Concepts of .NET? #flashcard 
![[Pasted image 20240420192219.png]]
<!--ID: 1713635629540-->


Talk about what are the possible .NET Technologies? #flashcard 
![[Pasted image 20240420192426.png]]
<!--ID: 1713635629545-->



What are the possible .NET (runtimes) versions? #flashcard 
![[Pasted image 20240420192922.png]]
<!--ID: 1713635629549-->



Talk about CLR? #flashcard 
![[Pasted image 20240420193947.png]]
Code Access Security (CAS) is a security feature in the .NET Framework that controls the permissions granted to managed code. It helps protect users and resources by controlling what operations code can perform, based on policies defined by administrators.
<!--ID: 1713635629553-->




Talk about the development in .NET. With its CLR.
Sha is the meaning of NO VARIANT?|
What is full name for COM? #flashcard 
![[Pasted image 20240420195337.png]]
VARIANT was a data type that could hold values of different types, such as integers, strings, dates, and even pointers. It was designed to be flexible, allowing developers to pass different types of data between COM components without needing to convert them explicitly.
However, VARIANTs had some drawbacks, such as potential type mismatches, increased complexity, and performance overhead due to the need for type conversions.
In the .NET framework, there is no direct equivalent of the VARIANT data type. Instead, .NET uses a rich type system where every type is a class or a value type, and type safety is enforced by the compiler. This means that variables are strongly typed, and operations on them are checked for compatibility at compile time.
COM - Component Object Model
<!--ID: 1713635629558-->

Draw thee CLR components? #flashcard 
![[Pasted image 20240420200316.png]]
<!--ID: 1713636945443-->



Talk about how laguages are related to each other in .NET? #flashcard 
![[Pasted image 20240420200245.png]]
<!--ID: 1713636945450-->


What is the name of the compiler platform? #flashcard 
![[Pasted image 20240420201245.png]]
<!--ID: 1713636945454-->



What is CLI? #flashcard 
Common Language Infrastructure (CLI) is an open specification developed by Microsoft that describes the runtime environment and execution model for managed code in the .NET Framework. It includes specifications for the Common Type System (CTS), the Common Intermediate Language (CIL or IL), the Common Language Specification (CLS), and the Common Language Runtime (CLR), among other components.
<!--ID: 1713636945458-->

C++ in .NET? #flashcard 
***MANAGED***
![[Pasted image 20240420202035.png]]
This is the only language is not true now.
<!--ID: 1713638745661-->


What should you talk about when you talk about the Managed Environment? #flashcard 
![[Pasted image 20240420202843.png]]
<!--ID: 1713638745668-->


What is the meaning of `GC No reference counting, traverses the whole object graph in memory` ? #flashcard 
The statement "No reference counting, traverses the whole object graph in memory" means that the .NET garbage collector (GC) does not rely on reference counting to manage memory. Instead, it uses a technique called "tracing garbage collection."
Here's what it means:
1. **No Reference Counting**: Reference counting is a memory management technique where each object keeps track of how many references point to it. When the reference count drops to zero, the object is deallocated. However, reference counting has limitations, especially with cyclic references, where objects reference each other in a loop, preventing them from being deallocated even when they are no longer needed.
2. **Traverses the Whole Object Graph**: In contrast, the .NET garbage collector uses a tracing algorithm to identify and reclaim memory that is no longer in use. It starts from a set of known root objects (such as global variables, thread stacks, and CPU registers) and traverses the entire object graph by following references between objects. Any objects that are not reachable from the root set are considered garbage and can be safely deallocated.
By not relying on reference counting and instead traversing the entire object graph, the .NET garbage collector can accurately identify and reclaim memory even in the presence of cyclic references or complex object relationships. This approach simplifies memory management for developers and ensures efficient use of memory without the risk of memory leaks.
<!--ID: 1713638745673-->



Explain the two phase collection of GC? #flashcard 
1. **Mark Phase**: In the mark phase, the garbage collector traverses the entire object graph starting from the set of known root objects (such as global variables, thread stacks, and CPU registers). It marks each object that is reachable from the root set as "alive" or "in-use" by setting a flag or bit on the object. This phase identifies all reachable objects and ensures that no live objects are inadvertently collected.
2. **Compact Phase**: In the compact phase, the garbage collector reclaims memory by compacting the heap. It moves live objects closer together, filling in the gaps left by reclaimed memory. This reduces fragmentation and optimizes memory usage, improving performance and reducing memory overhead.
<!--ID: 1713638745678-->


Talk about GC generations? #flashcard 
The statement "Uses generations: Young objects die earlier" refers to the concept of generational garbage collection used by the .NET garbage collector (GC). In generational garbage collection, memory is divided into multiple generations or age groups, and objects are categorized based on their age or how long they have survived previous garbage collection cycles.
In the context of the .NET GC:
1. **Young Generation (Gen0)**: Newly created objects are allocated in the young generation (Generation 0). These objects are considered "young" and are expected to have a shorter lifespan. During garbage collection, the GC focuses primarily on collecting and reclaiming memory in the young generation.
2. **Older Generations (Gen1 and Gen2)**: Objects that survive garbage collection cycles in the young generation are promoted to older generations (Generation 1 and Generation 2). These objects are considered "older" and are likely to have a longer lifespan. Garbage collection in the older generations is performed less frequently because objects that survive multiple cycles are less likely to become garbage.
<!--ID: 1713638745682-->



Talk about managed data? #flashcard 
![[Pasted image 20240420204117.png]]
![[Pasted image 20240420204123.png]]
![[Pasted image 20240420204541.png]]
![[Pasted image 20240420204320.png]]
<!--ID: 1713638745687-->

Talk about managed code? #flashcard 
![[Pasted image 20240420205206.png]]
**"Uniform exception handling"**: Exception handling in managed code follows a uniform and consistent model provided by the Common Language Runtime (CLR). This means that exceptions are handled in a standardized way across all .NET languages and environments. Additionally, managed code integrates with the Windows structured exceptions (SEH) mechanism, allowing exceptions raised by native code to be seamlessly propagated and handled within managed code.
In the context of managed environments like .NET, **"pointer tables"** typically refer to internal data structures used by the runtime to manage references to objects in memory. These tables are part of the memory management mechanism implemented by the runtime to track references and perform garbage collection.
<!--ID: 1713640663843-->


Draw and explain the Compilation and Execution phases? #flashcard 
![[Pasted image 20240420205602.png]]
<!--ID: 1713640663849-->




Is the compiler the same for each language or different? #flashcard 
![[Pasted image 20240420205831.png]]
Debug symbols, also known as symbol files or debugging information, are files generated by compilers or build tools that contain additional metadata about a compiled program or library. These symbols are used by debugging tools, such as debuggers or profilers, to map machine code instructions back to their corresponding source code lines, variables, and functions.
Performance counters, on the other hand, are a feature provided by operating systems or runtime environments to monitor and measure various aspects of system or application performance in real-time. Performance counters expose metrics such as CPU usage, memory usage, disk I/O rates, network activity, and application-specific performance indicators.
<!--ID: 1713640663853-->



Talk about IL. #flashcard 
Python is interpreted (no native code) python is executed.
IL need to be compiled in native code => not interpreted
![[Pasted image 20240420210350.png]]
**Reflector**: "Reflector" likely refers to tools like ".NET Reflector" (now known as "dotPeek" by JetBrains) or "ILSpy," which are popular IL disassemblers and decompilers for .NET code. These tools allow developers to analyze, inspect, and decompile .NET assemblies, including IL code, back into C#, VB.NET, or other high-level languages.
<!--ID: 1713640663857-->



What is an assembly? 
What does it contain? 
How are namespaces and assemblies related to each other? #flashcard 
![[Pasted image 20240420210534.png]]
<!--ID: 1713640663862-->



What is contain in Assembly metainformation? #flashcard 
![[Pasted image 20240420210907.png]]
<!--ID: 1713640663866-->



Assembly as a unit…? #flashcard 
![[Pasted image 20240420211352.png]]
  A1     A2
|     |     |
	N1    N2 
   |  |  | |  -> inside here you have types => Types are bound to assemblies
You can not have a type span 2 assemblis.
<!--ID: 1713640663870-->


Talk about Version control of assemblies? #flashcard 
![[Pasted image 20240420211800.png]]
<!--ID: 1713641859465-->


Talk about Dependencies between assemblies?
What are private and shared assemblies? #flashcard 
![[Pasted image 20240420211914.png]]![[Pasted image 20240420212457.png]]
NuGet packages are dowloaded into private assemblies
![[Pasted image 20240420212621.png]]
<!--ID: 1713641859471-->



Explain what is DLL Hell problem? #flashcard 
![[Pasted image 20240420212840.png]]
<!--ID: 1713641859475-->


Talk about GAC? #flashcard 
![[Pasted image 20240420213141.png]]
<!--ID: 1713641859479-->



Talk about NuGet? #flashcard 
![[Pasted image 20240420212951.png]]
<!--ID: 1713641859484-->



Can you give some class Libraries - System namespace? #flashcard 
![[Pasted image 20240420212927.png]]
<!--ID: 1713641859488-->
