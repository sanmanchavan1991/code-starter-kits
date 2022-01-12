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
       
        
        private int GetBonus(IFrame frame, List<IFrame> lstFrame,int start,int limit)
        {
            int bonus = 0;
            IFrame nextFrameStrike = lstFrame.Where(i => (i.frameNo == (frame.frameNo + 1) && i.frameType == Enum.FrameType.StrikeFrame)
            || (i.frameNo == (frame.frameNo + 1) && i.frameType == Enum.FrameType.LastFrame && i.frameScore.firstPinScore == 10 )).FirstOrDefault();

            //last frame && second strike
            IFrame nextFrameLast = lstFrame.Where(i => i.frameNo == (frame.frameNo ) && i.frameType == Enum.FrameType.LastFrame && (i.frameScore.firstPinScore == 10|| i.frameScore.secondPinScore == 10)).FirstOrDefault();

            if (nextFrameStrike != null)
            {
                bonus = nextFrameStrike.frameScore.firstPinScore;
                if (start < limit)
                {
                    bonus += GetBonus(nextFrameStrike, lstFrame, start: nextFrameStrike.frameNo + 1, limit: limit);
                }
            }
			else if (nextFrameLast != null)
			{
				bonus = nextFrameLast.frameScore.secondPinScore;
			}
			else
            {
                IFrame nextFrameSpear = lstFrame.Where(i => i.frameNo == (frame.frameNo + 1)).FirstOrDefault();
                bonus = nextFrameSpear.frameScore.firstPinScore + nextFrameSpear.frameScore.secondPinScore;

            }
            return bonus;
        }
        public override int GetFrameScore(IFrame currentFrame, List<IFrame> lstFrame)
        {
            int bonus = GetBonus(currentFrame, lstFrame, start: currentFrame.frameNo+1, limit: currentFrame.frameNo+2);
            int sum = currentFrame.frameScore.firstPinScore+ bonus;
            return sum;
        }
    }
}
