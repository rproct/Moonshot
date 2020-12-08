using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionSlow : MonoBehaviour
{
    void Start()
    {
        Vector2 force;
        force = new Vector2(0.0f, -50.0f);
        Rigidbody2D gravRigidBody = GetComponent<Rigidbody2D>();
        gravRigidBody.AddForce(force);
    }
    void Update()
    {

    }

}
