using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAni : MonoBehaviour
{
    public float degree;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * degree);
    }
}
