using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{

    public GameObject player;
    public float gravityConstant = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        Vector2 direction = player.transform.position - transform.position;

        float distance = direction.magnitude + 1;
        float forceMagnitude = gravityConstant * (playerRb.mass * GetComponent<Rigidbody2D>().mass) / Mathf.Pow(distance, 2);

        Vector2 force = direction.normalized * forceMagnitude;
        playerRb.AddForce(-force);
    }
    
}
