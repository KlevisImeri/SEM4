```mermaid
sequenceDiagram
    User->>System: Request
    alt Request is valid
        System-->>User: Process request
    else Request is invalid
        System-->>User: Reject request
    end

```

```mermaid
sequenceDiagram
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedPipe(pipe)
	Player->>PlumberKeyboardInput: onKewboardInput("i")
	PlumberKeyboardInput->>Grid:fixPipe(Plumber);
	PipeGUI->>GridGUI:redraw();
	
	Player->>PumpGUI: onMouseClick()
	PumpGUI->>Grid: setselectedPump(pump)
	Player->>PlumberKeyboardInput: onKewboardInput("f")
	PlumberKeyboardInput->>Grid:fixPump(Plumber);
	PumpGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>PumpGUI: onMouseClick()
	PumpGUI->>Grid: setselectedPump(pump)
	Player->>PlumberKeyboardInput: onKewboardInput("p")
	PlumberKeyboardInput->>Grid:fixPump(Plumber);
	PumpGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedPipe(pipe)
	Player->>PlumberKeyboardInput: onKewboardInput("f")
	PlumberKeyboardInput->>Grid:fixPipe(Plumber);
	PipeGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedPipe(pipe)
	Player->>PlumberKeyboardInput: onKewboardInput("d")
	PlumberKeyboardInput->>Grid:changeDirection(Plumber);
	PipeGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedPipe(pipe)
	Player->>PlumberKeyboardInput: onKewboardInput("a")
	PlumberKeyboardInput->>Grid:insertPump(Plumber);
	PipeGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedPipe(pipe)
	Player->>PlumberKeyboardInput: onKewboardInput("r")
	PlumberKeyboardInput->>Grid:changeDirection(Plumber);
	PipeGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedPipe(pipe)
	Player->>PlumberKeyboardInput: onKewboardInput("y")
	PlumberKeyboardInput->>Grid:setInPipe(Plumber);
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedPipe(pipe)
	Player->>PlumberKeyboardInput: onKewboardInput("o")
	PlumberKeyboardInput->>Grid:setOutPipe(Plumber);
	PipeGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>PipeGUI: onMouseClick()
	PipeGUI->>Grid: setselectedActiveElement(ActiveElement)
	Player->>PlumberKeyboardInput: onKewboardInput("m")
	PlumberKeyboardInput->>Grid:moveToLocation(Plumber);
	PipeGUI->>GridGUI:redraw();
```

```mermaid
sequenceDiagram
	Player->>MenuGUI:presses the "Start Game" Button
	MenuGUI->>Main:startGame()
```

```mermaid
sequenceDiagram
    Player->>MenuGUI: presses the "End Game" Button
    MenuGUI-->>MenuGUI: showConfirmationDialog()
    Player->>MenuGUI: chooses "yes"
    MenuGUI->>Main: endGame()
    Player->>MenuGUI: chooses "no"
    MenuGUI-->>MenuGUI: closeConfirmationDialog()
```

```mermaid
sequenceDiagram
    Player->>PlayresCollectionGUI: entersName
    PlayresCollectionGUI-->>PlayresCollectionGUI: updatesTheJTextFileds
    Player->>PlayresCollectionGUI: entersName
    PlayresCollectionGUI-->>PlayresCollectionGUI: updatesTheJTextFileds

```


```mermaid
sequenceDiagram
	Player->>MenuGUI:presses the "Settinga Button" Button
	MenuGUI->>MenuGUI:add(SettingGUI)
	Player->>SettingGUI: changes text filds
	SettingGUI->>Settings: updatesFields
	SettingGUI->>SettingGUI: updatesTheJTextFiled
	Player->>MenuGUI: presses the "Done" button
	MenuGUI->>MenuGUI:remove(SettingGUI)
	
```


k
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Pump: onMouseClick()
    Pump->>-Grid: setSelectedActiveElement(this)
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: fixPump()
    Plumber->>+Grid: getSelectedActiveElement()
	Grid-->>-Plumber: ActiveElement
	Plumber->>+Location: isConnected(ActiveElement)
    alt yes or selected=location
	    Location-->>Plumber: True 
        alt selectedActiveElement is Pump
            Plumber->>Pump: fix()
            Plumber->>Plumber: move(Pump)
        else selectedActiveElement is Cistern
            Plumber-->>User: "You can't fix a cistern"
        else selectedActiveElement is Spring
            Plumber-->>User: "You can't fix a spring"
        end
    else no
	    Location-->>-Plumber: Flase 
        Plumber-->>-User: "The pump is too far"
    end
```
```java

```

### 4. Change Pipe Direction
```mermaid
sequenceDiagram
    actor User as Player
    User->>+Pipe: onMouseClick()
    Pipe->>-Grid: setSelectedPipe(this)
    User->>+Player: keyTyped(e)
    Player->>Player: changePipeDirection()
    Player->>+Grid: getSelectedPipe();
	Grid -->>-Player: Pipe;
	Player->>+Location: isConnected(Pipe)
	alt yes
		Location-->>Player: True 
		Player->>Pipe: changePipeDirection()
	else No
		Location-->>Player: False
		Player-->>User: "The pipe is too far!"
	end
```

### 3. Fix Grid :: Repair Leaking Pipe
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Pipe: onMouseClick()
    Pipe->>-Grid: setSelectedPipe(this)
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: fix()
    Plumber->>+Grid: getSelectedPipe();
	Grid -->>-Plumber: Pipe;
    Plumber->>+Location: isConnected(Pipe)
    alt yes
	    Location-->>Plumber: True 
	    Plumber->>Pipe: fix()
    else No
	    Location-->>Plumber: False
        Plumber-->>-User: "The pipe is too far!"
    end
```p

```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Pipe: onMouseClick()
    Pipe->>-Grid: setSelectedPipe(this)
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: fixPipe()
    Plumber->>+Grid: getSelectedPipe();
	Grid -->>-Plumber: Pipe;
	alt player has a pump
	    Plumber->>+Location: isConnected(Pipe)
	    alt yes
		    Location-->>Plumber: True 
		    create participant NewPipe
			Plumber->>NewPipe: new Pipe()
			Plumber->>+Pipe: getNext(location)
			Pipe-->>-Plumber: theNextACtiveElement
			Plumber->>NewPipe: addVertex(carryPump)
			Plumber->>NewPipe: addVertex(ActiveElement)
			Plumber->>carryPump: setInPipe(Pipe)
			Plumber->>carryPump: setOutPipe(NewPipe)
			Plumber->>Pipe: removeVertex(theNextACtiveElement)
			Plumber->>Pipe: addVertex(carryPump)
	    else No
		    Location-->>Plumber: False
	        Plumber-->>User: "The pipe is too far"
	    end
    else carryPump=null
		Plumber-->>-User: "You have no pump!"
	end
	
```