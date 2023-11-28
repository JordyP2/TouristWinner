using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplicitContentDetection
{
    public const string TAG = "Explicit Content Detection";

    public ExplicitContentResponses[] responses;

    public class ExplicitContentResponses
    {
        public SafeSearchAnnotation safeSearchAnnotation;
    }

    public class SafeSearchAnnotation
    {
        public string adult;
        public string spoof;
        public string medical;
        public string violence;
        public string racy;
    }
}
