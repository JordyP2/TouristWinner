using static Borders;

public class LogosDetection
{
    public const string TAG = "Logos Detection";

    public LogosResponses[] responses;

    public class LogosResponses
    {
        public LogoAnnotations[] logoAnnotations;
    }

    public class LogoAnnotations
    {
        public string description;
        public float score;
        public Border boundingPoly;
    }
}
