using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelsDetection
{
    public const string TAG = "Labels Detection";

    public LabelsResponses[] responses;

    public class LabelsResponses
    {
        public LabelAnnotations[] labelAnnotations;
    }

    public class LabelAnnotations
    {
        public string description;
        public float score;
        public float topicality;
    }
}
