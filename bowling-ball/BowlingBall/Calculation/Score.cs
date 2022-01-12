using BowlingBall.Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Calculation
{
    public class Score : IScore
    {
        public int GetScore(List<IFrame> frameList)
        {
            int totalSum = 0;
            for (int i = 0; i < frameList.Count; i++)
            {
                totalSum = totalSum + frameList[i].GetFrameScore(frameList[i], frameList);
            }
            return totalSum;
        }
    }
}
