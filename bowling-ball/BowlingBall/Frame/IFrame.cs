using BowlingBall.Enum;
using BowlingBall.Pin;
using System.Collections.Generic;

namespace BowlingBall.Frame
{
    public interface IFrame
    {
        int frameNo { get; set; }
        FrameScore frameScore { get; set; }
        FrameType frameType { get; set; }

        int GetFrameScore(IFrame currentFrame, List<IFrame> lstFrame);
    }
}