# Personal-Project-2
## Overview
I will be building my version of Google Chrome's no-internet dino game. With the creation of a grid system within c#, the 
terminal acts as a game screen––a player uses their space bar to jump to avoid obstacles. If they are found within the same grid 
space as an obstacle, the player dies. The terminal is updated several times per second to simulate player movement, and 
barriers are randomly chosen from a list. 
## High-Level Flowchart: 
- See GameControl for the basics.
![Overview](DinoBrainstorm.png)
## Methods
GameControl: Controls whether the game should continue building or not.
- Build the background
- check if the game is over. 
  - If not, continue building obstacles. 
  - If yes, clear the console and write "Game Over"

UpdateTerminal: Updates the terminal every amount of milliseconds.
- for every x milliseconds
  - use FancyConsole's "Refresh"

ObstacleList: Loads a list of obstacles and chooses one. 
- load in obstacles.txt file  
- create list chosenobstacle
- randomly choose a number less than or equal to the number of indices in txt file divided by three. Make this equal to int randomnumber
- index = 0
  - while this number is less than or equal to itself + 2, copy the index of obstacles.txt corresponding to random number to chosenObstacle.
  - randomNumber = randomNumber + (index + 1).
- when randomNumber > original value of randomNumber + 2, return the list chosenobstacle

BuildBackground: Builds the base image for the game
- foreach column in the terminal
  - write "_" in a certain row

DrawObstacle: Using the chosen obstacle, draws the obstacle in the terminal. It draws a new column every time the terminal refreshes. 
- list obstacleList = method obstacleList
- int place = 0
- foreach index of obstaclelist
  - if index = 3, check if character is a space/empty/null. 
    - if yes, break. This means the obstacle is finished and a new one must be chosen. restart the loop at the list = method.
    - if no, continue;
  - in the index, write the char in the number place listed to the top row + the index, lastcolumn
  - increase place by 1
  - call DrawPlayer 
  - call updateTerminal
  - repeat the loop

DrawPlayer: Draws the player avatar to the correct row
- create character player
- write player to currentRow (playerbehavior()), playingColumn.
Note for this: I have no way currently to remove the last player instance. I'd need to figure out how to save the history of a certain column and then input it where the player has passed every terminal refresh.

GameOver: Checks if the game is over. Lacking complexity needed to actually work in outline. I need to check whether the character the player erased is empty space or another character (obstacle).
- create bool isGameOver = false
- if char in currentRow(playerbehavaior()), playingColumn ≠ " "
  - isGameOver = true
return isGameOver


PlayingColumn, LastColumn, TopRow: These methods initialize variables for the column the player is to play in, the last column of the terminal, and the topmost row that the player can play in / obstacles can be loaded into. Their setup, currently, is the same but will likely change for different terminal sizes. These variables have the potential to be used in several methods, so having them exist outside of a particular method is the best way to go in my opinion.
- int [name]
- return [name]


