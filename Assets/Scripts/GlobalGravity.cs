using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGravity : MonoBehaviour
{
    private PlayerMovementScript pm;
    public float gravityConstant = 10.0f;
    public Rigidbody2D[] bodies;

    // Start is called before the first frame update
    void Start()
    {
        bodies = FindObjectsOfType<Rigidbody2D>();    
        pm = FindObjectsOfType<PlayerMovementScript>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (pm.areControlsEnabled()) {
            foreach (Rigidbody2D body1 in bodies)
            {
                foreach (Rigidbody2D body2 in bodies)
                {
                    if (body1 != body2 && body1 != null && body2 != null && !body2.CompareTag("Player"))
                    {
                        Vector2 direction = body2.position - body1.position;
                        float distance = direction.magnitude;

                        float forceMagnitude = gravityConstant * (body1.mass * body2.mass) / (distance * distance);
                        Vector2 force = direction.normalized * forceMagnitude;

                        body2.AddForce(-force);
                    }
                }
            }
        }
    }
}
