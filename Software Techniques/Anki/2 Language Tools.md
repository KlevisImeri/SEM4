TARGET DECK: SEM4::Software Techniques::2 Language Tools

What is the property? 
How are these methods called? #flashcard 
A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can be used as if they're public data members, but they're special methods called accessors. 
<!--ID: 1713642037615-->

What is multicasting? #flashcard 
A delegate can call more than one method when invoked. This is referred to as multicasting.
<!--ID: 1713651725548-->



The delegate model follows what pattern? #flashcard 
Observer design pattern.
provider <- subsciber1,2,3..
![[Pasted image 20240420233650.png]]
<!--ID: 1713651725671-->



The object that raises the event is called? #flashcard 
Event sender
<!--ID: 1713651725676-->


Does event sender which object or method will receive the events it raises?
What about the receiver does it know who created that event?
The event sender doesn't know which object or method will receive (handle) the events it raises.
The receiver usually knows (if you implemented like that it can be null object)
![Pasted image 20240420235853.png](app://f934a7e266d6494327bbd01962cd17761201/D:/Users/Admin/Desktop/UNI/SEM4/Images/Pasted%20image%2020240420235853.png?1713650333072)



What are Event Handlers?
How do the generic delagates for evenehadling look? #flashcard 
Event handlers are nothing more than methods that are invoked through delegates
![[Pasted image 20240420235853.png]]
![[Pasted image 20240420235842.png]]
<!--ID: 1713651725680-->


What is the base type for all event data classes? #flashcard 
EventArgs
Use it when you don't have any data to pass.
<!--ID: 1713651729253-->


Where can you declare a delegate? 
Where can you iniciate a delegate? 
Can you declare a event? 
Where can you iniciate a event?  #flashcard 
Delegate:
- Declare: namespace, class
- Iniciate: class, func (localy)
Event:
- Declare: No
- Inicate: class
<!--ID: 1713651725685-->


How are events different compared to delegates? #flashcard 
![[Pasted image 20240421002408.png]]
<!--ID: 1713653383645-->


What are attributes?
How are they queried during runt time? #flashcard 
- Attributes provide a powerful method of associating metadata, or declarative information, with code (assemblies, types, methods, properties, and so forth). 
- reflection
<!--ID: 1713653383652-->


How are attributes used and what are some predefined attributes?
Where do attributes derive from? #flashcard 
![[Pasted image 20240421003453.png]]
<!--ID: 1713653383662-->




In c# are structs value or reference types? #flashcard 
- Value Types
![[Pasted image 20240421004302.png]]
<!--ID: 1713653383666-->


What kind of types are interfaces? #flashcard 
referecne
<!--ID: 1713653383671-->


Talk about build in reference types? 
Talk about how to compare using string? #flashcard 
![[Pasted image 20240421004915.png]]
<!--ID: 1713653383675-->

What are some exeptions you need to use in properties? #flashcard 
ArgumentException
ArgumentNullException
<!--ID: 1713654279007-->


What does generic solve? #flashcard 
- Type Safety
- Wrapping (int, float ...) slow
<!--ID: 1713690550671-->



Tell the difference between c++ an c# temaplates? #flashcard 
![[Pasted image 20240421100441.png]]
<!--ID: 1713690550781-->



What keyword do you use to pas by reference? #flashcard 
![[Pasted image 20240421100643.png]]
ref
<!--ID: 1713690550786-->



What can be a genereic? 
Give example for each one of them? #flashcard 
![[Pasted image 20240421100949.png]]\
<!--ID: 1713690550808-->


What are possible constrains in generic parameters? #flashcard 
![[Pasted image 20240421103156.png]]
<!--ID: 1713690550813-->


Talk about statement lambda and expression lambda? #flashcard 
![[Pasted image 20240421103942.png]]
<!--ID: 1713690550818-->


What is the type of a lambda expression? #flashcard 
![[Pasted image 20240421104104.png]]\
<!--ID: 1713690550823-->


What are the build in generic delegates? #flashcard 
![[Pasted image 20240421104811.png]]
<!--ID: 1713690550828-->



Give examples of LINQ using the fluent syntax? #flashcard 
![[Pasted image 20240421105551.png]]
![[Pasted image 20240421105556.png]]
![[Pasted image 20240421105738.png]]
<!--ID: 1713690550832-->


In which interface are Where OrderBy and Select defined? #flashcard 
IEnumerable\<T\>
<!--ID: 1713690550837-->


What word to use to combine classes in different files? #flashcard 
partial
<!--ID: 1713690550842-->


Talk about object initializer? #flashcard 
![[Pasted image 20240421110836.png]]
<!--ID: 1713690550852-->
