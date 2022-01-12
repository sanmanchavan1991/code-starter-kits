using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frame
{
    public class StrikeFrame : Frame, IStrikeFrame
    {
        public int nextFrameNo { get; set; }
        public bool isDoubleStrike { get; set; }
        public bool isTripleStrike { get; set; }
       
        private IStrikeFrame ConvertToStrike(IFrame currentFrame)
        {
            return (StrikeFrame)currentFrame;
        }
        private int GetBonus(IStrikeFrame strikeFrame, List<IFrame> lstFrame,int start,int limit)
        {
            int bonus = 0;
            IFrame nextFrameStrike = lstFrame.Where(i => i.frameNo == (strikeFrame.frameNo + 1) && i.frameType == Enum.FrameType.StrikeFrame).FirstOrDefault();
            if (nextFrameStrike != null)
            {
                IStrikeFrame nextStrikeFrame = ConvertToStrike(nextFrameStrike);
                bonus = nextStrikeFrame.frameScore.firstPinScore;
                if (start < limit)
                {
                    bonus += GetBonus(nextStrikeFrame, lstFrame, start: nextStrikeFrame.frameNo+1, limit: limit);
                }
            }
            else
            {
                IFrame nextFrameSpear = lstFrame.Where(i => i.frameNo == (strikeFrame.frameNo + 1)).FirstOrDefault();
                bonus = nextFrameSpear.frameScore.firstPinScore + nextFrameSpear.frameScore.secondPinScore;

            }
            return bonus;
        }
        public override int GetFrameScore(IFrame currentFrame, List<IFrame> lstFrame)
        {
            IStrikeFrame strikeFrame= ConvertToStrike(currentFrame);
            int bonus = GetBonus(strikeFrame,lstFrame, start:strikeFrame.frameNo+1, limit:strikeFrame.frameNo+2);
            int sum = strikeFrame.frameScore.firstPinScore+ bonus;
            return sum;
        }
    }
}
