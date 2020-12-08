using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShoot : MonoBehaviour
{
    public float power = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;

    private Rigidbody2D ball;
    private Camera cam;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        ball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPoint = cam.ScreenToWorldPoint(touch.position);
                startPoint.z = 15;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endPoint = cam.ScreenToWorldPoint(touch.position);
                endPoint.z = 15;

                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                ball.AddForce(force * power, ForceMode2D.Impulse);
            }
        }
    }
}
