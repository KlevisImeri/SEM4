## Abstract Shape
The CAD program has several shapes so a good way to clear the code from repetition was to create a base class `Shape` which would store the x and y position which would be the same for each shape. `Shape` is an ***abstract*** class because you can't really create just a shape, you need to make it concreate (a triangle or a square ...). Another importance of the Shape class was to have  functions `GetX()` ,`GetY()` and  `ToString()` implemented in `Shape` so we don't have to repeat the code in every new shape we add. We also added virtual to `GetX()` ,`GetY()` so the programmer has the flexibility to override in the future. 
> Note that the `GetArea()` is an abstract function because you can only find the area of a concreate shape.

## Interface Shapable
The reason we needed this interface was so we can have `Editbox` which derives from `Textbox` which is a class from outside. This implies that if we create a container with shapes we cant include `Editbox`, therefore we need to create container with the `Shapable` interface  which allows us to include shapes which derive from outside classes (since multiple inheritance is not allowed in .NET). For example we made  the `Editbox` implement this interface, therefore we can put it in the `List<Shapable>` together with the other shapes (because the `Shape` class implements the `Shapable` to).
##### Decisions about the functions in the interface
```C
public interface Shapable
{
	int GetX();
	int GetY();
	double GetArea();
	string ToString();
	Type GetType();
}
```
The `GetX()` and `GetY()` functions where used so you can get the position for the shape and also the `Textbox` already implements them, so les code duplication.
If we were using .NET Core, we could implement the `ToString()` function in the interface to avoid repeating code. The implementation would look like this:
```C
string ToString(){
    return $"{this.GetType()}: <{this.GetX()},{this.GetY()}> Area={this.GetArea()}";
}
```
We would have to implement this function in each new class we add from outside, not even in the `Shape` class, which would have been very convenient. But because the .NET Framework does not allow this, we have to implement it in classes. The default implementation is possible because `ToString()` is just a function showing the usage of the interface, therefore it can have a default implementation in the interface itself.
We are using the `Object.GetType()`, so we don't need to write more code when this function already returns the type (the project and the name of the class). The string returned will also include the project name, but that is even more precise. Another way to do it was to add a different function like `GetTypeString()` and implement it in each class. But this would take more code for no reason, while `GetType()` is good enough for this purpose.

> The implementation of other classes is trivial.
> For simplicity not getters and setters are used. Just the variables are set to protected.
> Also constructors (Circle, Shape) check if the inputs of `radius`, `width` and `heigh` are positive. If not makes them  `0`.
