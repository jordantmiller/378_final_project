using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public GameObject Player;
    public float thrustIncrement = 2f;
    public float currentThrust;
    public float newThrust;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            Destroy(gameObject);
            currentThrust = Player.GetComponent<PlayerMovement>.thrust;
            newThrust = currentThrust + thrustIncrement;
        }
    }
}
