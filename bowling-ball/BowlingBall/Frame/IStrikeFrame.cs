namespace BowlingBall.Frame
{
    public interface IStrikeFrame :IFrame
    {
        bool isDoubleStrike { get; set; }
        bool isTripleStrike { get; set; }
        int nextFrameNo { get; set; }

    }
}