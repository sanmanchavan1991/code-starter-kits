using BowlingBall.Frame;
using System.Collections.Generic;

namespace BowlingBall
{
    public interface IGame
    {
        int Run(int[,] rolls);
    }
}