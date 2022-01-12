using BowlingBall.Enum;
using BowlingBall.Pin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frame
{
    public class Frame : IFrame
    {
        public int frameNo { get; set; }
        public FrameScore frameScore { get; set; }
        public FrameType frameType { get; set; }
        public virtual int GetFrameScore(IFrame currentFrame, List<IFrame> lstFrame)
        {
            return currentFrame.frameScore.firstPinScore + currentFrame.frameScore.secondPinScore;
        }
    }
}
