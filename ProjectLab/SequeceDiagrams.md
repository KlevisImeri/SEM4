### 1.1 Connect Pipe :: Disconnect Pipe :: Put Pump in Pipe
```mermaid
sequenceDiagram
	actor User  as Plumber
	User->>+ActiveElement: onMouseClick()
	ActiveElement->>-Grid: setSelectedActveElement(this)
	User->>+Pipe: onMouseClick()
	Pipe->>-Grid: setSelectedPipe(this)
	User->>+Plumber: keyTyped(e)
	Plumber->>Plumber:connectPipe()
	Plumber->>+Grid: getSelectedActiveElement()
	Grid-->>-Plumber: ActiveElement
	Plumber->>+Grid: getSelectedPipe();
	Grid -->>-Plumber: Pipe;
	Plumber->>+Location: isSecoundNeighbor(ActiveElement)
	alt yes
		Location-->>Plumber: True 	
		Plumber->>Location: isConnected(Pipe)
		alt Yes
			Location-->>Plumber: True 	
			Plumber->>Location: removePipe(Pipe)
			Plumber->>ActiveElement: connectPipe(Pipe)
			Plumber->>Plumber: move()
		else No
			Location-->>Plumber: Flase
			Plumber-->>User: "Pipe is to far away!"
		end
	else no
		Location-->>-Plumber: Flase
		Plumber-->>-User: "The selected ActiveElement is too far!"
	end
```
The user is a playing the plumber.
The event e here has e.getKeyChar()="c".
Note that the Pipe has become the selectedPipe.
This also includes picking up an end of pipe at a cistern.

### 1.2 Connect New Pipe
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: connectNewPipe()
    alt location is ActiveElement
        Plumber->>Location: addNeighbor(carryPipe)
    else 
        Plumber-->>User: "You can connect a New Pipe here!"
    end
```

### 2. Fix Grid :: Fix Broken Pump :: Repair Leaking Pipe
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: fix()
    alt location is Pump
        Plumber->>Location: fix()
    else location is Pipe
	    Plumber->>Location: fix()
    else location is Cistern
        Plumber-->>User: "You can't fix a cistern!"
    else location is Spring
        Plumber-->>User: "You can't fix a spring!"
    end
```
The event e here has e.getKeyChar()="f".

### 3. Change Pump Direction
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: fixPump()
    alt location is Pump
        Plumber->>Location: changeDirection()
    else location is Pipe
	    Plumber-->>User: "You can't change the direction Pipe!"
    else location is Cistern
        Plumber-->>User: "You can't change the direction of cistern!"
    else location is Spring
        Plumber-->>-User: "You can't change the direction of spring!"
    end
```
The event e here has e.getKeyChar()="d"

### 4. Insert Pump
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Plumber: keyTyped(e)
	alt carryPump!=null
		alt location is pipe
			create participant NewPipe
			Plumber->>NewPipe: new Pipe()
			Plumber->>+Location: getNeighbors()
			Location->>-Plumber: pumps
			Plumber->>carryPump: setInPipe(newPipe)
			Plumber->>carryPump: setOutPipe(Location)
			Plumber->>carryPump: addPlayer(this)
			Plumber->>Location: removeNeighbor(pumps.at(1))
			Plumber->>Location: addNeighbor(carryPump)
			Plumber->>Location: removePlayer(this)
			Plumber->>NewPipe: addNeighbor(carryPump)
			Plumber->>NewPipe: addNeighbor(pumps.get(1))
		else
			Plumber-->>User: "You cant insert a Pump here!"
		end
    else carryPump=null
		Plumber-->>-User: "You have no pump!"
	end
	
```
The event e here has e.getKeyChar()="i"

### 5.1 Pick Up Pump
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: pickPump()
    alt location is Cistern
        Plumber->>+Location: getPump()
        alt empty
			Location-->>Plumber: Pump
        else 
	        Location-->>-Plumber: "Not More Pumps"
        end
    else 
        Plumber-->>-User: "You are not at the cistern!"
    end
```
### 5.2 Pick up New Pipe at Cistern 
```mermaid
sequenceDiagram
    actor User as Plumber
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: pickPipe()
    alt location is Cistern
        Plumber->>+Location: getPipe()
        alt empty
			Location-->>Plumber: Pipe
        else 
	        Location-->>-Plumber: "Not More Pipes"
        end
    else 
        Plumber-->>-User: "You are not at the cistern!"
    end

```

The event e here has e.getKeyChar()="p"
### 6. Puncture Pipe
```mermaid
sequenceDiagram
    actor User as Saboteur
    User->>+Plumber: keyTyped(e)
    Plumber->>Plumber: puncturePipe()
    alt location is a pipe
	    Plumber->>location: puncture()
    else 
        Plumber-->>-User: "You can only punctire Pipes!"
    end
    
