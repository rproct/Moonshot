using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory_render : MonoBehaviour
{
    public LineRenderer trail;

    // Start is called before the first frame update
    void Awake()
    {
        trail = GetComponent<LineRenderer>();
        trail.sortingLayerName = "Foreground";
    }

    public void Render(Vector3 startpoint, Vector3 endpoint)
    {
        trail.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startpoint;
        points[1] = endpoint;

        trail.SetPositions(points);
    }

    public void EndLine()
    {
        trail.positionCount = 0;
    }
}
