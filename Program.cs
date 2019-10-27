using System;

namespace BowlingScoreKeeperCSharp
{
    internal static class Program
    {
        private static int _numberOfPlayers;
        private static Player[] _playersArray;
        
        private static void Main()
        {
            SetNumberOfPlayers();
            
            _playersArray = new Player[_numberOfPlayers];
		
            for (var i = 0; i < _numberOfPlayers; i++)
            {
                InitPlayer(i);
            }

            var scoreCard = new ScoreCard(_playersArray);

            Console.ReadLine();
        }
        
        private static void SetNumberOfPlayers() 
        {
            try
            {
                // for C# I would use Console.WriteLine() and Console.ReadLine() methods
                Console.WriteLine("Type the number of players: ");
                var nrOfPlayers = Console.ReadLine();
                _numberOfPlayers = int.Parse(nrOfPlayers ?? throw new FormatException());
            }
            catch (FormatException)
            {
                Console.WriteLine("The value must be numeric.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
        }
        
        private static void InitPlayer(int playerNr) 
        {
            try 
            {
                Console.Write("The name of the player #" + (playerNr + 1) + ": ");
                var newPlayer = new Player {Name = Console.ReadLine()};
                newPlayer.Game = new Game(newPlayer.Name);
                _playersArray[playerNr] = newPlayer;
            } 
            catch (Exception e) 
            {
                Console.WriteLine("Exception: " + e);
            }
        }
    }
}