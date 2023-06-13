using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public GameObject player;
    public static int currentStarCount;
    public static int totalStarCount;
    public static TextMeshProUGUI starCountText;
    private float thrustIncrement = 5f;
    public float currentThrust;
    public float newThrust;


    void Start() {
        currentStarCount = 0;
        totalStarCount = GetTotalStars();
        GameObject textObject = GameObject.Find("StarText");
        starCountText = textObject.GetComponent<TextMeshProUGUI>();
        starCountText.text = string.Format("{0}/{1}", currentStarCount, totalStarCount);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            player = GameObject.Find("Player");
            player.GetComponent<PlayerMovementScript>().thrust += thrustIncrement;
            Debug.Log("Added thrust. New thrust: " + player.GetComponent<PlayerMovementScript>().thrust);
            currentStarCount++;
            starCountText.text = string.Format("{0}/{1}", currentStarCount, totalStarCount);
            Destroy(gameObject);
        }
    }

    private int GetTotalStars() {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("speedBoost");
        return stars.Length;
    }
}
