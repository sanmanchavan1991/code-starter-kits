using BowlingBall.Pin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frame
{
    public class SpareFrame : Frame 
    {
        public int nextFrameNo { get; set; }
        public override int GetFrameScore(IFrame currentFrame, List<IFrame> lstFrame)
        {
            IFrame nextFrame = lstFrame.Where(i => i.frameNo == (currentFrame.frameNo + 1)).FirstOrDefault();
            int sum = 0;
            sum = currentFrame.frameScore.firstPinScore + currentFrame.frameScore.secondPinScore+ nextFrame.frameScore.firstPinScore;
            return sum;
        }
    }
}