```
The event e here has e.getKeyChar()="p"

### 7. Move
```mermaid
sequenceDiagram
    actor User as Player
    User->>+Element: onMouseClick()
    Element->>-Grid: setSelectedElement(this)
    User->>+Player: keyTyped(e)
    Player->>Player: move()
    Player->>+Grid: getSelectedElement()
	Grid-->>-Player: Element
	Player->>+Location: isConnected(Element)
    alt yes
	    Location-->>Player: True 
	    Player->>Element:addPlayer(this)
	    Player->>Location:removePlayer(this)
    else no
	    Location-->>-Player: Flase 
        Player-->>-User: "The destination is too far"
    end
```

The event e here has e.getKeyChar()="m"

### 8. Calculation :: Leakage of water
```mermaid
sequenceDiagram
	Main->>+Grid: caculateFlow();
	loop through ActiveElements
        Grid->>-ActiveElement: Flow()
    end
```
if ActiveElement is a Spring
```mermaid
sequenceDiagram
    Grid->>+Spring: Flow()
	loop through neighbors
	    Spring->>-Pipe: fill()
	end
```
if ActiveElement is a Pump
```mermaid
sequenceDiagram
	participant Grid
    participant Pump
    participant Reservoir
    participant PipeIn
    participant PipeOut
    Grid->>Pump: Flow()
	Pump->>PipeIn: isFull()
    alt in Pipe is full
        PipeIn-->>Pump: True
        PipeIn->>PipeIn: empty()
        alt if Pump is BROKEN
            Pump->>Reservoir: addWater()
        else
            Pump->>PipeOut: fill()
        end
	else if Pump is Not Broken 
		PipeIn-->>Pump: False
		alt Reservoir not empty
            Pump->>Reservoir: removeWater()
            Pump->>PipeOut: fill()
        end
    end
```
if ActiveElement is a Cistern
```mermaid
sequenceDiagram
	participant Grid
    participant Element as Cistern
    participant Pipe
	Grid->>Element: Flow()
    loop through neighbors
        Element->>Pipe: isFull()
        alt Pipe is full
	        Pipe-->>Element: True
            Element->>Pipe: empty()
            Element->>Element: addWater()
        else
	        Pipe-->>Element: False
        end
	        
    end

    loop through newPipes
        Element->>Element: removeWater()
    end
```


### 9. Start game
```mermaid
sequenceDiagram
	actor Player
	participant Main
	Player->>Main: void main(String[] args)
	create participant Menu
	Main->>Menu: menu()
	Main->>Menu: setStartGameFunction(startGame)
	Player->>Menu: "Clicks on the Start Game Button"
	Menu-->>Main: startGame()
```
### 10. Select Teams :: Main Loop
```mermaid
sequenceDiagram
	actor Player
    Player->>PlayresCollection: add(Player)
    Player->>PlayresCollection: remove(Player)
```

```mermaid
sequenceDiagram
	Main->>+Main: mainLoop()
    loop until game timer ends
        Main->+PlayresCollection: selectRandom()
        PlayresCollection-->>-Main: random player
        Main->>Player: active()
        loop until player timer ends
	        Note right of Main: timer ends here
        end
        Main->>Player: pasive()
    end
    Main->>-Main: endGame()
```
### 11. Change Settings
```mermaid
sequenceDiagram
	actor Player
	Player->>Settings: getSettings(endTime, playerTime)
	Settings-->>Player: endTime, playerTime 
	Player->>Settings: setSettings(endTime, playerTime)
```
### 12. End Game

```mermaid
sequenceDiagram
    Main->>Main: endGame()
    Main->>+Grid: getWaterAtDesert()
    Grid-->>-Main: saboteur result
    Main->>+Grid: getWaterAtCistern()
    Grid->>+Cistern: getWaterAmount()
    Cistern->>-Grid: waterAmount
    Grid-->>-Main: plumber result
    Main->>Main: displayResults()
