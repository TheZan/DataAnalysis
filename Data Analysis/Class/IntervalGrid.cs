namespace Data_Analysis.Class
{
    public class IntervalGrid : DiscreteGrid
    {
        public double leftBorder { get; set; }
        public double rightBorder { get; set; }
        new public double accumulatedFrequency { get; set; }
    }
}
