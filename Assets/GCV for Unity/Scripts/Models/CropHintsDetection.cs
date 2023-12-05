using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Borders;

public class CropHintsDetection
{
    public const string TAG = "Crop Hints Detection";

    public CropHintsResponses[] responses;

    public class CropHintsResponses
    {
        public CropHintsAnnotation cropHintsAnnotation;
    }

    public class CropHintsAnnotation
    {
        public CropHints[] cropHints;
    }

    public class CropHints
    {
        public float confidence;
        public float importanceFraction;
        public Border boundingPoly;
    }
}
