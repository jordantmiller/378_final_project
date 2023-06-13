using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    public float damageMultiplier = 0.02f;
    public float forceFieldNegation = 1f;
    public SceneController sc;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        sc = FindObjectsOfType<SceneController>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            sc.resetGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Finish")) {
            float damage = other.relativeVelocity.magnitude * damageMultiplier * forceFieldNegation;
            TakeDamage((int)damage);
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }

            audioSource.Play();

        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("ForceField")){
            forceFieldNegation = 0f;
            yield return new WaitForSeconds(8.0f);
            forceFieldNegation = 1f;
        }
    }




}
