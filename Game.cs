using System;
using System.Linq;

namespace BowlingScoreKeeperCSharp
{
    public class Game
    {
        private readonly string _playerName;
        public int GameScore { get; private set; }
        public Frame[] AllFrames { get; }
        
        public Game(string playerName) 
        {
            // The game consists of 10 frames
            AllFrames = new Frame[10];
            _playerName = playerName;
			
            SubmitScores();
        }
        
        /**
         * Calculate the game score
         */
        private int GetGameScore()
        {
            return AllFrames.Sum(frame => frame.FrameScore);
        }
        
        /**
         * Re-calculate scores for the frames with strikes
         */
        private void RecalculateStrikes() 
        {
            var frameLength = AllFrames.Length;
			
            // make a loop to read scores of each frame
            for (var i = 0; i < frameLength; i++)
            {
                // if first throw equals to 10, it is a strike
                // we cannot calculate the score of the last strike frame in this method
                if (AllFrames[i].FirstThrow != 10 || i == frameLength - 1) continue;

                // if it's a strike, add to the frame score the score of the next frame
                var frameScore = AllFrames[i].FrameScore + AllFrames[i + 1].FrameScore;

                AllFrames[i].FrameScore = frameScore;
            }
        }
        
        /**
         * Re-calculate scores for the frames with spares
         */
        private void RecalculateSpares() 
        {
            var frameLength = AllFrames.Length;
			
            // make a loop to read scores of each frame
            for (var i = 0; i < frameLength; i++) 
            {
                var firstThrow = AllFrames[i].FirstThrow;
                var secondThrow = AllFrames[i].SecondThrow;
				 
                // if summing the first and the second throws we get 10, it is a spare
                // the first throw should be less than 10, otherwise it is a strike
                // we cannot calculate the score of the last spare frame in this method
                if (firstThrow + secondThrow != 10 || firstThrow == 10 || i == frameLength - 1) continue;
            
                // if it's a spare, add the first throw of the next frame to the frame score
                var frameScore = AllFrames[i].FrameScore + AllFrames[i + 1].FirstThrow;

                AllFrames[i].FrameScore = frameScore;
            }
        }
        
        /**
         * Give a player a bonus throw and return a bonus score
         */
        private int StrikeOnLastFrame() 
        {
            var bonusFirstThrow = 0;
            var bonusSecondThrow = 0;

            try
            {
                Console.Write(_playerName + " has a bonus throw #1: ");
                bonusFirstThrow = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                Console.Write(_playerName + " has a bonus throw #2: ");
                bonusSecondThrow = int.Parse(Console.ReadLine() ?? throw new FormatException());

            }
            catch (FormatException)
            {
                Console.WriteLine("The value must be numeric.");
            }
            catch (Exception e) 
            {
                Console.WriteLine("Exception: " + e);
            }

            return bonusFirstThrow + bonusSecondThrow;
        }
        
        /**
         * Give a player a bonus throw and return a bonus score
         */
        private int SpareOnLastFrame() 
        {
            var bonusThrow = 0;
			
            try 
            {
                Console.Write(_playerName + " has a bonus throw: ");
                bonusThrow = int.Parse(Console.ReadLine() ?? throw new FormatException());
            }
            catch (FormatException)
            {
                Console.WriteLine("The value must be numeric.");
            }
            catch (Exception e) 
            {
                Console.WriteLine("Exception: " + e);
            }
            
            return bonusThrow;
        }
        
        /**
         * Submit scores
         */
        private void SubmitScores() 
        {
            var frameLength = AllFrames.Length;
            var bonusScore = 0;
	            
            try 
            {
                // create a loop to go through each frame
                for (var i = 0; i < frameLength; i++) 
                {
                    int firstThrow;
                    int secondThrow;
                    
                    // throws are NUMBERS and should be less or equal to 10
                    do
                    {
                        Console.Write("Player " + _playerName + ", please enter your score for the 1 ball of frame " + (i + 1) + ": ");
                        firstThrow = int.Parse(Console.ReadLine() ?? throw new FormatException());
	        		    
                        // if it's a strike, it is not necessary to throw the second ball
                        if (firstThrow == 10) 
                        {
                            secondThrow = 0;
                            Console.WriteLine("Player " + _playerName + " has strike.");
                        }
                        else 
                        {
                            Console.Write("Player " + _playerName + ", please enter your score for the 2 ball of frame " + (i + 1) + ": ");
                            secondThrow = int.Parse(Console.ReadLine() ?? throw new FormatException());
                        }
                    } 
                    while (firstThrow > 10 || secondThrow > 10 || firstThrow + secondThrow > 10); 

                    var frame = new Frame
                    {
                        FirstThrow = firstThrow,
                        SecondThrow = secondThrow,
                        FrameScore = firstThrow + secondThrow
                    };

                    AllFrames[i] = frame;
                }
	        	    
                // if there were strikes, the score should be recalculated
                RecalculateStrikes();
	        	    
                // if there were spares, the score should be recalculated
                RecalculateSpares();
	        	    
                // bonus throws for a strike or a spare on the final frame
                if (AllFrames[frameLength - 1].FirstThrow == 10)
                {
                    bonusScore = StrikeOnLastFrame();
                }
                else if (AllFrames[frameLength - 1].FirstThrow + AllFrames[frameLength - 1].SecondThrow == 10)
                {
                    bonusScore = SpareOnLastFrame();
                }
	        	    
            }
            catch (FormatException)
            {
                Console.WriteLine("The value must be numeric.");
            }
            catch (Exception e) 
            {
                Console.WriteLine("Exception: " + e);
            }

            // count the game score including bonus throws
            GameScore = GetGameScore() + bonusScore;
        }
    }
}