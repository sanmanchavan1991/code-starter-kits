using BowlingBall.Frame;
using System.Collections.Generic;

namespace BowlingBall.Calculation
{
    public interface IScore
    {
        int GetScore(List<IFrame> frameList);
    }
}