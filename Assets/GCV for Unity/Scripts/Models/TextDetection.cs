using static Borders;

public class TextDetection 
{
    public const string TAG1 = "Text Detection";
    public const string TAG2 = "Handwriting Detection";

    public TextResponses[] responses;

    public class TextResponses
    {
        public TextAnnotations[] textAnnotations;
    }

    public class TextAnnotations
    {
        public string locale;
        public string description;
        public Border boundingPoly;
    }
}
