using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public GameObject player;
    private float thrustIncrement = 5f;
    public float currentThrust;
    public float newThrust;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            player = GameObject.Find("Player");
            player.GetComponent<PlayerMovementScript>().thrust += thrustIncrement;
            Debug.Log("Added thrust. New thrust: " + player.GetComponent<PlayerMovementScript>().thrust);
            Destroy(gameObject);
        }
    }
}
