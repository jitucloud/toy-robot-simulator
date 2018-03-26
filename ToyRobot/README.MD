Unzip the toy-robot-simulator
===================

STEPS
-----------------
#Goto inside the folder where you can see below two folders
  #ToyRobot
  #ToyRobot.Tests

#Go inside ToyRobot folder to run the solution from command prompt

#open command prompt, type below command and press enter
#CMD> ToyRobot\bin\Debug\ToyRobot.exe

Step 1: Some instruction will be shown how to place and move robot on the table

STEP 2: Place the robot on 5*5 table top.

    CMD> place 2,3,north                      //this will place the robot on specified position
    CMD> report                               //this will report the current position of robot
    CMD> move                                 //this will move the robot 
    CMD> left                                 //robot will turn to its left
    CMD> right                                //robot will turn to its right
    CMD> report                               //robot will report again 
    CMD> place 1,4,south                      //this will again place the robot to new position
    CMD> exit                                 //exit will exist the table

#Scenarios covered:

    First command should be valid place command with correct coordinates and facing

    Robot will never fall from the table top and all invalid commands will be ignored

### valid commands are:

  # place x,y,north|south|east|west, ove,left, right, report, exit
  
Example Input and Output
------------------------

### Example a

    PLACE 0,0,NORTH
    MOVE
    REPORT

Expected output:

    0,1,NORTH

### Example b

    PLACE 0,0,NORTH
    LEFT
    REPORT

Expected output:

    0,0,WEST

### Example c

    PLACE 1,2,EAST
    MOVE
    MOVE
    LEFT
    MOVE
    REPORT

Expected output

    3,3,NORTH




