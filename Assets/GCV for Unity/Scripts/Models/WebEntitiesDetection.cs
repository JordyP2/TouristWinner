using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebEntitiesDetection
{
    public const string TAG = "Web Entities Detection";

    public WebEntitiesResponses[] responses;

    public class WebEntitiesResponses
    {
        public WebDetection webDetection;
    }

    public class WebDetection
    {
        public WebEntities[] webEntities;
    }

    public class WebEntities
    {
        public float score;
        public string description;
    }
}
