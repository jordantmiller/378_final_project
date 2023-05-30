using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneStars : MonoBehaviour
{
    public GameObject starPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;

    void Start(){
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        StartCoroutine(newStar());
    }
    private void spawnStar(){
        GameObject a = Instantiate(starPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator newStar(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnStar();
        }
    }
}
