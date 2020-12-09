using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prediction_path : MonoBehaviour
{

    public GameObject predictionPointPrefab;

    public GameObject [] predictionPoints;

    private Rigidbody2D rb2d;

    public int pathPoints;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        predictionPoints = new GameObject[pathPoints];

        for(int i = 0; i < pathPoints; i++)
        {
            predictionPoints[i] = Instantiate(predictionPointPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < predictionPoints.Length; i++)
        {
            predictionPoints[i].transform.position = pointPosition(i * 0.5f);
        }
    }

    Vector2 pointPosition(float t)
       {
            Vector2 currentPointPosition = (Vector2)transform.position * rb2d.velocity.magnitude * 0.5f * Physics2D.gravity * (t * t);

            return currentPointPosition;
       }
    }
