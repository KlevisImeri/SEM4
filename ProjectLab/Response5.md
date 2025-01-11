The responses are short so we don't waste your time.

---
1. `The use case diagram contains the needed use cases; it is complex.`
It is complex because we include many cases. It may look compelling, but if you try to decompose it, it's actually pretty simple. It looks big because of the application start use case.
---
2. `Regarding their sequence, I would have put the “start application” “start game “ in the beginning, and follow a sequence that would guide doing the tests.`
If you think about the testers, then this looks logical, but if you look at the structure from the requirements to the design, the flow is this way. The "start application" and "start game" have always been to the end. Furthermore, nowhere was it mentioned that they should be ordered in any way. Therefore, we think ***this point is invalid***.
---
3. `There use cases remained at a high level, it is difficult to understand them as test cases. For instance: “The plumber/saboteur moves from pump/spring/cistern to pipe” – will be hard to the tester to understand exactly which case is under test. I understand that you have the Remarks in 5.2, where you explain your approach. However, I would have kept separately some of the cases to make tests easier.`
Here we ***strongly disagree***. In the skeleton program each one of these test cases has its own setup. In one the setup is done with pump in the other with spring and so one. They are different use cases for which each on of them the application has a setup to test it. They are just compressed into one because the results in the screen are similar and small parts change which are also explicitly explained in the dialogs. A normal intelligent human tester should be able to understand it fairly quick and simply. Therefore, we think ***this point is invalid***.
---
4. `You have the test cases more in the sequence diagrams; I cannot find a precise connection between the sequence diagrams and the use cases / dialogues.`
Here we ***strongly disagree***. We actually are not able to understand how you can't see the connection, so we think this should be ***discussed in person***. The diagrams are precisely made from the dialogs. Also, we politely ask to explain what the first sentence here means. Is there a typo?.
---
5. `Please think of the following - can they be tested based on your description?`
Yes they can be precisely tested. We can discuss this on class.
---
6. `„The Plumber inserts the pump at a pipe” – which use case is this and in which dialogue is it described?`
This is use case 5.2.5.1, the first one in section 5.2.5, which is mistakenly written as 5.2.4.1. If the document was read carefully, this could have been easily spotted. This also has the sequence diagram of 5.2.5.1, which was mistakenly written as 5.2.4.1. (There are two 5.2.4.1. You can just read the tile to see that they are different and find the specific use case. You may have used the numbers but the tiles are more precise).
---
7. `Are cases like these possible based on your description: "the sabouteur steps to a pipe and punctures it; water is leaked. Plumber steps to pipe that is broken and fixes it. Plumber and saboteur step on the same pipe."
Yes these use cases are tested and included in our use cases ***(5.2.8.1, 5.2.3.1)***. In person we can explain where each one of them is included. For the "Plumber and saboteur step on the same pipe" this can't even happen cause there can be only one person in the pipe. This is precisely stated in the problem definition. ***We test that this can't happen in 5.2.9.2!***.
---
8. `“At the beginning every method writes its name on the screen and calls the methods he needs to fulfil his service.” – I hope this is so in each case.`
Please, just read the document! Every method rights its name on the screen and calls the other methods.
---
9. `This is a good moment to revisit the requirements of Requirements (document "https://www.iit.bme.hu/system/files/uploads/module_files/e_templ_02-req_0.doc". Requirements formulated there should be followable in the design, code and test cases!`
They are! That is why the use cases are ordered like we ordered them. 

 > [!warning]
Considering the reasons mentioned, our team collectively concludes that none of the arguments presented were valid. Consequently, we find the removal of two points to be unjustified.
