
What is a packet sniffer? #flashcard 
***packet sniffer***: The basic tool for observing the messages exchanged between executing protocol entities.
<!--ID: 1710367167879-->


What can the packet sniffer store and/or display? #flashcard 
***Protocol fields*** in the captured messages
<!--ID: 1710367167884-->


What is a property of a packet sniffer? #flashcard 
It is passive: 
- it doesn't sent packages itself
- received packets are never explicitly addressed to the sniffer.
<!--ID: 1710367167889-->


What kind of packets does the packet sniffer receive? #flashcard 
Instead, a packet sniffer receives a copy of packets that are sent/received from/by application and protocols executing on your machine.
<!--ID: 1710367167893-->


What are the parts of the packet sniffer? #flashcard 
- ***packet capture library***:
	- receives a copy of every link-layer frame that is sent from or received by your computer over a given interface (link layer, such as Ethernet or WiFi).
- ***packet analyzer***:
	- displays the contents of all fields within a protocol message
<!--ID: 1710367167898-->


Which layer does the packet sniffer capture and why? #flashcard 
- The link layer:
Because:
- link-layer frames encapsulate all high level protocols.
- Capturing all link-layer frames thus gives you all messages sent/received across the monitored link from/by all protocols and applications executing in your computer.
<!--ID: 1710367167902-->


sExplain the layers in a packet? #flashcard 
Ethernateframe(IP datagram(TCP(HTTP)))
<!--ID: 1710367167907-->


What is Wireshark? #flashcard 
network protocol analyzer
<!--ID: 1710367167912-->




### Questions
Protocols running on your computer? 

### Notes
link-layer frames, network-layer datagrams, transport-layer segments

- The protocol type field lists the highest-level protocol that sent or received this packet, i.e., the protocol that is the source or ultimate sink for this packet.