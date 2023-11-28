using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Borders;

public class MultipleObjectsDetection
{
    public const string TAG = "Multiple Objects Detection";

    public MultipleObjectsResponses[] responses;

    public class MultipleObjectsResponses
    {
        public LocalizedObjectAnnotations[] localizedObjectAnnotations;
    }

    public class LocalizedObjectAnnotations
    {
        public string name;
        public float score;
        public BorderNormalized boundingPoly;
    }
}
