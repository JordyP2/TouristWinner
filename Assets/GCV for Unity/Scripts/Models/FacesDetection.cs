using static Borders;

public class FacesDetection
{
    public const string TAG = "Faces Detection";

	public FaceResponses[] responses;

	public class FaceResponses
    {
		public FaceAnnotations[] faceAnnotations;
	}

	public class FaceAnnotations
    {
		public Border boundingPoly;
	}
}
