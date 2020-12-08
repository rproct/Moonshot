using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    public GameObject target;

    private Transform ball;
    private Rigidbody2D rb2d;
    private float speed;
    private Camera cam;
    private float[] zoomBounds = new float[] { 5, 9 };
    private float size = 5;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        ball = target.GetComponent<Transform>();
        rb2d = target.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        speed = rb2d.velocity.magnitude;

        if (Input.touchCount == 2)
        {
            Vector2 touch1, touch2;
            float dist;
            touch1 = Input.GetTouch(0).position;
            touch2 = Input.GetTouch(1).position;
            dist = Vector2.Distance(touch1, touch2);

            size = Mathf.Clamp(dist, zoomBounds[0], zoomBounds[1]);
        }

        Debug.Log(speed);
        size = Mathf.Clamp(speed/2, zoomBounds[0], zoomBounds[1]);

        cam.orthographicSize = size;
    }
    */
}