```

- [x] stepping on the elements (Move)
- [x] puncturing a pipe 
- [x] fixing a pipe
- [x] setting a direction of a pump
- [x] fixing a pump
- [x] pump is broken (not included)
- [x] disconnecting a pipe
- [x] connecting a pipe 
- [x] picking up a pump 
- [x] picking up an end of pipe at a cistern
- [x] putting a pump into a pipe (Add Pump)
- [x] leakage of water (pump transfers the water it possesses into an outgoing pipe, if possible. If this was successful, tries to get water from the incoming pipe, and stores the water into the reservoir.)


5.2.1.1.1
```mermaid
sequenceDiagram
	actor User  as Plumber
	participant Location as Locatoin:Pump
	User->>Plumber:connectPipe()
	
	Plumber->>Grid: getSelectedActiveElement()
	Grid-->>Plumber: Pump
	
	Plumber->>Grid: getSelectedPipe();
	Grid -->>Plumber: Pipe

	Plumber->>Location: isSecoundNeighbor(Pump)
	alt yes
		Location-->>Plumber: True 	
		Plumber->>Location: isConnected(Pipe)
		alt Yes
			Location-->>Plumber: True 	
			Plumber->>Location: removePipe(Pipe)
			Plumber->>Pump: connectPipe(Pipe)
			Plumber->>Plumber: move()
		else No
			Location-->>Plumber: False
			Plumber-->>User: "Pipe is to far away!"
		end
	else no
		Location-->>Plumber: False
		Plumber-->>User: "The selected ActiveElement is too far!"
	end
```

5.2.1.1.2
```mermaid
sequenceDiagram
	actor User  as Plumber
	participant Location as Locatoin:Pump
	User->>Plumber:connectPipe()
	
	Plumber->>User: Choose Active Element: [number]
	User-->>Plumber: Spring [int]
	Plumber->>Grid: setSelectedActveElement(Spring)
	
	Plumber->>User: Choose Pipe: [number]
	User-->>Plumber: Pipe [int]
	Plumber->>Grid: setSelectedPipe(Pipe)
	
	Plumber->>Grid: getSelectedActiveElement()
	Grid-->>Plumber: Spring
	
	Plumber->>Grid: getSelectedPipe();
	Grid -->>Plumber: Pipe

	Plumber->>Location: isSecoundNeighbor(Spring)
	alt yes
		Location-->>Plumber: True 	
		Plumber->>Location: isConnected(Pipe)
		alt Yes
			Location-->>Plumber: True 	
			Plumber->>Location: removePipe(Pipe)
			Plumber->>Spring: connectPipe(Pipe)
			Plumber->>Plumber: move()
		else No
			Location-->>Plumber: False
			Plumber-->>User: "Pipe is to far away!"
		end
	else no
		Location-->>Plumber: False
		Plumber-->>User: "The selected ActiveElement is too far!"
	end
```

```mermaid
sequenceDiagram
    actor U as Player
    %%Player
    participant P as Plumber
    %%Grid
    participant G as Grid  
    %%Location
    participant L as Location:Pipe/Spring/Cistern 
    %%Destination
    participant D as Pipe
    
    U->>+P: move()
    
    P->>+G: getSelectedElement()
	G-->>-P: Pipe
	
	P->>+L: isConnected(Pipe)
	L->>+U: Is the spring connected to the pipe? [y]es\[n]o
    alt yes
	    U-->>L: y 
	    L-->>P: true
	    P->> U: Is the pipe free of players?
		alt yes
			U-->>P: y
		    P->>D: addPlayer(Plumber)
		    P->>L:removePlayer(Plumber)
		else no
			U-->>P: n
			P->>U:"The pipe has players standing on it!"
		end
    else no
	    U-->>-L: n
	    L-->>-P: false
	    P-->>-U: "The destination is too far!"
    end
```

5.2.14.1. Adding Player into the Plumber/Saboteur team of the game
```mermaid
sequenceDiagram
    participant User
    participant System as Main
    participant P as PlayersCollection
    
    System ->> +User:  "Select the team: [P]lumber/[S]aboteur"
    User -->> -System: [P/S]
    
    System ->> +User: Enter the name of the 1st plumber/saboteur
    User -->> -System: [string]
    
    create participant Player1
	System ->> Player1: Player([string])
    System ->> P: add(Player1)
    
    
    
    System ->>+ User: Enter the name of the 2nd plumber/saboteur
    User -->>-System: [string]
    
    System ->>+ User: Is [string] added before? [y]es/[n]o
    alt yes
	    User -->> System: y
	    System ->> User: The name has been added before
	else no
	    User -->> -System: n
	    create participant Player2
		System ->> Player: Player([string])
	    System ->> P: add(Player2)

	end
	System ->> +User: Do you want to add more players?[y]es/[n]o
	alt yes
	    User ->> System: y
	    System ->> User: Enter the name of the 3nd plumber/saboteur
	    User ->> System: [string]
	    System ->> User: Is [string] added before? [y]es/[n]o
	    alt yes
		    loop  this loops over an over
			    System ->>  User: Do you want to add more players?[y]es/[n]o
		    end
		else no
		    User ->> System: n
		end
	else no
		User ->> -System: n
	end
```