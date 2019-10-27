namespace BowlingScoreKeeperCSharp
{
    public class Frame
    {
        public int FirstThrow { get; set; }
        public int SecondThrow { get; set; }
        public int FrameScore { get; set; }
        
        public Frame() 
        {
            FirstThrow = 0;
            SecondThrow = 0;
            FrameScore = 0;
        }
    }
}