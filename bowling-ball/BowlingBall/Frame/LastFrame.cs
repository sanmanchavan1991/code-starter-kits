using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frame
{
    public class LastFrame : Frame, ILastFrame
    {
        public int thirdPinScore { get; set; }
        private ILastFrame lastFrame;

        private void ConvertToLast(IFrame currentFrame)
        {
            lastFrame = (LastFrame)currentFrame;
        }
        public override int GetFrameScore(IFrame currentFrame, List<IFrame> lstFrame)
        {
            ConvertToLast(currentFrame);
            return lastFrame.frameScore.firstPinScore + lastFrame.frameScore.secondPinScore + lastFrame.thirdPinScore;
        }
    }
}
