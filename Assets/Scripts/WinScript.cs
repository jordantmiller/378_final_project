using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private SceneController sc;
    private PlayerMovementScript pm;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            sc = FindObjectsOfType<SceneController>()[0];
            pm = FindObjectsOfType<PlayerMovementScript>()[0];
            sc.winScreen();
            pm.enableControls(false);
        }
    }
}
