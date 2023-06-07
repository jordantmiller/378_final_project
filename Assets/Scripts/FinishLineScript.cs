using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour
{
    public TimeController timeController;
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other) {
        timeController.StopTimer();
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        SceneManager.LoadScene(sceneName);
    } 
}
