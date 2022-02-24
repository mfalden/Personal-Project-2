# Personal-Project-2
## Overview
I will be building my version of Google Chrome's no-internet dino game. With the creation of a grid system within c#, the 
terminal acts as a game screen––a player uses their space bar to jump to avoid obstacles. If they are found within the same grid 
space as an obstacle, the player dies. The terminal is updated several times per second to simulate player movement, and 
barriers are randomly chosen from a list. 
## High-Level Flowchart

## Methods






1: CreateObstacleList
- houses a list of obstacles (stored in .txt file––three lines per obstacle) and randomly chooses one. list output. 
2: CreatePlayer 
- loads in player (shown as string) into a set column (maybe 1/4 the way over?) and their movement (i.e 2 space hits, 2 units up). Accepts the player input. 
3: // UpdateTerminal AKA REFRESH + SLEEP
- sets the framerate for the game. Calls BackGround. 
4: SetupGridGround
- sets grid system, flat ground. output list (?)
5: BuildBackGround
- first update: gridGround + first obstacle
- all other updates: remove first column of old backGround, add last column.
6: // CalculateLastColumn AKA WRITE
- forEach char in each string of each line of each list of obstacle, add to new lastColumn every terminalupdate. 
7: DrawColumn
- creates template for each column. 
8: GameOver
- checks if player is in the same grid space as the barrier. If so, then the game is over. Runs with every UpdateTerminal call. 
- also clears the terminal and displays "Game Over."
