using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    public GameObject target;
    public float smoothness = 1;
    public float[] zoomBounds = new float[] { 5, 9 };

    private Transform ball;
    private Rigidbody2D rb2d;
    private float speed;
    private float prevSpeed = 0;
    private Camera cam;
    private bool locked = false;

    private float size = 5;

    // Start is called before the first frame update
    void Start()
    {
        
        cam = GetComponent<Camera>();
        ball = target.GetComponent<Transform>();
        rb2d = target.GetComponent<Rigidbody2D>();

        size = cam.orthographicSize;
        speed = rb2d.velocity.magnitude;
        prevSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            if (!locked)
            {
                if (transform.position != target.transform.position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (60 * Time.deltaTime));
                }
                else
                    locked = true;
            }
            else
                transform.position = target.transform.position;


            speed = rb2d.velocity.magnitude;

            //Debug.Log(rb2d.velocity);
            if (size > zoomBounds[1])
            {
                size -= .5f;
            }
            else
            {
                if (speed > prevSpeed)
                {
                    size += smoothness;
                    prevSpeed = speed;
                }

                if (speed < prevSpeed)
                {
                    size -= smoothness;
                    prevSpeed = speed;
                }

                size = Mathf.Clamp(speed / 2, zoomBounds[0], zoomBounds[1]);
            }

            cam.orthographicSize = size;
        }
    }
}
