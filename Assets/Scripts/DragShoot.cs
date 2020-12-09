using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragShoot : MonoBehaviour
{
    public float power = 10f;
    public GameObject deathMenu;
    public GameObject winMenu;
    public Vector2 minPower;
    public Vector2 maxPower;
    public float strokes = 0;
    

    private Rigidbody2D ball;
    private Camera cam;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool grounded = false;
    private RectTransform rt;

    private trajectory_render trail;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        ball = GetComponent<Rigidbody2D>();
        trail = GetComponent<trajectory_render>();
        rt = winMenu.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(grounded);

        if (Input.touchCount > 0 && grounded)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPoint = cam.ScreenToWorldPoint(touch.position);
                startPoint.z = 15;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 current = cam.ScreenToWorldPoint(touch.position);
                current.z = 15;
                trail.Render(startPoint, current);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endPoint = cam.ScreenToWorldPoint(touch.position);
                endPoint.z = 15;

                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                ball.AddForce(force * power, ForceMode2D.Impulse);
                trail.EndLine();
                grounded = false;
                strokes++;
            }
        }
    }

   private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "planet")
        {
            grounded = true;
            Vector2 vel = ball.velocity;

            ball.AddForce(-(vel/2), ForceMode2D.Impulse);
           
        }

        if (col.gameObject.name == "Goal")
        {
            rt.anchoredPosition = Vector3.zero;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Boundary")
        {
            Dead();
        }
    }

    private void Dead()
    {
        deathMenu.SetActive(true);
        Destroy(gameObject);
    }
}
