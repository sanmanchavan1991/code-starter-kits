using BowlingBall.Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class FrameFactory
    {
        IFrame frame = null;
        int[] row = null;
        public FrameFactory(int[] row, int rowNo)
        {
            this.row = row;
            this.frame = new BowlingBall.Frame.Frame()
            {
                frameNo = rowNo,
                frameScore = new Pin.FrameScore
                {
                    firstPinScore = row[0],
                    secondPinScore = row[1]
                },
            };


        }
        private void RecifyFrame()
        {
            if (frame.frameNo == 10)
            {
                frame.frameType = Enum.FrameType.LastFrame;

            }
            else if (
               (frame.frameScore.firstPinScore == 0 && frame.frameScore.secondPinScore == 0) ||
               frame.frameScore.firstPinScore + frame.frameScore.secondPinScore < 10
                )
            {
                frame.frameType = Enum.FrameType.NormalFrame;
            }
            else if (
                frame.frameScore.firstPinScore == 10 && frame.frameScore.secondPinScore == 0
                )
            {
                frame.frameType = Enum.FrameType.StrikeFrame;
            }
            else if (frame.frameScore.firstPinScore + frame.frameScore.secondPinScore == 10)
            {
                frame.frameType = Enum.FrameType.SpareFrame;
            }
        }

        private void AssignValueToObject(IFrame currentFrameObj)
        {
            currentFrameObj.frameNo = frame.frameNo;
            currentFrameObj.frameType = frame.frameType;
            currentFrameObj.frameScore = new Pin.FrameScore
            {
                firstPinScore = frame.frameScore.firstPinScore,
                secondPinScore = frame.frameScore.secondPinScore
            };
        }
        public IFrame CreateFrame()
        {
            RecifyFrame();
            IFrame createdFrame = null;
            switch (frame.frameType)
            {
                case Enum.FrameType.LastFrame:
                    createdFrame = new LastFrame() {
                        frameNo = frame.frameNo,
                        frameType= frame.frameType,
                        frameScore = new Pin.FrameScore
                        {
                            firstPinScore = frame.frameScore.firstPinScore,
                            secondPinScore = frame.frameScore.secondPinScore
                        },
                        thirdPinScore = row[2]
                    };
                    break;
                case Enum.FrameType.StrikeFrame:
                    createdFrame = new StrikeFrame();
                    AssignValueToObject(createdFrame);
                    break;
                case Enum.FrameType.SpareFrame:
                    createdFrame = new SpareFrame();
                    AssignValueToObject(createdFrame);
                    break;
                case Enum.FrameType.NormalFrame:
                    createdFrame = new BowlingBall.Frame.Frame();
                    AssignValueToObject(createdFrame);
                    break;
            }
            return createdFrame;
        }
    }
}
