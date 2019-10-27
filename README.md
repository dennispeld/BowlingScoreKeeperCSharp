# Bowling Score Keeper C#
The *BowlingScoreKeeper* console app was written in C# language using .NET Core 2.2 and JetBrains Rider. 

Added new validation that checks if both bowls for each frame are less or equal to 10. The score cards are also updated with new format.

### The logic of Score Keeper is very simple:
* Each player has one game
* The game consists of 10 frames
* Each frame has 2 throws and a score
* You call StartApp to begin the program
* You call ScoreCard to show the results

### Tested combinations (one player):
NORMAL   [1, 5] [3, 6] [7, 2] [3, 6] [4, 4] [5, 3] [3, 3] [4, 5] [8, 1] [2, 6] is 81  
STRIKE  [10, 0] [3, 6] [7, 2] [3, 6] [4, 4] [5, 3] [3, 3] [4, 5] [8, 1] [2, 6] is 94  
SPARE   [1, 9] [3, 6] [7, 2] [3, 6] [4, 4] [5, 3] [3, 3] [4, 5] [8, 1] [2, 6] is 88  
STRIKE & SPARE  [10, 0] [4, 6] [7, 2] [3, 6] [4, 4] [5, 3] [3, 3] [4, 5] [8, 1] [2, 6] is 103  
STRIKE AS THE LAST FRAME [1, 5] [3, 6] [7, 2] [3, 6] [4, 4] [5, 3] [3, 3] [4, 5] [8, 1] [10, 0] is 92 (last throws are [7, 2])  
SPARE AS THE LAST FRAME [1, 5] [3, 6] [7, 2] [3, 6] [4, 4] [5, 3] [3, 3] [4, 5] [8, 1] [2, 8] is 90 (last throw is 7)

### Usage
1. Clone the project
2. Run the Main method of Program.cs file
3. Type the number of players
4. Type the name of each player
5. Input values for each frame
6. Observe the score cards

Author: Dennis Peld  
Language: C#, .NET Core 2.2  
Environment: JetBrains Rider