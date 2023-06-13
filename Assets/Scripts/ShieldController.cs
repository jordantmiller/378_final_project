using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    public AudioSource shieldAudioSource;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player") {

            if (shieldAudioSource.isPlaying) {
                shieldAudioSource.Stop();
            }

            shieldAudioSource.Play();

            Destroy(gameObject);
        }
    }
}
