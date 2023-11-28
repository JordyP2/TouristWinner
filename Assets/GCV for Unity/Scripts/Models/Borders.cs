using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders
{
    public class Border
    {
        public Vertices[] vertices;
    }

    public class BorderNormalized
    {
        public Vertices[] normalizedVertices;
    }

    public class Vertices
    {
        public float x;
        public float y;
    }
}
