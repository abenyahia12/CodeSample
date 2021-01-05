Hello !
----------------------------------------------------------------------------------------------------------------------------------------
8 hours the first day:						I finished the part 1 and cleaned it
8 hours the second day:						I finished the second part and did some refactoring and cleaning
4 hours the last day :						I worked on the movement and refactored the state machine to include spacing from allies that are too close and Implemented the UI and its functionality
4 hours the second part of the last day :	I commented the code and tested the whole project over and over

Design patterns I used:
MVC for the (Unit.cs , UnitController.cs, UnitView)
I used one interface for the unit and inherited it, I would of made one for managers , but I didn't see anything in common between them
I used Solid principiles through all of my code
I used a mini state machine in the unit controller

----------------------------------------------------------------------------------------------------------------------------------------
To add a shape or color and change their modifiers, it's simple , you open the scriptable stats obj (Assets\Scripts\ScriptableObjects\Stats) 
ADDING SHAPE:
go to Shape Characteristic , add an element to each of its modifiers and configure them
go to Color Characteristic ,  add to modifier array another row if we are adding a shape and configure its modifiers
ADDING Color:
go to Color Characteristic if we are adding a color we add a new element in each row of the modifier array and configure their modifiers
----------------------------------------------------------------------------------------------------------------------------------------
