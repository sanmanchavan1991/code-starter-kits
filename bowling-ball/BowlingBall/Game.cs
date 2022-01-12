using BowlingBall.Calculation;
using BowlingBall.Extension;
using BowlingBall.Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game : IGame
    {
        private void Roll(int pins)
        {
            // Add your logic here. Add classes as needed.
        }

        private int GetScore(List<IFrame> frameList)
        {
            // Returns the final score of the game.
            IScore score = new Score();
            return score.GetScore(frameList: frameList);
        }
        public int Run(int[,] rolls)
        {
            List<IFrame> frameList = new List<IFrame>();
            for (int i = 0; i < rolls.GetLength(0); i++)
            {
                IFrame frame = null;
                frame = new FrameFactory(row:rolls.GetRow(i),rowNo:i+1).CreateFrame();
                frameList.Add(frame);
            }
            return GetScore(frameList: frameList);
        }
    }
}
