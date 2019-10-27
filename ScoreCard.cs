using System;
using System.Collections.Generic;

namespace BowlingScoreKeeperCSharp
{  
    public class ScoreCard
    {
        public ScoreCard(IEnumerable<Player> players)
        {
            // go through each player in array
            foreach (var player in players)
            {
                // get player's game
                var game = player.Game;
					    
                // get player's frames of the game
                var gameFrames = game.AllFrames;
					    
                // instead of frame score, we should show the game score in each frame
                var frames = RecalculateResults(gameFrames);
					    
                // draw the score cards
                Console.WriteLine();
                Console.WriteLine("PLAYER " + player.Name);
                Console.WriteLine("___________ ___________ ___________ ___________ ___________ ___________ ___________ ___________ ___________ ___________");
                Console.WriteLine("|    |    | |    |    | |    |    | |    |    | |    |    | |    |    | |    |    | |    |    | |    |    | |    |    |");
                Console.WriteLine("| " + FormatScore(frames[0], true) + " | " + FormatScore(frames[0], false) + " | | " + FormatScore(frames[1], true) + " | " + FormatScore(frames[1], false) + " | | " + FormatScore(frames[2], true) + " | " + FormatScore(frames[2], false) + " | | " + FormatScore(frames[3], true) + " | " + FormatScore(frames[3], false) + " | | " + FormatScore(frames[4], true) + " | " + FormatScore(frames[4], false) + " | | " + FormatScore(frames[5], true) + " | " + FormatScore(frames[5], false) + " | | " + FormatScore(frames[6], true) + " | " + FormatScore(frames[6], false) + " | | " + FormatScore(frames[7], true) + " | " + FormatScore(frames[7], false) + " | | " + FormatScore(frames[8], true) + " | " + FormatScore(frames[8], false) + " | | " + FormatScore(frames[9], true) + " | " + FormatScore(frames[9], false) + " |");
                Console.WriteLine("|    |____| |    |____| |    |____| |    |____| |    |____| |    |____| |    |____| |    |____| |    |____| |    |____|");
                Console.WriteLine("|         | |         | |         | |         | |         | |         | |         | |         | |         | |         |");
                Console.WriteLine("|   " + FormatResultScore(frames[0].FrameScore) + "   | |   " + FormatResultScore(frames[1].FrameScore) + "   | |   " + FormatResultScore(frames[2].FrameScore) + "   | |   " + FormatResultScore(frames[3].FrameScore) + "   | |   " + FormatResultScore(frames[4].FrameScore) + "   | |   " + FormatResultScore(frames[5].FrameScore) + "   | |   " + FormatResultScore(frames[6].FrameScore) + "   | |   " + FormatResultScore(frames[7].FrameScore) + "   | |   " + FormatResultScore(frames[8].FrameScore) + "   | |   " + FormatResultScore(frames[9].FrameScore) + "   |");
                Console.WriteLine("|_________| |_________| |_________| |_________| |_________| |_________| |_________| |_________| |_________| |_________|");
                Console.WriteLine("GAME SCORE (including bonus throw(s)): " + game.GameScore);
                Console.WriteLine();
            }
        }
        
        private static string FormatResultScore(int score) 
        {
            string formattedString;

            if (score > 99)
            {
                formattedString = score.ToString();
            }
            else if (score > 9)
            {
                formattedString = " " + score;
            }
            else
            {
                formattedString = "  " + score;
            }

            return formattedString;
        }

        private static string FormatScore(Frame frame, bool isFirstThrow) 
        {
            string formattedString;

            var score = isFirstThrow ? frame.FirstThrow : frame.SecondThrow;
			
            if (score != 10)
            {
                formattedString = " " + score;
            }
            else
            {
                formattedString = score.ToString();
            }
			
            if (frame.FirstThrow == 10 && !isFirstThrow)
            {
                formattedString = " X";
            }
            else if (frame.FirstThrow + frame.SecondThrow == 10 && !isFirstThrow)
            {
                formattedString = " /";
            }
			
            return formattedString;
        }
        
        private static Frame[] RecalculateResults(IReadOnlyList<Frame> frames) 
        {
            var recalculateFrames = new Frame[10];
            var score = 0;
			
            for (var i = 0; i < frames.Count; i++)
            {
                recalculateFrames[i] = frames[i];
				
                score += frames[i].FrameScore;
                recalculateFrames[i].FrameScore = score;
            }
			
            return recalculateFrames;
        }
    }
}