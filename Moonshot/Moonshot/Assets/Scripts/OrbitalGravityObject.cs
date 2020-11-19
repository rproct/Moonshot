using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Original: https://gist.github.com/oliverholmberg/de738361a07246991b56

public class OrbitalGravityObject : MonoBehaviour
{

    public float mass;
    public int soiRadius;
    public int proximityModifier = 195;
    private bool colliding;
    private float slowdown;

    void Start()
    {
        mass = mass * 100000;
        colliding = false;
        slowdown = -1f;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, soiRadius);
    }

    void FixedUpdate()
    { // Runs continuously during gameplay

        GameObject[] objectsAffectedByGravity; objectsAffectedByGravity = GameObject.FindGameObjectsWithTag("affectedByPlanetGravity");

        foreach (GameObject gravBody in objectsAffectedByGravity)
        {
            Rigidbody2D gravRigidBody = gravBody.GetComponent<Rigidbody2D>();
            float orbitalDistance = Vector3.Distance(transform.position, gravRigidBody.transform.position);

            if (orbitalDistance < soiRadius)
            {
                Vector3 objectOffset = transform.position - gravRigidBody.transform.position;
                objectOffset.z = 0;
                Vector3 objectTrajectory = gravRigidBody.velocity;
                float angle = Vector3.Angle(objectOffset, objectTrajectory);
                float magsqr = objectOffset.sqrMagnitude;
                Vector2 speed = gravRigidBody.velocity;

                if (magsqr > 0.0001f)
                {
                    if (colliding == true)
                    {
                        Vector3 gravityVector = (mass * objectOffset.normalized / magsqr) * gravRigidBody.mass;
                        gravRigidBody.AddForce(gravityVector * (orbitalDistance / proximityModifier) * slowdown);
                    }
                    else
                    {
                        Vector3 gravityVector = (mass * objectOffset.normalized / magsqr) * gravRigidBody.mass;
                        gravRigidBody.AddForce(gravityVector * (orbitalDistance / proximityModifier));
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

   void OnTriggerExit2D(Collider2D collision)
   {
        colliding = false;
   }
}