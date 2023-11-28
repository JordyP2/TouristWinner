using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Borders;

public class LandmarksDetection
{
    public const string TAG = "Landmarks Detection";

    public LandmarkResponses[] responses;

    public class LandmarkResponses
    {
        public LandmarkAnnotations[] landmarkAnnotations;
    }

    public class LandmarkAnnotations
    {
        public string description;
        public float score;
        public Border boundingPoly;
    }
}
